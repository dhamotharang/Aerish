using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.TableQrs
{
    public class GetPhilHealthTableQr : ITasq<TableBO>
    {

        public GetPhilHealthTableQr(short planYear, short payRunID)
        {
            PlanYear = planYear;
            PayRunID = payRunID;
        }

        public short PlanYear { get; }
        public short PayRunID { get; }
    }

}
