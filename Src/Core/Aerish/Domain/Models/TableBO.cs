using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class TableBO
    {
        public short TableID { get; set; }
        public string Code { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }

        public string Reference { get; set; }

        public DateTime EffectiveStartOn { get; set; }
        public DateTime? EffectiveEndOn { get; set; }

        public IEnumerable<TableRangeBO> Ranges { get; set; } = new List<TableRangeBO>();
    }
}
