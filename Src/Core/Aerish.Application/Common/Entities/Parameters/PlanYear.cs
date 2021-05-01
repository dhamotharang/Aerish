using System;

namespace Aerish.Domain.Entities.Parameters
{
    public class PlanYear
    {
        public short Year { get; set; }

        public DateTime EffectivityStart { get; set; }
        public DateTime EffectivityEnd { get; set; }

        public bool IsActive { get; set; }
    }
}
