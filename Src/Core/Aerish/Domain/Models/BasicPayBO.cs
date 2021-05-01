using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class BasicPayBO
    {
        public int EmployeeID { get; set; }
        public short ClientID { get; set; }

        public int BasicPayID { get; set; }

        public short PeriodStartID { get; set; }
        public short? PeriodEndID { get; set; }


        public decimal Amount { get; set; }
        public AmountBasis AmountBasis { get; set; }

        public DateTime Effectivity { get; set; }
    }
}
