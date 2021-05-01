using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

using Aerish.Domain.Models;
using Aerish.Queries.NavigationQrs;

using TasqR;

namespace Aerish.Admin.Client.Handlers.Queries.NavigationQrs
{
    public class GetNavigationQrHandler : TasqHandlerAsync<GetNavigationQr, NodeItemSetBO>
    {
        private readonly HttpClient p_HttpClient;

        public GetNavigationQrHandler(HttpClient httpClient)
        {
            p_HttpClient = httpClient;
        }

        public async override Task<NodeItemSetBO> RunAsync(GetNavigationQr request, CancellationToken cancellationToken = default)
        {
            string requestUri = "Navigation";

            List<string> qs = new List<string>();

            int? employeeId = request.EmployeeID;
            string navUri = request.CurrentUri;
            string search = request.Filter;


            if (employeeId != null && employeeId != 0)
            {
                qs.Add($"employeeId={employeeId}");
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                qs.Add($"filter={search.Trim()}");
            }

            if (!string.IsNullOrWhiteSpace(navUri) && navUri.Trim() != "/")
            {
                qs.Add($"currentUri={navUri.Trim()}");
            }

            if (qs.Any())
            {
                requestUri = requestUri + "?" + string.Join("&", qs);
            }

            var result = await p_HttpClient.GetFromJsonAsync<NodeItemSetBO>(requestUri);

            return result;
        }
    }
}