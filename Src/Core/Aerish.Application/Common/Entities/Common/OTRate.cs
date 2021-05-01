using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Domain.Entities.Common
{
    public class OTRate
    {
        public short OTRateID { get; set; }
        public short OTRateTypeID { get; set; }

        public decimal Rate { get; set; }
        public ComputedBy? ComputedBy { get; set; }


        public OTRateType N_OTRateType { get; set; }
    }
}