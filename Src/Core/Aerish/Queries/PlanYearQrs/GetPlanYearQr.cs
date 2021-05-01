using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aerish.Domain.Common;
using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.PlanYearQrs
{
    public class GetPlanYearQr : ITasq<QueryResult<PlanYearBO>>
    {
        public GetPlanYearQr(QueryParameter queryParameter = null)
        {
            QueryParameter = queryParameter;
        }

        public QueryParameter QueryParameter { get; }
    }
}
