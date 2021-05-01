using System;
using System.Collections.Generic;
using Aerish.Constants;
using Aerish.Domain.Common;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Models;
using Aerish.Interfaces;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace Aerish.Application.Common.Models
{
    public class ProcessTracker : IProcessTracker
    {
        private readonly DbContext p_DbContext;
        private readonly IDateTime p_DateTime;
        private readonly IAppSession p_AppSession;
        private readonly ProcessInstance p_DbProcessInstance;
        private readonly IMapper p_Mapper;
        private bool jobInstanceIsSaved = false;
        private List<Exception> jobErrors = new List<Exception>();
        private bool? aborted = null;

        public short? PlanYear { get; set; }
        public short? PayRunID { get; set; }
        public short? ClientID { get; set; }

        public int ProcessInstanceID { get; set; }


        public JobBO Job { get; set; }
        public ParameterDictionary Parameters { get; set; }

        public ProcessInstanceBO ProcessInstance { get => p_Mapper.Map<ProcessInstanceBO>(p_DbProcessInstance); }

        public Guid UID { get; set; } = Guid.NewGuid();
        public bool? Aborted { get => aborted; }
        public bool? SaveContext { get; set; }

        public ProcessTracker(DbContext dbContext, IDateTime dateTime, IAppSession appSession, ProcessInstance dbProcessInstance, IMapper mapper)
        {
            p_DbContext = dbContext;
            p_DateTime = dateTime;
            p_AppSession = appSession;

            p_DbProcessInstance = dbProcessInstance;
            p_Mapper = mapper;
            }

        public void LogError(Exception exception)
        {
            if (jobErrors.Count >= 10)
            {
                Abort();
                return;
            }

            p_DbProcessInstance.N_InstanceErrors.Add(new ProcessInstanceError
            {
                ErrorType = exception.GetType().FullName,
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                CreatedOn = p_DateTime.Now
            });

            p_DbContext.SaveChanges();

            jobErrors.Add(exception);
        }

        public void AttachJob(JobBO job, ParameterDictionary parameters)
        {
            if (jobInstanceIsSaved)
            {
                return;
            }

            parameters["ProcessInstanceID"] = new ParameterBO
            {
                DataType = InputDataTypeConstants.Int,
                Name = "ProcessInstanceID",
                Value = ProcessInstance.ProcessInstanceID.ToString()
            };

            parameters["ClientID"] = new ParameterBO
            {
                DataType = InputDataTypeConstants.SmallInt,
                Name = "ClientID",
                Value = ClientID.ToString()
            };

            Parameters = parameters;


            p_DbProcessInstance.JobID = job.JobID;
            p_DbProcessInstance.ClientID = p_AppSession.ClientID;

            Job = job;

            p_DbContext.SaveChanges();

            ProcessInstanceID = ProcessInstance.ProcessInstanceID;
            PlanYear = Parameters.GetAs<short?>("PlanYear");
            PayRunID = Parameters.GetAs<short?>("PayRunID");
            ClientID = Parameters.GetAs<short?>("ClientID") ?? p_AppSession.ClientID;


            jobInstanceIsSaved = true;

        }

        public void LogMessage(string message)
        {
            p_DbProcessInstance.N_InstanceMessages.Add(new ProcessInstanceMessage
            {
                Message = message,
                CreatedOn = p_DateTime.Now
            });

            p_DbContext.SaveChanges();

        }

        public void LogMessage(string formattedMsg, params object[] args)
        {
            string msg = string.Format(formattedMsg, args);

            LogMessage(msg);

        }

        public void JobStarted()
        {
            p_DbProcessInstance.JobStatus = JobStatus.Started;

            LogMessage("Job Started");
        }

        public void JobEnded()
        {
            p_DbProcessInstance.CompletedOn = p_DateTime.Now;
            p_DbProcessInstance.JobStatus = JobStatus.Completed;


            if (jobErrors.Count > 0)
            {
                if (aborted == true)
                {
                    p_DbProcessInstance.JobStatus = JobStatus.Error;
                    LogMessage($"Job Aborted with {jobErrors.Count} error/s");
                }
                else
                {
                    p_DbProcessInstance.JobStatus = JobStatus.Error;
                    LogMessage($"Job Finished with {jobErrors.Count} error/s");
                }
            }
            else
            {
                aborted = false;
                LogMessage("Job Finished");
            }

            p_DbContext.Dispose();

        }

        public IEnumerable<Exception> JobErrors()
        {
            return jobErrors;
        }

        public void Abort()
        {
            aborted = true;
        }
    }
}
