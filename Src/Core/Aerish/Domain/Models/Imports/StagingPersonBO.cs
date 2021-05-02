using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class StagingPersonBO : BaseStagingBO
    {
        public long ID { get; set; }

        public string EmployeeSysID { get; set; }

        public string TaxIdNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }

        public string Gender { get; set; }
    }
}
