using Aerish.Domain.Entities.Parameters;
using System;
using System.Collections.Generic;

namespace Aerish.Domain.Entities.Common
{
    public class ProcessInstance
    {
        public int ProcessInstanceID { get; set; }

        public short ClientID { get; set; }
        public short JobID { get; set; }

        public JobStatus JobStatus { get; set; }

        public DateTime StartedOn { get; set; }
        public DateTime? CompletedOn { get; set; }


        public Job N_Job { get; set; }
        public ICollection<ProcessInstanceParameter> N_InstanceParameters { get; private set; } = new HashSet<ProcessInstanceParameter>();
        public ICollection<ProcessInstanceError> N_InstanceErrors { get; private set; } = new HashSet<ProcessInstanceError>();
        public ICollection<ProcessInstanceMessage> N_InstanceMessages { get; private set; } = new HashSet<ProcessInstanceMessage>();
    }
}
