using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Aerish.Admin.Shared;

using Telerik.DataSource;

namespace Aerish.Admin.Client.Services
{
    public class RequestResponse<T>
    {
        public int Count { get; set; }
        public T Data { get; set; }
    }

    public class DataService
    {
        private readonly HttpClient p_HttpClient;
        private readonly AdminAppSession p_AppSession;

        protected DataService() { }

        public DataService(HttpClient httpClient, AdminAppSession appSession)
        {
            p_HttpClient = httpClient;
            p_AppSession = appSession;
        }

        public virtual async Task<T> GetAsync<T>(string uri)
        {
            Console.WriteLine(uri);

            int? personId = await p_AppSession.GetEmployeeID();

            if (p_HttpClient.DefaultRequestHeaders.Contains("PersonId"))
            {
                p_HttpClient.DefaultRequestHeaders.Remove("PersonId");
            }

            if (personId != null)
            {
                p_HttpClient.DefaultRequestHeaders.Add("PersonId", personId.Value.ToString());
            }

            return await p_HttpClient.GetFromJsonAsync<T>(uri);
        }

        public virtual Task<RequestResponse<T>> GetAsync<T>(string uri, DataSourceRequest dataSourceRequest)
        {
            Dictionary<string, string> queryString = new Dictionary<string, string>();

            if (dataSourceRequest.Filters != null && dataSourceRequest.Filters.Count > 0)
            {
                var filter = dataSourceRequest.Filters[0] as FilterDescriptor;

                if (!string.IsNullOrWhiteSpace(filter.Member))
                {
                    queryString["Filter.Member"] = filter.Member;
                }

                if (filter.Value != null && filter.Value.ToString().Trim() != string.Empty)
                {
                    queryString["Filter.Value"] = filter.Value.ToString().Trim();
                }
            }

            if (dataSourceRequest.PageSize > 0)
            {
                queryString["PageSize"] = $"{dataSourceRequest.PageSize}";
            }

            if (dataSourceRequest.Page > 0)
            {
                queryString["PageNumber"] = $"{dataSourceRequest.Page}";
            }

            string qr = "";

            if (queryString.Count > 0)
            {
                qr = "?" + string.Join("&", queryString.Select(a => $"{a.Key}={a.Value}"));
            }

            return GetAsync<RequestResponse<T>>(uri + qr);
        }

        public virtual async Task<T> PostAsync<T, TValue>(string uri, TValue content, CancellationToken cancellationToken = default)
        {
            int? personId = await p_AppSession.GetEmployeeID();

            if (personId != null)
            {
                p_HttpClient.DefaultRequestHeaders.Add("PersonId", personId.Value.ToString());
            }

            var response = await p_HttpClient.PostAsJsonAsync<TValue>(uri, content, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<T>(jsonResponse);
            }

            return default;
        }    
    }
}
