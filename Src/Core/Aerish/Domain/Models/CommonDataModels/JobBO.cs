using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class JobBO
    {
        public short JobID { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }

        public TaskHandlerProviderBO TaskHandlerProvider { get; set; }
        public IEnumerable<JobParameterBO> JobParameters { get; set; }
    }
}