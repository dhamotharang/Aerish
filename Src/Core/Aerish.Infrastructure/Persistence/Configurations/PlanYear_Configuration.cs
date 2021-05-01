using Aerish.Constants;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

using System;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class PlanYear_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<PlanYear> builder)
        {
            builder.HasKey(a => a.Year);
        }

        protected override void SeedData(BaseSeeder<PlanYear> builder)
        {
            builder.HasData(new PlanYear
            {
                Year = 2020,
                EffectivityStart = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                EffectivityEnd = new DateTime(2020 + 1, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(-1),
                IsActive = true
            });

            builder.HasData(new PlanYear
            {
                Year = 2021,
                EffectivityStart = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                EffectivityEnd = new DateTime(2021 + 1, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(-1),
                IsActive = false
            });
        }
    }
}