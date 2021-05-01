using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aerish.Domain.Common;
using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.PayRunQrs
{
    public class GetPayRunQr : ITasq<QueryResult<PayRunBO>>
    {
        public GetPayRunQr(short planYear, QueryParameter parameter = null)
        {
            PlanYear = planYear;
            Parameter = parameter;
        }

        public short PlanYear { get; }
        public QueryParameter Parameter { get; }
    }
}
