using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Admin.Shared
{
    public class EmployeeSummaryVM
    {
        public int PersonID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }
    }
}
