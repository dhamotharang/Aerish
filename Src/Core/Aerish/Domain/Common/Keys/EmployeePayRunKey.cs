using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Domain.Common.Keys
{
    public abstract class EmployeePayRunKey : EmployeeKey
    {
        public short PlanYear { get; set; }
        public short PayRunID { get; set; }

    }
}
