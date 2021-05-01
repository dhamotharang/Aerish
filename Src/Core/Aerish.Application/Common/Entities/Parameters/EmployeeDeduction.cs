using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Domain.Common.Keys;
using Aerish.Domain.Entities.Common;

namespace Aerish.Domain.Entities.Parameters
{
    public class EmployeeDeduction : EmployeePayRunKey
    {
        public int EmployeeDeductionID { get; set; }
        public int EmployeeDeductionRefID { get; set; }
        public short DeductionID { get; set; }

        public decimal Amount { get; set; }
    }
}
