using Aerish.Constants;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class Period_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<Period> builder)
        {
            builder.HasKey(a => a.PeriodID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<Period> builder)
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

        protected override void ConfigureRelationship(BaseRelationshipBuilder<Period> builder)
        {
            builder.HasOne(a => a.N_PaymentMode)
                .WithMany()
                .HasForeignKey(a => a.PaymentModeID);
        }

        protected override void SeedData(BaseSeeder<Period> builder)
        {
            builder.HasData(new Period { PeriodID = 1, PaymentModeID = 2, ShortDesc = "First Payroll", LongDesc = "First Payroll", Order = 1, IsEveryPayroll = false, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 2, PaymentModeID = 2, ShortDesc = "Third Payroll", LongDesc = "Third Payroll", Order = 3, IsEveryPayroll = false, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 3, PaymentModeID = 2, ShortDesc = "Every Payroll", LongDesc = "Every Payroll", Order = 4, IsEveryPayroll = true, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 4, PaymentModeID = 2, ShortDesc = "Second Payroll", LongDesc = "Second Payroll", Order = 2, IsEveryPayroll = false, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 5, PaymentModeID = 5, ShortDesc = "Every Payroll", LongDesc = "Every Payroll", Order = 1, IsEveryPayroll = true, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 6, PaymentModeID = 4, ShortDesc = "Every Payroll", LongDesc = "Every Payroll", Order = 1, IsEveryPayroll = true, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 7, PaymentModeID = 3, ShortDesc = "Every Payroll", LongDesc = "Every Payroll", Order = 3, IsEveryPayroll = true, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 8, PaymentModeID = 3, ShortDesc = "First Half", LongDesc = "First Half", Order = 1, IsEveryPayroll = false, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 9, PaymentModeID = 3, ShortDesc = "Second Half", LongDesc = "Second Half", Order = 2, IsEveryPayroll = false, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 10, PaymentModeID = 1, ShortDesc = "Fourth Week", LongDesc = "Fourth Week", Order = 4, IsEveryPayroll = false, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 11, PaymentModeID = 1, ShortDesc = "Fifth Week", LongDesc = "Fifth Week", Order = 5, IsEveryPayroll = false, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 12, PaymentModeID = 1, ShortDesc = "Second Week", LongDesc = "Second Week", Order = 2, IsEveryPayroll = false, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 13, PaymentModeID = 1, ShortDesc = "Every Payroll", LongDesc = "Every Payroll", Order = 6, IsEveryPayroll = true, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 14, PaymentModeID = 1, ShortDesc = "Third Week", LongDesc = "Third Week", Order = 3, IsEveryPayroll = false, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 15, PaymentModeID = 1, ShortDesc = "First Week", LongDesc = "First Week", Order = 1, IsEveryPayroll = false, IsNeedPayoutPlace = false });
            builder.HasData(new Period { PeriodID = 16, PaymentModeID = 6, ShortDesc = "January", LongDesc = "January", Order = 0, IsEveryPayroll = false, IsNeedPayoutPlace = true });
            builder.HasData(new Period { PeriodID = 17, PaymentModeID = 6, ShortDesc = "February", LongDesc = "February", Order = 0, IsEveryPayroll = false, IsNeedPayoutPlace = true });
            builder.HasData(new Period { PeriodID = 18, PaymentModeID = 6, ShortDesc = "March", LongDesc = "March", Order = 0, IsEveryPayroll = false, IsNeedPayoutPlace = true });
            builder.HasData(new Period { PeriodID = 19, PaymentModeID = 6, ShortDesc = "April", LongDesc = "April", Order = 0, IsEveryPayroll = false, IsNeedPayoutPlace = true });
            builder.HasData(new Period { PeriodID = 20, PaymentModeID = 6, ShortDesc = "May", LongDesc = "May", Order = 0, IsEveryPayroll = false, IsNeedPayoutPlace = true });
            builder.HasData(new Period { PeriodID = 21, PaymentModeID = 6, ShortDesc = "June", LongDesc = "June", Order = 0, IsEveryPayroll = false, IsNeedPayoutPlace = true });
            builder.HasData(new Period { PeriodID = 22, PaymentModeID = 6, ShortDesc = "July", LongDesc = "July", Order = 0, IsEveryPayroll = false, IsNeedPayoutPlace = true });
            builder.HasData(new Period { PeriodID = 23, PaymentModeID = 6, ShortDesc = "August", LongDesc = "August", Order = 0, IsEveryPayroll = false, IsNeedPayoutPlace = true });
            builder.HasData(new Period { PeriodID = 24, PaymentModeID = 6, ShortDesc = "September", LongDesc = "September", Order = 0, IsEveryPayroll = false, IsNeedPayoutPlace = true });
            builder.HasData(new Period { PeriodID = 25, PaymentModeID = 6, ShortDesc = "October", LongDesc = "October", Order = 0, IsEveryPayroll = false, IsNeedPayoutPlace = true });
            builder.HasData(new Period { PeriodID = 26, PaymentModeID = 6, ShortDesc = "November", LongDesc = "November", Order = 0, IsEveryPayroll = false, IsNeedPayoutPlace = true });
            builder.HasData(new Period { PeriodID = 27, PaymentModeID = 6, ShortDesc = "December", LongDesc = "December", Order = 0, IsEveryPayroll = false, IsNeedPayoutPlace = true });
        }
    }
}
