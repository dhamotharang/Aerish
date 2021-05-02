using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models.Imports
{
    public class StagingBasicPayBO : BaseStagingBO
    {
        public string EmployeeSysID { get; set; }

        public string PeriodStart { get; set; }
        public string PeriodEnd { get; set; }
        public decimal Amount { get; set; }
        public string Basis { get; set; }
        public string Effectivity { get; set; }
    }
}
