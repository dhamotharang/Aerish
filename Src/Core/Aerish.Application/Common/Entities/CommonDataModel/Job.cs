using System.Collections.Generic;

using Aerish.Domain.Entities.Common;

namespace Aerish.Domain.Entities.Parameters
{
    public class Job
    {
        public short ClientID { get; set; }
        public short JobID { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }

        public bool IsEnabled { get; set; }

        public int? TaskHandlerProviderID { get; set; }


        public TaskHandlerProvider N_TaskHandlerProvider { get; set; }


        public ICollection<JobParameter> N_JobParameters { get; private set; } = new HashSet<JobParameter>();
    }
}
