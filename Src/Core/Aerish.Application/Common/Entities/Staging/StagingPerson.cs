using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aerish.Domain.Common;

namespace Aerish.Domain.Entities.Staging
{
    public class StagingPerson : BaseStagingEntity
    {
        public string EmployeeSysID { get; set; }

        public string TaxIdNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }

        public string Gender { get; set; }
    }
}
