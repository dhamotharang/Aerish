using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Aerish.Admin.Client.Services;
using Aerish.Admin.Client.ViewModels;
using Aerish.Admin.Shared;
using Aerish.Admin.Shared.ViewModels;
using Aerish.Commands;
using Aerish.Constants;
using Aerish.Domain.Models;
using Aerish.Queries.PlanYearQrs;

using Microsoft.AspNetCore.Components;

using TasqR;

using Telerik.Blazor.Components;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;

namespace Aerish.Admin.Client.Pages.Employee
{
    public partial class PayrollRuns
    {
        [Inject]
        public DataService DataService { get; set; }

        [Inject]
        public AdminAppSession AppSession { get; set; }

        [Inject]
        public ITasqR TasqR { get; set; }

        public TelerikGrid<MasterDataSummaryVM> grdPayRuns { get; set; }

        protected int Total { get; private set; } = 0;
        protected IEnumerable<MasterDataSummaryVM> Data { get; private set; }


        public bool WindowVisible { get; set; }
        public bool IsRequesting { get; set; } = true;
        public bool CanCalculate { get; set; }

        public PayRunVM NewCalcPayRun { get; set; }


        public IEnumerable<PlanYearBO> PlanYearData { get; set; }
        public IEnumerable<PayRunVM> PayRunData { get; set; }




        protected async override Task OnInitializedAsync()
        {
            var planYearResponse = await TasqR.RunAsync(new GetPlanYearQr());

            PlanYearData = planYearResponse.Data;

            CanCalculate = await DataService.GetAsync<bool>(AerishAdminConstants.Uri.MasterData + "/CanCalculate");
        }





        protected async Task ReadItems(GridReadEventArgs args)
        {
            IsRequesting = true;

            var response = await DataService.GetAsync<MasterDataSummaryVM[]>(AerishAdminConstants.Uri.MasterData, args.Request);

            IsRequesting = false;

            Total = response.Count;
            Data = response.Data;

            StateHasChanged();
        }

        protected async Task OnReload()
        {
            var args = new GridReadEventArgs
            {
                Request = new DataSourceRequest
                {
                    Page = grdPayRuns.Page,
                    PageSize = grdPayRuns.PageSize
                }
            };

            await grdPayRuns.OnRead.InvokeAsync(args);
        }

        short? lastPlanYear { get; set; }
        protected async Task OnPlanYearChange(object args)
        {
            short curPlanYear = (short)args;

            if (!curPlanYear.Equals(lastPlanYear))
            {
                PayRunData = new List<PayRunVM>();

                var dsReq = new DataSourceRequest
                {
                    Filters = new List<IFilterDescriptor>() { new FilterDescriptor("PlanYear", FilterOperator.IsEqualTo, args) }
                };

                var payRunResponse = await DataService.GetAsync<IEnumerable<PayRunVM>>(AerishAdminConstants.Uri.PayRun, dsReq);
                PayRunData = payRunResponse.Data;
            }

            lastPlanYear = curPlanYear;
        }

        protected void OnCalculatePayRunClick()
        {
            WindowVisible = true;
            NewCalcPayRun = new PayRunVM();
        }

        protected async Task OnWindowCalculatePayRun()
        {
            WindowVisible = false;
            CanCalculate = false;

            var calcParam = new CalculateParameter
            {
                PayRunID = NewCalcPayRun.PayRunID.GetValueOrDefault(),
                PlanYear = NewCalcPayRun.PlanYear.GetValueOrDefault(),
                PersonID = await AppSession.GetEmployeeID()
            };

            var cmd = new MasterProcessCmd(MainConstants.Job.MainCalc, calcParam);
            var result = await TasqR.RunAsync(cmd);


            //var calcParam = new CalculateParameterVM
            //{
            //    PayRunID = NewCalcPayRun.PayRunID,
            //    PlanYear = NewCalcPayRun.PlanYear,
            //    PersonID = await AppSession.GetEmployeeID()
            //};

            //var result = await DataService.PostAsync<ProcessTrackerVM, CalculateParameterVM>
            //    (
            //        AerishAdminConstants.Uri.CalculateMasterData,
            //        calcParam
            //    );

            CanCalculate = true;
            NewCalcPayRun = new PayRunVM();
            PayRunData = null;
            lastPlanYear = null;

            await OnReload();
        }

        protected void OnWindowCalculatePayRunCancelClick()
        {
            WindowVisible = false;
            NewCalcPayRun = new PayRunVM();
        }
    }
}
