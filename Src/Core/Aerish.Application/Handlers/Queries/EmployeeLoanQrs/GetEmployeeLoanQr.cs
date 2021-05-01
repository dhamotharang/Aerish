using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Application.Queries.LoanQrs;
using Aerish.Domain.Entities.Parameters;
using Aerish.Interfaces;
using Aerish.Queries.LoanQrs;

using Microsoft.EntityFrameworkCore;
using TasqR;

namespace Aerish.Application.Queries.EmployeeLoanQrs
{
    public class GetEmployeeLoanQr : ITasq<EmployeeLoan>
    {
        private readonly short p_PlanYear;
        private readonly short p_PayRunID;
        private readonly int p_EmployeeID;
        private readonly string p_LoanCode;

        public GetEmployeeLoanQr(short planYear, short payRunID, int employeeID, string loanCode)
        {
            p_PlanYear = planYear;
            p_PayRunID = payRunID;
            p_EmployeeID = employeeID;
            p_LoanCode = loanCode;
        }

        public class GetEmployeeLoanQrHandler : TasqHandler<GetEmployeeLoanQr, EmployeeLoan>
        {
            private readonly ITasqR p_Processor;
            private readonly IAerishDbContext p_DbContext;

            public GetEmployeeLoanQrHandler
                (
                    ITasqR processor,
                    IAerishDbContext dbContext
                )
            {
                p_Processor = processor;
                p_DbContext = dbContext;
            }

            public override EmployeeLoan Run(GetEmployeeLoanQr process)
            {
                var loan = p_Processor.Run(new GetLoanQr(process.p_LoanCode));

                var empLoan = p_DbContext.EmployeeLoans
                    .Include(a => a.N_EmployeeLoanRef)
                    .Where(a => a.EmployeeID == process.p_EmployeeID 
                        && a.LoanID == loan.LoanID 
                        && a.PlanYear == process.p_PlanYear
                        && a.PayRunID == process.p_PayRunID);

                if (empLoan.Count() > 1)
                {
                    throw new AerishMultipleObjectFoundException<EmployeeLoan>(process.p_LoanCode);
                }

                return empLoan.SingleOrDefault();
            }
        }
    }
}
