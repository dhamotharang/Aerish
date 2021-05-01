using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Common.Models;

using TasqR;

namespace Aerish.Queries.MasterDataQrs
{
    public class GetPreviousMasterDataQr : ITasq<MasterDataBO>
    {
        public GetPreviousMasterDataQr(short planYear, short payPeriodID, int employeeID)
        {
            PlanYear = planYear;
            PayPeriodID = payPeriodID;
            EmployeeID = employeeID;
        }

        public short PlanYear { get; }
        public short PayPeriodID { get; }
        public int EmployeeID { get; }
    }
}
