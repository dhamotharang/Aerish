using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.BasicPayQrs
{
    public class GetBasicPayQr : ITasq<BasicPayBO>
    {

        public GetBasicPayQr(int employeeID, short planYear, short payPeriodID)
        {
            EmployeeID = employeeID;
            PlanYear = planYear;
            PayPeriodID = payPeriodID;
        }

        public int EmployeeID { get; }
        public short PlanYear { get; }
        public short PayPeriodID { get; }
    }
}
