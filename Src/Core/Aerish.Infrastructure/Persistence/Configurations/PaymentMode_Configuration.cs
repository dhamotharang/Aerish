using Aerish.Constants;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class PaymentMode_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<PaymentMode> builder)
        {
            builder.HasKey(a => a.PaymentModeID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<PaymentMode> builder)
        {
            builder.Property(a => a.ShortDesc)
                .IsRequired()
                .HasMaxLength(StringLengthConstant.ShortDesc);

            builder.Property(a => a.LongDesc)
                .IsRequired()
                .HasMaxLength(StringLengthConstant.LongDesc);

            builder.Property(a => a.AltDesc)
                .HasMaxLength(StringLengthConstant.AltDesc);
        }

        protected override void SeedData(BaseSeeder<PaymentMode> builder)
        {
            builder.HasData(new PaymentMode
            {
                PaymentModeID = 1,
                ShortDesc = "Weekly",
                LongDesc = "Weekly"
            });

            builder.HasData(new PaymentMode
            {
                PaymentModeID = 2,
                ShortDesc = "Bi-weekly",
                LongDesc = "Bi-weekly"
            });

            builder.HasData(new PaymentMode
            {
                PaymentModeID = 3,
                ShortDesc = "Semi-Monthly",
                LongDesc = "Semi-Monthly"
            });

            builder.HasData(new PaymentMode
            {
                PaymentModeID = 4,
                ShortDesc = "Monthly",
                LongDesc = "Monthly"
            });

            builder.HasData(new PaymentMode
            {
                PaymentModeID = 5,
                ShortDesc = "Daily",
                LongDesc = "Daily"
            });

            builder.HasData(new PaymentMode
            {
                PaymentModeID = 6,
                ShortDesc = "Annually",
                LongDesc = "Annually"
            });
        }
    }
}
