using Aerish.Domain.Common.Keys;
using Aerish.Domain.Entities.Parameters;
using System;
using System.Collections.Generic;

namespace Aerish.Domain.Entities.Common
{
    public class Employee : EmployeeKey
    {
        public string EmployeeSysID { get; set; }

        public Client N_Client { get; set; }
        public Person N_Person { get; set; }
        public ICollection<BasicPay> N_BasicPays { get; private set; } = new HashSet<BasicPay>();
    }
}
