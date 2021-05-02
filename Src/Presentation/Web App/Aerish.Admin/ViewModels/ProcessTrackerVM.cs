using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aerish.Interfaces;

namespace Aerish.Admin.ViewModels
{
    public class ProcessTrackerVM : IProcessTrackerBase
    {
        public Guid UID { get; set; }
        public bool? Aborted { get; }
        public short? PlanYear { get; set; }
        public short? PayRunID { get; set; }
        public int ProcessInstanceID { get; set; }
    }
}
