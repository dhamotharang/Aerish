using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Aerish.Application.Common.Helpers;
using Aerish.Application.Queries.DeductionQrs;
using Aerish.Application.Queries.EarningQrs;
using Aerish.Application.Queries.LoanQrs;
using Aerish.Application.Queries.MasterDataQrs;
using Aerish.Application.Queries.TableQrs;
using Aerish.Commands.CalcCmds;
using Aerish.Common.Models;
using Aerish.Constants;
using Aerish.Domain.Entities.CalcData;
using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.DeductionQrs;
using Aerish.Queries.EarningQrs;
using Aerish.Queries.LoanQrs;
using Aerish.Queries.MasterDataQrs;
using Aerish.Queries.PayRunQrs;
using Aerish.Queries.TableQrs;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using TasqR;

namespace Aerish.Application.Commands.CalcCmds
{
    public class MainCalcCmdHandler : TasqHandlerAsync<MainCalcCmd, int, bool>
    {
        private IProcessTracker p_ProcessTracker;
        private readonly ITasqR p_Processor;
        private readonly IAppSession p_AppSession;
        private readonly IMapper p_Mapper;
        private readonly IAerishDbContext p_DbContext;

        private PayRunBO p_PayPeriod = null;
        private MasterDataBO p_OldMasterData = null;
        private MasterDataBO p_NewMasterData = null;

        public MainCalcCmdHandler
            (
                ITasqR processor,
                IAppSession appSession,
                IMapper mapper,
                IAerishDbContext dbContext
            )
        {
            p_Processor = processor;
            p_AppSession = appSession;
            p_Mapper = mapper;
            p_DbContext = dbContext;
        }

        public override Task InitializeAsync(MainCalcCmd request, CancellationToken cancellationToken = default)
        {
            p_ProcessTracker = (IProcessTracker)request.ProcessTracker;

            return Task.CompletedTask;
        }

        public async override Task<IEnumerable> SelectionCriteriaAsync(MainCalcCmd request, CancellationToken cancellationToken = default)
        {
            int? personIDInParam = p_ProcessTracker.Parameters.GetAs<int?>("PersonID");

            if (personIDInParam.GetValueOrDefault() > 0)
            {
                return new[] { personIDInParam.GetValueOrDefault() };
            }

            return await p_DbContext.Employees
                .Where(a => a.ClientID == p_AppSession.ClientID)
                .Select(a => a.EmployeeID)
                .ToListAsync();
        }

        public async override Task<bool> RunAsync(int key, MainCalcCmd request, CancellationToken cancellationToken = default)
        {
            short planYear = p_ProcessTracker.PlanYear.GetValueOrDefault();
            short payPeriodID = p_ProcessTracker.PayRunID.GetValueOrDefault();

            bool isSuccess = false;

            try
            {
                p_PayPeriod = await p_Processor.RunAsync(new FindPayRunQr(planYear, payPeriodID));

                if (p_PayPeriod == null)
                {
                    throw new AerishException($"Invalid pay period ({planYear} - {payPeriodID}) for client: {p_AppSession.ClientID}");
                }

                p_OldMasterData = await p_Processor.RunAsync(new GetPreviousMasterDataQr(p_PayPeriod.PlanYear, p_PayPeriod.PayRunID, key));

                if (p_OldMasterData != null)
                {
                    p_NewMasterData = CopyToNewCalc(p_OldMasterData, p_PayPeriod);
                }
                else
                {
                    p_ProcessTracker.LogMessage("No existing records");

                    p_NewMasterData = new MasterDataBO
                    {
                        EmployeeID = key,
                        ClientID = p_AppSession.ClientID,
                        RecordStatus = RecordStatus.ModelledActive,
                    };
                }

                p_NewMasterData.ClearTracker();

                p_NewMasterData.PlanYear = p_PayPeriod.PlanYear;
                p_NewMasterData.PayRunID = p_PayPeriod.PayRunID;

                CalcLastCalcID();
                CalcBasicPay();
                CalcDaysFactor();
                CalcRates();

                ValidateParameters();

                CalcDeductions();
                CalcLoans();
                CalcEarnings();
                CalcTotalTaxableIncome();
                CalcTotalNonTaxableIncome();
                CalcNetTaxableIncome();
                CalcWitholdingTax();
                CalcTotalDeduction();
                CalcNetSalary();

                if (p_NewMasterData.HasChanges())
                {
                    if (p_OldMasterData != null)
                    {
                        MarkOldCalcAsFrozen(p_OldMasterData);
                    }

                    p_NewMasterData.RecordStatus = RecordStatus.Active;

                    var newMasterData = p_Mapper.Map<MasterDataBO, MasterEmployee>(p_NewMasterData);
                    p_DbContext.MasterEmployees.Add(newMasterData);

                    p_ProcessTracker.SaveContext = true;
                }
                else
                {
                    p_ProcessTracker.SaveContext = false;
                }

                isSuccess = true;
            }
            catch (Exception ex)
            {
                p_ProcessTracker.LogError(ex);

                isSuccess = false;
            }

            return isSuccess;
        }

