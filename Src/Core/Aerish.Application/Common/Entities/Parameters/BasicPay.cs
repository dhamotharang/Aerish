using Aerish.Domain.Common.Keys;
using Aerish.Domain.Entities.Common;
using System;

namespace Aerish.Domain.Entities.Parameters
{
    public class BasicPay : EmployeeKey
    {
        public int BasicPayID { get; set; }

        public short PeriodStartID { get; set; }
        public short? PeriodEndID { get; set; }


        public decimal Amount { get; set; }
        public AmountBasis AmountBasis { get; set; }

        public DateTime Effectivity { get; set; }
        public Employee N_Employee { get; set; }
        public Period N_PeriodStart { get; set; }
        public Period N_PeriodEnd { get; set; }
    }
}
