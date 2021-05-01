using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Domain.Common.Keys;
using Aerish.Domain.Entities.Common;

namespace Aerish.Domain.Entities.Parameters
{
    public class EmployeeLoan : EmployeePayRunKey
    {
        public int EmployeeLoanID { get; set; }
        public short LoanID { get; set; }
        public int EmployeeLoanRefID { get; set; }

        public decimal Amount { get; set; }

        public EmployeeLoanRef N_EmployeeLoanRef { get; set; }
    }
}
