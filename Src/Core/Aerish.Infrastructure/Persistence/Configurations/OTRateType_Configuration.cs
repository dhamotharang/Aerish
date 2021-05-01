using Aerish.Constants;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class OTRateType_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<OTRateType> builder)
        {
            builder.HasKey(a => a.OTRateTypeID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<OTRateType> builder)
        {
            builder.Property(p => p.ShortDesc)
                .IsRequired()
                .HasMaxLength(StringLengthConstant.ShortDesc);

            builder.Property(p => p.LongDesc)
               .IsRequired()
               .HasMaxLength(StringLengthConstant.LongDesc);

            builder.Property(p => p.AltDesc)
               .HasMaxLength(StringLengthConstant.AltDesc);
        }

        protected override void SeedData(BaseSeeder<OTRateType> builder)
        {
            builder.HasData(new OTRateType
            {
                OTRateTypeID = 1,
                ShortDesc = "Night Differential",
                LongDesc = "Night Differential"
            });
        }
    }
}
