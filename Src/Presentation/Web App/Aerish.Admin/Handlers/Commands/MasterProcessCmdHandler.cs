using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Aerish.Admin.ViewModels;
using Aerish.Admin.Shared;
using Aerish.Commands;
using Aerish.Constants;
using Aerish.Domain.Models;
using Aerish.Interfaces;

using TasqR;

namespace Aerish.Admin.Handlers.Commands
{
    public class MasterProcessCmdHandler : TasqHandlerAsync<MasterProcessCmd, IProcessTrackerBase>
    {
        private readonly HttpClient p_HttpClient;
        private readonly AdminAppSession p_AppSession;

        public MasterProcessCmdHandler(HttpClient httpClient, AdminAppSession appSession)
        {
            p_HttpClient = httpClient;
            p_AppSession = appSession;
        }

        public async override Task<IProcessTrackerBase> RunAsync(MasterProcessCmd request, CancellationToken cancellationToken = default)
        {
            int? personId = await p_AppSession.GetEmployeeID();

            p_HttpClient.DefaultRequestHeaders.Clear();

            if (personId != null)
            {
                p_HttpClient.DefaultRequestHeaders.Add("PersonId", personId.Value.ToString());
            }

            HttpResponseMessage response = null;

            switch (request.JobID)
            {
                case MainConstants.Job.MainCalc:
                    response = await p_HttpClient.PostAsJsonAsync
                        (
                            AerishAdminConstants.Uri.CalculateMasterData, 
                            request.Parameters as CalculateParameter, 
                            cancellationToken
                        );
                    break;
                default:
                    break;
            }

            if (response != null && response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<ProcessTrackerVM>(jsonResponse);
            }

            return null;
        }
    }
}
