using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.PayRunQrs
{
    public class FindPayRunQr : ITasq<PayRunBO>
    {
        public FindPayRunQr(short planYear, short payRunID)
        {
            PlanYear = planYear;
            PayRunID = payRunID;
        }

        public short PlanYear { get; }
        public short PayRunID { get; }
    }
}
