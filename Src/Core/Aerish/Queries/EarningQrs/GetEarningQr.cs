using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.EarningQrs
{
    public class GetEarningQr : ITasq<EarningBO>
    {

        public GetEarningQr(string earningCode)
        {
            EarningCode = earningCode;
        }

        public string EarningCode { get; }
    }
}
