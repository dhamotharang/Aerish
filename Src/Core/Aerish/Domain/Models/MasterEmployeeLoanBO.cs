using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class MasterEmployeeLoanBO
    {
        public int MasterEmployeeLoanID { get; set; }

        public short LoanID { get; set; }

        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }

        public decimal Amount { get; set; }

        public RecordStatus RecordStatus { get; set; }

        public LoanBO Loan { get; set; }
    }
}
