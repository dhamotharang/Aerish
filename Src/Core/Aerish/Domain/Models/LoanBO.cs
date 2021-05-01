using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class LoanBO
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

        public LoanTypeBO LoanType { get; set; }
        public TaskHandlerProviderBO TaskHandlerProvider { get; set; }

        public override string ToString()
        {
            return AltDesc ?? LongDesc ?? ShortDesc;
        }
    }
}
