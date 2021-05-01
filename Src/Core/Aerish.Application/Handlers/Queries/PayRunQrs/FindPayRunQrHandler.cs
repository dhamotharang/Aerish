using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Models;
using Aerish.Queries.PayRunQrs;

using TasqR;

namespace Aerish.Application.Handlers.Queries.PayRunQrs
{
    public class FindPayRunQrHandler : TasqHandler<FindPayRunQr, PayRunBO>
    {
        private readonly ITasqR p_TasqR;

        public FindPayRunQrHandler(ITasqR tasqR)
        {
            p_TasqR = tasqR;
        }

        public override PayRunBO Run(FindPayRunQr request)
        {
            var payRuns = p_TasqR.Run(new GetPayRunQr(request.PlanYear));

            return payRuns.Data
                .SingleOrDefault(a => a.PayRunID == request.PayRunID);
        }
    }
}