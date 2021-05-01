using Aerish.Domain.Common.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Domain.Entities.Parameters
{
    public class PayRun : PayRunKey
    {
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime CutOffStart { get; set; }
        public DateTime CutOffEnd { get; set; }

        public DateTime PayoutDate { get; set; }

        public PlanYear N_PlanYear { get; set; }
    }
}
