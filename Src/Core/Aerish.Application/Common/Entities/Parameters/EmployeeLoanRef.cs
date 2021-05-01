using System;
using System.Collections.Generic;
using Aerish.Domain.Common.Keys;
using Aerish.Domain.Entities.Common;

namespace Aerish.Domain.Entities.Parameters
{
    public class EmployeeLoanRef : EmployeeKey
    {
        public int EmployeeLoanRefID { get; set; }
        public short LoanID { get; set; }

        public string OvrdShortDesc { get; set; }
        public string OvrdLongDesc { get; set; }
        public string OvrdAltDesc { get; set; }


        public DateTime? GrantedOn { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal Interest { get; set; }

        public decimal TotalLoan { get => PrincipalAmount + Interest; }


        public Loan N_Loan { get; set; }
        public Employee N_Employee { get; set; }

        public ICollection<EmployeeLoan> N_EmployeeLoans { get; set; } = new HashSet<EmployeeLoan>();
    }
}
