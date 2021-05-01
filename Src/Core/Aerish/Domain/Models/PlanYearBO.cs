using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class PlanYearBO
    {
        public short Year { get; set; }

        public DateTime EffectivityStart { get; set; }
        public DateTime EffectivityEnd { get; set; }

        public bool IsActive { get; set; }
    }
}
