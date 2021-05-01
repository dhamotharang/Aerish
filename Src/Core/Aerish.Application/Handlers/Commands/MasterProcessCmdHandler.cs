using System;
using System.Linq;
using System.Reflection;
using Aerish.Application.Queries.JobQrs;
using Aerish.Commands;
using Aerish.Commands.JobInstanceCmds;
using Aerish.Domain.Common;
using Aerish.Interfaces;
using Aerish.Queries.JobQrs;

using Microsoft.EntityFrameworkCore;
using TasqR;

namespace Aerish.Application.Commands.MasterCmds
{
    public class MasterProcessCmdHandler : TasqHandler<MasterProcessCmd, IProcessTrackerBase>
    {
        private readonly ITasqR p_Processor;
        private readonly DbContext p_BaseDbContext;

        public MasterProcessCmdHandler
            (
                ITasqR processor,
                DbContext baseDbContext
            )
        {
            p_Processor = processor;
            p_BaseDbContext = baseDbContext;
        }

        public override IProcessTrackerBase Run(MasterProcessCmd request)
        {
            var jobTracker = p_Processor.Run(new GetNewJobInstanceCmd());

            var job = p_Processor.Run(new FindJobQr(request.JobID));
            if (job == null)
            {
                throw new AerishNullReferenceException("Job", request.JobID);
            }

            foreach (var jobParams in job.JobParameters)
            {
                var paramDic = request.Parameters[jobParams.Name];

                if (paramDic != null)
                {
                    paramDic.DataType = jobParams.DataType;
                    paramDic.IsRequired = jobParams.IsRequired;
                    paramDic.MaxLength = jobParams.MaxLength;
                }
            }

            jobTracker.AttachJob(job, request.Parameters);

            jobTracker.JobStarted();

            try
            {
                var handlerProvider = job.TaskHandlerProvider;

                var assembly = Assembly.Load(assemblyString: handlerProvider.TaskAssembly);
                var type = assembly.GetType(handlerProvider.TaskClass);

                var instance = (ITasq)Activator.CreateInstance(type, args: new object[] { jobTracker });

                if (handlerProvider.IsDefaultHandler)
                {
                    p_Processor.Run(instance);
                }
                else
                {
                    var assemblyH = Assembly.Load(assemblyString: handlerProvider.HandlerAssembly);
                    var typeH = assemblyH.GetType(name: handlerProvider.HandlerClass);

                    p_Processor.UsingAsHandler(typeH).Run(instance);
                }

                if (jobTracker.SaveContext == true)
                {
                    p_BaseDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                jobTracker.LogError(ex.InnermostException());
            }

            jobTracker.JobEnded();

            return jobTracker;
        }
    }
}