using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Domain.Common.Keys;
using Aerish.Domain.Entities.Common;

namespace Aerish.Domain.Entities.Parameters
{
    public class EmployeeEarningRef : EmployeeKey
    {
        public int EmployeeEarningRefID { get; set; }
        public short EarningID { get; set; }

        public string OvrdShortDesc { get; set; }
        public string OvrdLongDesc { get; set; }
        public string OvrdAltDesc { get; set; }

        public bool IsEnabled { get; set; }

        public Earning N_Earning { get; set; }
        public Employee N_Employee { get; set; }

        public ICollection<EmployeeEarning> N_EmployeeEarnings { get; set; } = new HashSet<EmployeeEarning>();
    }
}
