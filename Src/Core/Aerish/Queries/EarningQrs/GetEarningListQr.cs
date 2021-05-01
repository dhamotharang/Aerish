using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.EarningQrs
{
    public class GetEarningListQr : ITasq<IEnumerable<EarningBO>>
    {

        public GetEarningListQr(bool clientSpecific = true)
        {
            ClientSpecific = clientSpecific;
        }

        public bool ClientSpecific { get; }
    }
}