        protected virtual void MarkOldCalcAsFrozen(MasterDataBO oldCalc)
        {
            var oldCalcData = p_DbContext.MasterEmployees
                .SingleOrDefault(a => a.ClientID == oldCalc.ClientID
                    && a.CalcID == oldCalc.CalcID
                    && a.EmployeeID == oldCalc.EmployeeID
                    && a.PlanYear == oldCalc.PlanYear
                    && a.PayRunID == oldCalc.PayRunID);

            if (oldCalcData != null)
            {
                oldCalcData.RecordStatus = RecordStatus.Frozen;
            }
        }

        protected virtual void ValidateParameters()
        {
            if (p_NewMasterData.MonthlyRate == null)
            {
                throw new ArgumentNullException(nameof(p_NewMasterData.MonthlyRate));
            }

            if (p_NewMasterData.DailyRate == null)
            {
                throw new ArgumentNullException(nameof(p_NewMasterData.DailyRate));
            }
        }

        protected virtual void CalcLastCalcID()
        {
            short calcID = 1;
            var lastCalc = p_DbContext.MasterEmployees
                .Where(a => a.ClientID == p_AppSession.ClientID
                    && a.EmployeeID == p_NewMasterData.EmployeeID
                    && a.PlanYear == p_PayPeriod.PlanYear
                    && a.PayRunID == p_PayPeriod.PayRunID)
                .OrderByDescending(a => a.CalcID)
                .FirstOrDefault();

            if (lastCalc != null)
            {
                calcID = (short)(lastCalc.CalcID + 1);
            }

            p_NewMasterData.CalcID = calcID;
        }

        protected virtual MasterDataBO CopyToNewCalc(MasterDataBO oldData, PayRunBO payPeriod)
        {
            string json = JsonSerializer.Serialize(oldData);
            var result = JsonSerializer.Deserialize<MasterDataBO>(json);

            result.PlanYear = payPeriod.PlanYear;
            result.PayRunID = payPeriod.PayRunID;

            result.MasterEmployeeDeductions.ToList()
                .ForEach(a =>
                {
                    a.MasterEmployeeDeductionID = 0;
                    a.PlanYear = payPeriod.PlanYear;
                    a.PayRunID = payPeriod.PayRunID;
                });

            result.MasterEmployeeEarnings.ToList()
                .ForEach(a =>
                {
                    a.MasterEmployeeEarningID = 0;
                    a.PlanYear = payPeriod.PlanYear;
                    a.PayRunID = payPeriod.PayRunID;
                });

            return result;
        }

