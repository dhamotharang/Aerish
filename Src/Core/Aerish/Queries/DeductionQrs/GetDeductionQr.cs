using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.DeductionQrs
{
    public class GetDeductionQr : ITasq<DeductionBO>
    {

        public GetDeductionQr(string deductionCode, bool clientSpecific = true)
        {
            DeductionCode = deductionCode;
            ClientSpecific = clientSpecific;
        }

        public string DeductionCode { get; }
        public bool ClientSpecific { get; }
    }
}
