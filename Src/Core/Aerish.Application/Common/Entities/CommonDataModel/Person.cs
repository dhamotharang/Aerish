using System;

namespace Aerish.Domain.Entities.Common
{
    public class Person
    {
        public int PersonID { get; set; }

        public string EmployeeSysID { get; set; }

        public string TaxIdNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public Gender? Gender { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}
