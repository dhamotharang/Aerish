using Aerish.Application.Common.Helpers;
using Aerish.Application.Common.Models;
using Aerish.Application.Queries.DeductionQrs;
using Aerish.Application.Queries.TableQrs;
using Aerish.Constants;
using Aerish.Domain.Entities.CalcData;
using Aerish.Interfaces;
using FluentValidation;
using TasqR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aerish.Commands.DeductionCmds.Contributions;
using Aerish.Domain.Models;
using Aerish.Queries.DeductionQrs;
using Aerish.Queries.TableQrs;

namespace Aerish.Application.Commands.DeductionCmds.Contributions
{

    public class PhilHealthContributionDeductionCmdHandler : BaseContributionDeductionCmdHandler
    {
        private readonly IAppSession p_AppSession;
        private readonly ITasqR p_Processor;

        public PhilHealthContributionDeductionCmdHandler
            (
                IAppSession appSession,
                ITasqR processor
            )
        {
            p_AppSession = appSession;
            p_Processor = processor;
        }

        public override void Run(ContributionDeductionCmd process)
        {
            short planYear = process.m_NewMasterData.PlanYear;
            short payRunID = process.m_NewMasterData.PayRunID;

            var ded = p_Processor.Run(new GetDeductionQr(DeductionCodeConstants.PhilHealth));

            var existingPhilHealthDed = process.m_NewMasterData.MasterEmployeeDeductions
                .SingleOrDefault(a => a.DeductionID == ded.DeductionID);

            var philHealthTable = p_Processor.Run(new GetPhilHealthTableQr(planYear, payRunID));
            var range = philHealthTable.Ranges
                .SingleOrDefault(a => a.Min < process.m_NewMasterData.MonthlyRate && process.m_NewMasterData.MonthlyRate < a.Max);



            var variables = new Dictionary<string, decimal>
            {
                ["Fixed"] = range.Fixed.GetValueOrDefault(),
                ["MonthlyBasicPay"] = process.m_NewMasterData.MonthlyRate.GetValueOrDefault(),
                ["Rate"] = range.Rate.GetValueOrDefault()
            };

            var newComputedDeduction = new MasterEmployeeDeductionBO
            {
                DeductionID = ded.DeductionID,
                RecordStatus = RecordStatus.Active,
                EmployeeAmount = FormulaHelper.Calculate(range.EmployeeFormula, variables),
                EmployerAmount = FormulaHelper.Calculate(range.EmployerFormula, variables),
                ShortDesc = ded.ShortDesc,
                LongDesc = ded.LongDesc,
                AltDesc = ded.AltDesc
            };

            if (HasChanges(existingPhilHealthDed, newComputedDeduction))
            {
                process.m_NewMasterData.AddNewEmployeeDeduction(newComputedDeduction);
            }
        }

        protected virtual bool HasChanges(MasterEmployeeDeductionBO previousDeduction, MasterEmployeeDeductionBO newComputed)
        {
            if (previousDeduction == null)
            {
                return true;
            }

            if (previousDeduction.EmployeeAmount != newComputed.EmployeeAmount
                || previousDeduction.EmployerAmount != newComputed.EmployerAmount)
            {
                return true;
            }

            return false;
        }
    }

}