using System;
using Aerish.Application.Common.Models;
using Aerish.Commands.JobInstanceCmds;
using Aerish.Domain.Common;
using Aerish.Domain.Entities.Common;
using Aerish.Interfaces;

using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TasqR;

namespace Aerish.Application.Commands.JobInstanceCmds
{
    public class GetNewJobInstanceCmdHandler : TasqHandler<GetNewJobInstanceCmd, IProcessTracker>
    {
        private readonly IAppSession p_AppSession;
        private readonly IDateTime p_DateTime;
        private readonly IServiceScopeFactory p_ServiceScopeFactory;
        private readonly IMapper p_Mapper;

        public GetNewJobInstanceCmdHandler
            (
                IAppSession appSession,
                IDateTime dateTime,
                IServiceScopeFactory serviceScopeFactory,
                IMapper mapper
            )
        {
            p_AppSession = appSession;
            p_DateTime = dateTime;
            p_ServiceScopeFactory = serviceScopeFactory;
            p_Mapper = mapper;
        }

        public override IProcessTracker Run(GetNewJobInstanceCmd process)
        {
            var scope = p_ServiceScopeFactory.CreateScope();
            var provider = scope.ServiceProvider;
            var dbContext = provider.GetService<IAerishDbContext>();
            var baseDbContext = provider.GetService<DbContext>();

            var newJobInstance = new ProcessInstance
            {
                StartedOn = p_DateTime.Now,
                JobStatus = JobStatus.Initialized
            };

            dbContext.ProcessInstances.Add(newJobInstance);

            return new ProcessTracker(baseDbContext, p_DateTime, p_AppSession, newJobInstance, p_Mapper);
        }
    }
}