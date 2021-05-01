using Aerish.Application.Common.Helpers;
using Aerish.Application.Common.Models;
using Aerish.Application.Queries.DeductionQrs;
using Aerish.Application.Queries.TableQrs;
using Aerish.Constants;
using Aerish.Domain.Common;
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
using Aerish.Queries.DeductionQrs;
using Aerish.Domain.Models;
using Aerish.Queries.TableQrs;

namespace Aerish.Application.Commands.DeductionCmds.Contributions
{

        public class SSSContributionDeductionCmdHandler : TasqHandler<ContributionDeductionCmd>
        {
            private readonly IAppSession p_AppSession;
            private readonly ITasqR p_Processor;

            public SSSContributionDeductionCmdHandler
                (
                    IAppSession appSession,
                    ITasqR processor
                )
            {
                p_AppSession = appSession;
                p_Processor = processor;
            }

        public override void Run(ContributionDeductionCmd request)
        {
            short planYear = request.m_NewMasterData.PlanYear;
            short payPeriodID = request.m_NewMasterData.PayRunID;

            var ded = p_Processor.Run(new GetDeductionQr(DeductionCodeConstants.SSS));

            var existingSSSDed = request.m_NewMasterData.MasterEmployeeDeductions
                .SingleOrDefault(a => a.DeductionID == ded.DeductionID);


            var cmd = new GetSSSTableQr(request.m_NewMasterData.PlanYear, request.m_NewMasterData.PayRunID);
            var sssTable = p_Processor.Run(cmd);
            var range = sssTable.Ranges
                .SingleOrDefault(a => a.Min < request.m_NewMasterData.MonthlyRate && request.m_NewMasterData.MonthlyRate < a.Max);

            var variables = new Dictionary<string, decimal>();

            variables["Fixed"] = range.Fixed.GetValueOrDefault();
            variables["MonthlyBasicPay"] = request.m_NewMasterData.MonthlyRate.GetValueOrDefault();
            variables["Rate"] = range.Rate.GetValueOrDefault();

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

            if (HasChanges(existingSSSDed, newComputedDeduction))
            {
                request.m_NewMasterData.AddNewEmployeeDeduction(newComputedDeduction);
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