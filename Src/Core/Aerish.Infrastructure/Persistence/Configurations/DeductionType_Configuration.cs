using Aerish.Constants;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class DeductionType_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<DeductionType> builder)
        {
            builder.HasKey(a => a.DeductionTypeID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<DeductionType> builder)
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

        protected override void SeedData(BaseSeeder<DeductionType> builder)
        {
            builder.HasData(new DeductionType
            {
                DeductionTypeID = 1,
                ShortDesc = "Normal",
                LongDesc = "Normal"
            });

            builder.HasData(new DeductionType
            {
                DeductionTypeID = 2,
                ShortDesc = "Contribution",
                LongDesc = "Contribution"
            });
        }
    }
}
