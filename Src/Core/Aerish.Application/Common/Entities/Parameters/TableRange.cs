using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Domain.Entities.Parameters
{
    public class TableRange
    {
        public short TableID { get; set; }
        public string Code { get; set; }
        public short TableRangeID { get; set; }
        public AmountBasis AmountBasis { get; set; }

        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Fixed { get; set; }

        public decimal? Custom1 { get; set; }
        public decimal? Custom2 { get; set; }
        public decimal? Custom3 { get; set; }
        public decimal? Custom4 { get; set; }
        public decimal? Custom5 { get; set; }

        public string EmployeeFormula { get; set; }
        public string EmployerFormula { get; set; }
    }
}