using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

using Aerish.Domain.Common;
using Aerish.Domain.Models;
using Aerish.Queries.PlanYearQrs;

using TasqR;

namespace Aerish.Admin.Handlers.Queries.PlanYearQrs
{
    public class GetPlanYearQrHandler : TasqHandlerAsync<GetPlanYearQr, QueryResult<PlanYearBO>>
    {
        private readonly HttpClient p_HttpClient;

        public GetPlanYearQrHandler(HttpClient httpClient)
        {
            p_HttpClient = httpClient;
        }

        public override Task<QueryResult<PlanYearBO>> RunAsync(GetPlanYearQr request, CancellationToken cancellationToken = default)
        {
            return p_HttpClient.GetFromJsonAsync<QueryResult<PlanYearBO>>
                (
                    AerishAdminConstants.Uri.PlanYear,
                    request.QueryParameter,
                    cancellationToken
                );
        }
    }
}