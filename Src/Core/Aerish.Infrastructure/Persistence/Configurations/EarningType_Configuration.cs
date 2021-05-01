using Aerish.Constants;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class EarningType_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<EarningType> builder)
        {
            builder.HasKey(a => a.EarningTypeID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<EarningType> builder)
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

        protected override void SeedData(BaseSeeder<EarningType> builder)
        {
            builder.HasData(new EarningType
            {
                EarningTypeID = 1,
                ShortDesc = "Basic Pay",
                LongDesc = "Basic Pay"
            });

            builder.HasData(new EarningType
            {
                EarningTypeID = 2,
                ShortDesc = "Allowance",
                LongDesc = "Allowance"
            });

            builder.HasData(new EarningType
            {
                EarningTypeID = 3,
                ShortDesc = "Absence",
                LongDesc = "Absence"
            });
        }
    }
}