        #region BasicPay
        protected virtual void CalcBasicPay()
        {
            var basicPayEarnRef = p_Processor.Run(new GetEarningQr(EarningCodeConstants.BasicPay));
            var handlerProvider = basicPayEarnRef.TaskHandlerProvider;

            var basicPayInstance = JobInstanceHelper.NewInstance<ITasq>
                    (
                        handlerProvider.TaskAssembly,
                        handlerProvider.TaskClass,
                        p_ProcessTracker,
                        p_OldMasterData,
                        p_NewMasterData,
                        basicPayEarnRef
                    );

            if (!handlerProvider.IsDefaultHandler)
            {
                var assembly = Assembly.Load(assemblyString: handlerProvider.HandlerAssembly);
                var type = assembly.GetType(name: handlerProvider.HandlerClass);

                p_Processor.UsingAsHandler(type)
                    .Run(basicPayInstance);
            }
            else
            {
                p_Processor.Run(basicPayInstance);
            }
        }
        #endregion

        protected virtual void CalcDaysFactor()
        {
            p_Processor.Run(new CalcDaysFactorCmd(p_ProcessTracker, p_OldMasterData, p_NewMasterData));
        }

        protected virtual void CalcRates()
        {
            p_Processor.Run(new CalcRatesCmd(p_ProcessTracker, p_OldMasterData, p_NewMasterData));
        }


        #region Deductions
        protected virtual void CalcDeductions()
        {
            var deductions = p_Processor.Run(new GetDeductionListQr());

            foreach (var deduction in deductions)
            {
                try
                {
                    var handlerProvider = deduction.TaskHandlerProvider;
                    var instance = JobInstanceHelper.NewInstance<ITasq>
                        (
                            handlerProvider.TaskAssembly,
                            handlerProvider.TaskClass,
                            p_ProcessTracker,
                            p_OldMasterData,
                            p_NewMasterData,
                            deduction
                        );

                    if (handlerProvider.IsDefaultHandler)
                    {
                        p_Processor.Run(instance);
                    }
                    else
                    {
                        var assembly = Assembly.Load(assemblyString: handlerProvider.HandlerAssembly);
                        var type = assembly.GetType(name: handlerProvider.HandlerClass);

                        p_Processor.UsingAsHandler(type)
                            .Run(instance);
                    }
                }
                catch (Exception ex)
                {
                    p_ProcessTracker.LogError(ex);
                }
            }
        }
        #endregion

        #region Loans
        protected virtual void CalcLoans()
        {
            var loans = p_Processor.Run(new GetLoanListQr());

            foreach (var loan in loans)
            {
                try
                {
                    var handlerProvider = loan.TaskHandlerProvider;
                    var instance = JobInstanceHelper.NewInstance<ITasq>
                        (
                            handlerProvider.TaskAssembly,
                            handlerProvider.TaskClass,
                            p_ProcessTracker,
                            p_OldMasterData,
                            p_NewMasterData,
                            loan
                        );

                    if (handlerProvider.IsDefaultHandler)
                    {
                        p_Processor.Run(instance);
                    }
                    else
                    {
                        var assembly = Assembly.Load(assemblyString: handlerProvider.HandlerAssembly);
                        var type = assembly.GetType(name: handlerProvider.HandlerClass);

                        p_Processor.UsingAsHandler(type)
                            .Run(instance);
                    }
                }
                catch (Exception ex)
                {
                    p_ProcessTracker.LogError(ex);
                }
            }
        }
        #endregion


        #region Earnings
        protected virtual void CalcEarnings()
        {
            var earnings = p_Processor.Run(new GetEarningListQr());
            var basicPayEarning = p_Processor.Run(new GetEarningQr(EarningCodeConstants.BasicPay));

            foreach (var earning in earnings)
            {
                try
                {
                    if (earning.EarningID == basicPayEarning.EarningID)
                    {
                        continue;
                    }

                    var handlerProvider = earning.TaskHandlerProvider;

                    var instance = JobInstanceHelper.NewInstance<ITasq>
                        (
                            handlerProvider.TaskAssembly,
                            handlerProvider.TaskClass,
                            p_ProcessTracker,
                            p_OldMasterData,
                            p_NewMasterData,
                            earning
                        );

                    if (handlerProvider.IsDefaultHandler)
                    {
                        p_Processor.Run(instance);
                    }
                    else
                    {
                        var assembly = Assembly.Load(assemblyString: handlerProvider.HandlerAssembly);
                        var type = assembly.GetType(name: handlerProvider.HandlerClass);

                        p_Processor.UsingAsHandler(type).Run(instance);
                    }
                }
                catch (Exception ex)
                {
                    p_ProcessTracker.LogError(ex);
                }
            }
        }
        #endregion

