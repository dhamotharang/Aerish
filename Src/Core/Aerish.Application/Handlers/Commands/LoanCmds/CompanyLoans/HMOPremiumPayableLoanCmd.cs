using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Application.Common.Models;
using Aerish.Application.Queries.EmployeeLoanQrs;
using Aerish.Application.Queries.LoanQrs;
using Aerish.Commands.LoanCmds.CompanyLoans;
using Aerish.Common.Models;
using Aerish.Constants;
using Aerish.Domain.Entities.CalcData;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Models;
using Aerish.Queries.LoanQrs;

using TasqR;

namespace Aerish.Application.Commands.LoanCmds.CompanyLoans
{

    public class HMOPremiumPayableLoanCmdHandler : TasqHandler<HMOPremiumPayableLoanCmd>
    {
        private readonly ITasqR p_Processor;

        public HMOPremiumPayableLoanCmdHandler
            (
                ITasqR processor
            )
        {
            p_Processor = processor;
        }

        public override void Run(HMOPremiumPayableLoanCmd request)
        {
            short planYear = request.m_NewMasterData.PlanYear;
            short payPeriodID = request.m_NewMasterData.PayRunID;
            var loan = p_Processor.Run(new GetLoanQr(LoanCodeConstants.HMOPremiumPayable));

            var existingLoan = FindExistingLoan(request.m_NewMasterData, request.Loan);
            var employeeLoan = p_Processor.Run(new GetEmployeeLoanQr
                (
                    planYear,
                    payPeriodID,
                    request.m_NewMasterData.EmployeeID,
                    LoanCodeConstants.HMOPremiumPayable
                ));

            MasterEmployeeLoanBO newComputedLoan = null;

            if (employeeLoan != null)
            {
                newComputedLoan = new MasterEmployeeLoanBO
                {
                    LoanID = loan.LoanID,
                    RecordStatus = RecordStatus.Active,
                    ShortDesc = employeeLoan.N_EmployeeLoanRef.OvrdShortDesc ?? loan.ShortDesc,
                    LongDesc = employeeLoan.N_EmployeeLoanRef.OvrdLongDesc ?? loan.LongDesc,
                    AltDesc = employeeLoan.N_EmployeeLoanRef.OvrdAltDesc ?? loan.AltDesc,
                    Amount = employeeLoan.Amount
                };
            }

            if (HasChanges(existingLoan, newComputedLoan))
            {
                request.m_NewMasterData.AddNewEmployeeLoan(newComputedLoan);
            }

        }

        protected virtual MasterEmployeeLoanBO FindExistingLoan(MasterDataBO newMasterData, LoanBO loanReference)
        {
            return newMasterData.MasterEmployeeLoans
                .SingleOrDefault(a => a.LoanID == loanReference.LoanID);

        }

        protected virtual bool HasChanges(MasterEmployeeLoanBO prev, MasterEmployeeLoanBO next)
        {
            if (prev == null || (prev != null && next == null))
            {
                return true;
            }

            if (prev.Amount != next.Amount)
            {
                return true;
            }

            return false;
        }
    }

}