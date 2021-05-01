using System;
using System.Collections.Generic;
using System.Text;


namespace Aerish.Domain.Models
{
    public class PayRunBO
    {
        public short ClientID { get; set; }
        public short PlanYear { get; set; }
        public short PayRunID { get; set; }

        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime CutOffStart { get; set; }
        public DateTime CutOffEnd { get; set; }

        public DateTime PayoutDate { get; set; }
    }
}
