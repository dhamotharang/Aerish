using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Constants;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.DeductionQrs;

using TasqR;

namespace Aerish.Application.Queries.DeductionQrs
{
   

    public class GetDeductionQrHandler : TasqHandler<GetDeductionQr, DeductionBO>
    {
        private readonly ITasqR p_Processor;

        public GetDeductionQrHandler
            (
                ITasqR processor
            )
        {
            p_Processor = processor;
        }

        public override DeductionBO Run(GetDeductionQr process)
        {
            var deductions = p_Processor.Run(new GetDeductionListQr(process.ClientSpecific));

            var deduction = deductions.Where(a => a.Code == process.DeductionCode);

            if (deduction.Count() > 1)
            {
                throw new AerishMultipleObjectFoundException<DeductionBO>(process.DeductionCode);
            }

            if (deduction.Count() == 0)
            {
                throw new AerishObjectNotFoundException<DeductionBO>(process.DeductionCode);
            }

            return deduction.Single();
        }
    }
}