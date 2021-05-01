using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Domain.Common.Keys;
using Aerish.Domain.Entities.Common;

namespace Aerish.Domain.Entities.Parameters
{
    public class EmployeeDeductionRef : EmployeeKey
    {
        public int EmployeeDeductionRefID { get; set; }

        public short DeductionID { get; set; }

        public string OvrdShortDesc { get; set; }
        public string OvrdLongDesc { get; set; }
        public string OvrdAltDesc { get; set; }

        public bool IsEnabled { get; set; }


        public Deduction N_Deduction { get; set; }
        public Employee N_Employee { get; set; }

        public ICollection<EmployeeDeduction> N_EmployeeDeductions { get; set; } = new HashSet<EmployeeDeduction>();
    }
}
