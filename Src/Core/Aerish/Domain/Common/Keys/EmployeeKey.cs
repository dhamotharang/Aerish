using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Domain.Common.Keys
{
    public abstract class EmployeeKey
    {
        public int EmployeeID { get; set; }
        public short ClientID { get; set; }
    }
}
