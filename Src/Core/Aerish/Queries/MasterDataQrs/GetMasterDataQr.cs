using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aerish.Common.Models;
using Aerish.Domain.Common;
using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.MasterDataQrs
{
    public class GetMasterDataQr : ITasq<QueryResult<MasterDataSummaryBO>>
    {
        public GetMasterDataQr(short planYear, int? personId, QueryParameter queryParameter = null)
        {
            PlanYear = planYear;
            PersonId = personId;
            QueryParameter = queryParameter;
        }

        public short PlanYear { get; }
        public int? PersonId { get; }
        public QueryParameter QueryParameter { get; }
    }
}
