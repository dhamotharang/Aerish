using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.TableQrs
{
    public class GetTaxTableQr : ITasq<TableBO>
    {

        public GetTaxTableQr(short planYear, short payRunID)
        {
            PlanYear = planYear;
            PayRunID = payRunID;
        }

        public short PlanYear { get; }
        public short PayRunID { get; }
    }
}
