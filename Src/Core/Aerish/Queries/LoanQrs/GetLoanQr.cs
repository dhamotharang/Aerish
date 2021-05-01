using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.LoanQrs
{
    public class GetLoanQr : ITasq<LoanBO>
    {

        public GetLoanQr(string loanCode, bool clientSpecific = true)
        {
            LoanCode = loanCode;
            ClientSpecific = clientSpecific;
        }

        public string LoanCode { get; }
        public bool ClientSpecific { get; }
    }
}
