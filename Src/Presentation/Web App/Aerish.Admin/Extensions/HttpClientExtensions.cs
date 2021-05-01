using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Json;

using Aerish.Domain.Common;

namespace Aerish.Admin.Client
{
    public static class HttpClientExtensions
    {
        public static Task<T> GetFromJsonAsync<T>(this HttpClient client, string requestUri, QueryParameter queryParameter, CancellationToken cancellationToken = default)
        {
            string reqUri = requestUri;
            List<string> qs = new List<string>();

            if (queryParameter != null)
            {
                qs.Add($"PageSize={queryParameter.PageSize}");
                qs.Add($"PageNumber={queryParameter.PageNumber}");
            }

            if (qs.Any())
            {
                reqUri = reqUri + "?" + string.Join("&", qs);
            }

            return client.GetFromJsonAsync<T>(reqUri, cancellationToken);
        }
    }
}
