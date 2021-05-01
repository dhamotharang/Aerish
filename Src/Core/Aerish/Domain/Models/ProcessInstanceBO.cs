using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerish.Domain.Models
{
    public class ProcessInstanceBO
    {
        public int ProcessInstanceID { get; set; }

        public short ClientID { get; set; }
        public short JobID { get; set; }

        public JobStatus JobStatus { get; set; }

        public DateTime StartedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public JobBO Job { get; set; }

        private List<ProcessInstanceMessageBO> instanceMessages = new List<ProcessInstanceMessageBO>();
        public IEnumerable<ProcessInstanceMessageBO> InstanceMessages { get => instanceMessages; set => instanceMessages = value.ToList(); }

        private List<ProcessInstanceErrorBO> instanceErrors = new List<ProcessInstanceErrorBO>();
        public IEnumerable<ProcessInstanceErrorBO> InstanceErrors { get => instanceErrors; set => instanceErrors = value.ToList(); }


        public void AddMessage(ProcessInstanceMessageBO message)
        {
            instanceMessages.Add(message);
        }

        public void AddError(ProcessInstanceErrorBO error)
        {
            instanceErrors.Add(error);
        }
    }
}
