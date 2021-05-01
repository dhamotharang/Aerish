using System;
using System.Collections.Generic;
using Aerish.Domain.Common;
using Aerish.Domain.Models;

namespace Aerish.Interfaces
{
    public interface IProcessTrackerBase
    {
        Guid UID { get; set; }

        bool? Aborted { get; }

        short? PlanYear { get; set; }
        short? PayRunID { get; set; }
        int ProcessInstanceID { get; set; }
    }

    public interface IProcessTracker : IProcessTrackerBase
    {
        bool? SaveContext { get; set; }

        JobBO Job { get; set; }
        ProcessInstanceBO ProcessInstance { get; }
        ParameterDictionary Parameters { get; set; }

        void AttachJob(JobBO job, ParameterDictionary parameters);


        void LogError(Exception exception);
        void LogMessage(string message);
        void LogMessage(string formattedMsg, params object[] args);

        void JobStarted();
        void JobEnded();
        IEnumerable<Exception> JobErrors();
        void Abort();

    }
}