        protected virtual void CalcTotalTaxableIncome()
        {
            decimal totalEarnings = p_NewMasterData.MasterEmployeeEarnings
                .Where(a => a.RecordStatus == RecordStatus.Active && a.IsTaxable)
                .Sum(a => a.Amount);

            p_NewMasterData.TotalTaxableIncome = totalEarnings;
        }

        protected virtual void CalcTotalNonTaxableIncome()
        {
            decimal totalNonTaxIncome = p_NewMasterData.MasterEmployeeEarnings
                   .Where(a => a.RecordStatus == RecordStatus.Active && !a.IsTaxable)
                   .Sum(a => a.Amount);

            p_NewMasterData.TotalNonTaxableIncome = totalNonTaxIncome;

        }

        protected virtual void CalcNetTaxableIncome()
        {
            var excludedTaxDeductions = p_Processor.Run(new GetDeductionListQr())
                .Where(a => a.IsExcludedInTax)
                .Select(a => a.DeductionID)
                .ToList();

            decimal netTaxableEarnings = p_NewMasterData.TotalTaxableIncome.GetValueOrDefault();

            foreach (var empDeduction in p_NewMasterData.MasterEmployeeDeductions
                .Where(a => a.RecordStatus == RecordStatus.Active))
            {
                if (excludedTaxDeductions.Contains(empDeduction.DeductionID))
                {
                    netTaxableEarnings -= empDeduction.EmployeeAmount;
                }
            }

            p_NewMasterData.NetTaxableIncome = netTaxableEarnings;
        }

        protected virtual void CalcWitholdingTax()
        {
            decimal netTaxableIncome = p_NewMasterData.NetTaxableIncome.GetValueOrDefault();
            var taxTable = p_Processor.Run(new GetTaxTableQr(p_PayPeriod.PlanYear, p_PayPeriod.PayRunID));
            var taxRange = taxTable.Ranges.Single(a => a.AmountBasis == p_NewMasterData.BasicPayBasis.Value
                    && a.Min < netTaxableIncome && netTaxableIncome < a.Max);

            decimal limitExemption = taxRange.Min;
            decimal finalTaxIncome = netTaxableIncome - limitExemption;
            decimal tax = finalTaxIncome * taxRange.Rate.GetValueOrDefault();
            decimal wtax = tax + taxRange.Fixed.GetValueOrDefault();

            p_NewMasterData.WitholdingTax = wtax;
        }

        protected virtual void CalcTotalDeduction()
        {
            decimal? totalDeductions = 0;
            decimal? wtax = p_NewMasterData.WitholdingTax.GetValueOrDefault();

            foreach (var empDeduction in p_NewMasterData.MasterEmployeeDeductions
                .Where(a => a.RecordStatus == RecordStatus.Active))
            {
                totalDeductions += empDeduction.EmployeeAmount;
            }

            totalDeductions += wtax;

            foreach (var empLoan in p_NewMasterData.MasterEmployeeLoans
                .Where(a => a.RecordStatus == RecordStatus.Active))
            {
                totalDeductions += empLoan.Amount;
            }

            p_NewMasterData.TotalDeduction = totalDeductions;

        }

        protected virtual void CalcNetSalary()
        {
            decimal allEarnings = p_NewMasterData.MasterEmployeeEarnings
                .Where(a => a.RecordStatus == RecordStatus.Active)
                .Sum(a => a.Amount);

            decimal totalDeductions = p_NewMasterData.TotalDeduction.GetValueOrDefault();

            p_NewMasterData.NetSalary = allEarnings - totalDeductions;

        }

    }
}