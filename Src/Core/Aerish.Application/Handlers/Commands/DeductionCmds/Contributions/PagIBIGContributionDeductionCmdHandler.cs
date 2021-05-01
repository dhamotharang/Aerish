using Aerish.Application.Common.Models;
using Aerish.Application.Queries.DeductionQrs;
using Aerish.Constants;
using Aerish.Domain.Entities.CalcData;
using Aerish.Interfaces;
using FluentValidation;
using TasqR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aerish.Commands.Base;
using Aerish.Common.Models;
using Aerish.Commands.DeductionCmds.Contributions;
using Aerish.Queries.DeductionQrs;
using Aerish.Domain.Models;

namespace Aerish.Application.Commands.DeductionCmds.Contributions
{
    public class PagIBIGContributionDeductionCmdHandler : BaseContributionDeductionCmdHandler
    {
        private readonly ITasqR p_Processor;
        private readonly IAppSession p_AppSession;

        public PagIBIGContributionDeductionCmdHandler(ITasqR processor, IAppSession appSession)
        {
            p_Processor = processor;
            p_AppSession = appSession;
        }

        public override void Run(ContributionDeductionCmd request)
        {
            var ded = p_Processor.Run(new GetDeductionQr(DeductionCodeConstants.PagIBIG));

            var existingDeduction = request.m_NewMasterData.MasterEmployeeDeductions
                .SingleOrDefault(a => a.DeductionID == ded.DeductionID);

            var newComputedDeduction = new MasterEmployeeDeductionBO
            {
                DeductionID = ded.DeductionID,
                RecordStatus = RecordStatus.Active,
                EmployeeAmount = 100,
                ShortDesc = ded.ShortDesc,
                LongDesc = ded.LongDesc,
                AltDesc = ded.AltDesc
            };

            if (HasChanges(existingDeduction, newComputedDeduction))
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