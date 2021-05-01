using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class MasterEmployeeDeductionBO
    {
        public int MasterEmployeeDeductionID { get; set; }
        public short DeductionID { get; set; }

        public short PlanYear { get; set; }
        public short PayRunID { get; set; }

        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }


        public decimal EmployeeAmount { get; set; }
        public decimal EmployerAmount { get; set; }

        public RecordStatus RecordStatus { get; set; }
    }
}
