using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Models;
using Aerish.Queries.LoanQrs;

using TasqR;

namespace Aerish.Application.Queries.LoanQrs
{
    public class GetLoanQrHandler : TasqHandler<GetLoanQr, LoanBO>
    {
        private readonly ITasqR p_Processor;

        public GetLoanQrHandler
            (
                ITasqR processor
            )
        {
            p_Processor = processor;
        }

        public override LoanBO Run(GetLoanQr request)
        {
            var loans = p_Processor.Run(new GetLoanListQr(request.ClientSpecific));

            var loan = loans.Where(a => a.Code == request.LoanCode);

            if (loan.Count() > 1)
            {
                throw new AerishMultipleObjectFoundException<Loan>(request.LoanCode);
            }

            if (loan.Count() == 0)
            {
                throw new AerishObjectNotFoundException<Loan>(request.LoanCode);
            }

            return loan.Single();
        }
    }
}