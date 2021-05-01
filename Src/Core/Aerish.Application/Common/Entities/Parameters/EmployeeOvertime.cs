using Aerish.Domain.Common.Keys;
using Aerish.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Domain.Entities.Parameters
{
    public class EmployeeOvertime : EmployeePayRunKey
    {
        public int EmployeeOvertimeID { get; set; }
        public short OTRateID { get; set; }

        public decimal Hours { get; set; }

        public PayRun N_PayRun { get; set; }
        public OTRate N_OTRate { get; set; }
        public Employee N_Employee { get; set; }
    }
}
