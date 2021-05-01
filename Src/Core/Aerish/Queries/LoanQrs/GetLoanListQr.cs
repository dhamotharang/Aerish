using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.LoanQrs
{
    public class GetLoanListQr : ITasq<IEnumerable<LoanBO>>
    {

        public GetLoanListQr(bool clientSpecific = true)
        {
            ClientSpecific = clientSpecific;
        }

        public bool ClientSpecific { get; }
    }
}
