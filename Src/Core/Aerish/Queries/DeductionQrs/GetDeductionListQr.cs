using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.DeductionQrs
{
    public class GetDeductionListQr : ITasq<IEnumerable<DeductionBO>>
    {

        public GetDeductionListQr(bool clientSpecific = true)
        {
            ClientSpecific = clientSpecific;
        }

        public bool ClientSpecific { get; }
    }
}
