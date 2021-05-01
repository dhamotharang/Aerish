using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Aerish.Admin.Client.Services;
using Aerish.Admin.Shared;

using Blazored.SessionStorage;

using Microsoft.AspNetCore.Components;

using Telerik.Blazor;
using Telerik.Blazor.Components;
using Telerik.DataSource;

namespace Aerish.Admin.Client.Shared
{
    public class MainLayoutBase : LayoutComponentBase
    {
        [Inject]
        public AdminAppSession appSession { get; set; }

        [Inject]
        public DataService DataService { get; set; }

        public bool HasSession { get; set; } = false;

        public int SelectedEmployeeID { get; set; }
        StringFilterOperator filterOperator { get; set; } = StringFilterOperator.StartsWith;
        public NavMenu NavMenu;
        public TelerikButton btnLogout = null;

        public IEnumerable<EmployeeSummaryVM> Suggestions { get; set; }

        protected async override Task OnInitializedAsync()
        {
            HasSession = (await appSession.GetEmployeeID()) != null;

            await base.OnInitializedAsync();
        }


        public async void OnSelectedEmployee(object selectedEmployeeID)
        {
            int employeeID = (int)selectedEmployeeID;

            await appSession.SetEmployeeSession(employeeID);

            await NavMenu.LoadNavigations(employeeID);

            HasSession = true;
        }

        public async Task Logout()
        {
            await appSession.LogoutEmployeeSession();
            await NavMenu.LoadNavigations();

            HasSession = false;

        }

        public async Task ReadItems(ComboBoxReadEventArgs args)
        {
            string userInput = null;

            if (args.Request.Filters.Count > 0)
            {
                var filter = args.Request.Filters[0] as FilterDescriptor;

                string tempUserInput = filter.Value.ToString();

                if (!string.IsNullOrWhiteSpace(tempUserInput) && tempUserInput.Trim().Length >= 3)
                {
                    userInput = tempUserInput;
                }
            }

            if (userInput != null)
            {
                var response = await DataService.GetAsync<EmployeeSummaryVM[]>("Employee/Search", args.Request);

                Suggestions = response.Data;
            }
            else
            {
                Suggestions = new List<EmployeeSummaryVM>();
            }
        }
    }
}
