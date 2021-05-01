using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Domain.Entities.Common
{
    public class Loan
    {
        public short LoanID { get; set; }

        public short ClientID { get; set; }
        public string Code { get; set; }


        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }
        public short LoanTypeID { get; set; }
        public bool IsEnabled { get; set; }

        public int? TaskHandlerProviderID { get; set; }

        public LoanType N_LoanType { get; set; }
        public TaskHandlerProvider N_TaskHandlerProvider { get; set; }

        public override string ToString()
        {
            return AltDesc ?? LongDesc ?? ShortDesc;
        }
    }
}
