using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class TableRangeBO
    {
        public short TableID { get; set; }
        public string Code { get; set; }
        public short TableRangeID { get; set; }
        public AmountBasis AmountBasis { get; set; }

        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Fixed { get; set; }

        public string EmployeeFormula { get; set; }
        public string EmployerFormula { get; set; }
    }
}
