using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Common;

namespace Aerish.Application.Common.Entities.Staging
{
    public class StagingBasicPay : BaseStagingEntity
    {
        public string EmployeeSysID { get; set; }

        public string PeriodStart { get; set; }
        public string PeriodEnd { get; set; }
        public decimal Amount { get; set; }
        public string Basis { get; set; }
        public string Effectivity { get; set; }
    }
}
