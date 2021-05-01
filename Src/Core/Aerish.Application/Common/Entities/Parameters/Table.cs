using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Domain.Entities.Parameters
{
    public class Table
    {
        public short TableID { get; set; }
        public string Code { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }

        public string Reference { get; set; }

        public DateTime EffectiveStartOn { get; set; }
        public DateTime? EffectiveEndOn { get; set; }

        public ICollection<TableRange> N_Ranges { get; private set; } = new HashSet<TableRange>();
    }
}
