using Aerish.Domain.Common.Keys;
using Aerish.Domain.Entities.Common;
using System;

namespace Aerish.Domain.Entities.Parameters
{
    public class EmployeeEarning : EmployeePayRunKey
    {
        public int EmployeeEarningID { get; set; }
        public short EarningID { get; set; }
        public int EmployeeEarningRefID { get; set; }

        public decimal Amount { get; set; }
    }
}