using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Domain.Common.Keys;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;

namespace Aerish.Domain.Entities.CalcData
{
    public class MasterEmployeeLoan : MasterEmployeeKey
    {
        public int MasterEmployeeLoanID { get; set; }

        public short LoanID { get; set; }

        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }

        public decimal Amount { get; set; }

        public RecordStatus RecordStatus { get; set; }

        public PayRun N_PayRun { get; set; }
        public Loan N_Loan { get; set; }
    }
}
