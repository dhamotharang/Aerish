using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Blazored.SessionStorage;
using Telerik.Blazor.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Aerish.Admin.Shared;
using TasqR;
using Aerish.Queries.NavigationQrs;
using Aerish.Domain.Models;
using System.Text.Json;

namespace Aerish.Admin.Shared
{
    public class NavMenuBase : ComponentBase
    {
        [Inject]
        public AdminAppSession appSession { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public ITasqR TasqR { get; set; }


        protected string SearchMenu { get; set; }
        public TelerikTreeView NavTreeView { get; set; }

        private bool collapseNavMenu = true;

        protected string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        public IEnumerable<object> SelectedNavigations { get; set; } = new List<object>();

        public ObservableCollection<NodeItemBO> FlatData { get; set; } = new ObservableCollection<NodeItemBO>();


        protected async override Task OnInitializedAsync()
        {
            int? employeeId = await appSession.GetEmployeeID();

            await LoadNavigations(employeeId);

            await base.OnInitializedAsync();
        }

        public async Task LoadNavigations(int? employeeId = null, string search = null)
        {
            string navUri = navigationManager.ToBaseRelativePath(navigationManager.Uri);

            var result = await TasqR.RunAsync(new GetNavigationQr(employeeId, search, navUri));

            FlatData.Clear();

            foreach (var item in result.Nodes)
            {
                FlatData.Add(item);
            }

            if (result.SelectedNode != null)
            {
                SelectedNavigations = new List<object>() { result.SelectedNode };
            }
        }
    }
}