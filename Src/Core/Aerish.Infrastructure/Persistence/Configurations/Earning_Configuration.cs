using Aerish.Commands.CalcCmds;
using Aerish.Commands.EarningCmds.Earnings;
using Aerish.Constants;
using Aerish.Domain.Entities.Common;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class Earning_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<Earning> builder)
        {
            builder.HasKey(a => a.EarningID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<Earning> builder)
        {
            builder.Property(a => a.ComputedBy)
                .HasConversion<string>()
                .HasMaxLength(StringLengthConstant.Enums);

            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(StringLengthConstant.Code);

            builder.Property(p => p.ShortDesc)
                .IsRequired()
                .HasMaxLength(StringLengthConstant.ShortDesc);

            builder.Property(p => p.LongDesc)
               .IsRequired()
               .HasMaxLength(StringLengthConstant.LongDesc);

            builder.Property(p => p.AltDesc)
               .HasMaxLength(StringLengthConstant.AltDesc);
        }

        protected override void ConfigureIndex(BaseIndexBuilder<Earning> builder)
        {
            builder.HasIndex(a => new
            {
                a.Code,
                a.ClientID,
                a.IsEnabled
            });
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<Earning> builder)
        {

            builder.HasOne(a => a.N_EarningType)
                .WithMany()
                .HasForeignKey(a => a.EarningTypeID);

            builder.HasOne(a => a.N_TaskHandlerProvider)
                .WithMany()
                .HasForeignKey(a => a.TaskHandlerProviderID);
        }

        protected override void SeedData(BaseSeeder<Earning> builder)
        {
            builder.HasData(new Earning
            {
                EarningID = 1,
                EarningTypeID = EarningTypeIDConstants.BasicPay,
                Code = EarningCodeConstants.BasicPay,
                ClientID = ClientConstant.Default,
                ShortDesc = "Basic Pay",
                LongDesc = "Basic Pay",
                IsTaxable = true,
                IsReceivable = true,
                IsEnabled = true,
                TaskHandlerProviderID = TaskHandlerProviderConstants.BasicPay
            });

            builder.HasData(new Earning
            {
                EarningID = 2,
                EarningTypeID = EarningTypeIDConstants.Absence,
                Code = EarningCodeConstants.Absent,
                ClientID = ClientConstant.Default,
                ShortDesc = "Absent",
                LongDesc = "Absent",
                ComputedBy = ComputedBy.Hour,
                IsComputed = true,
                IsDeMinimis = false,
                IsAdjustIfAbsent = true,
                IsNegativeComputation = true,
                IsPartOfBasicPay = true,
                IsTaxable = true,
                IsReceivable = false,
                IsEnabled = false
            });

            builder.HasData(new Earning
            {
                EarningID = 3,
                EarningTypeID = EarningTypeIDConstants.Allowance,
                Code = EarningCodeConstants.InternetAllowance,
                ClientID = ClientConstant.Default,
                ShortDesc = "Internet Allowance",
                LongDesc = "Internet Allowance",
                IsDeMinimis = true,
                IsTaxable = true,
                IsReceivable = true,
                IsEnabled = true,
                TaskHandlerProviderID = TaskHandlerProviderConstants.DefaultEarning
            });

            builder.HasData(new Earning
            {
                EarningID = 4,
                EarningTypeID = EarningTypeIDConstants.Allowance,
                Code = EarningCodeConstants.ShiftAllowance,
                ClientID = ClientConstant.Default,
                ShortDesc = "Shift Allowance",
                LongDesc = "Shift Allowance",
                IsDeMinimis = true,
                IsTaxable = true,
                IsReceivable = true,
                IsEnabled = true,
                TaskHandlerProviderID = TaskHandlerProviderConstants.DefaultEarning
            });

            builder.HasData(new Earning
            {
                EarningID = 5,
                EarningTypeID = EarningTypeIDConstants.Allowance,
                Code = EarningCodeConstants.RiceAllowance,
                ClientID = ClientConstant.Default,
                ShortDesc = "Rice Allowance",
                LongDesc = "Rice Allowance",
                IsReceivable = true,
                IsEnabled = true,
                TaskHandlerProviderID = TaskHandlerProviderConstants.DefaultEarning
            });

            builder.HasData(new Earning
            {
                EarningID = 6,
                EarningTypeID = EarningTypeIDConstants.Allowance,
                Code = EarningCodeConstants.ClothingAllowance,
                ClientID = ClientConstant.Default,
                ShortDesc = "Clothing Allowance",
                LongDesc = "Clothing Allowance",
                IsReceivable = true,
                IsEnabled = true,
                TaskHandlerProviderID = TaskHandlerProviderConstants.DefaultEarning
            });
        }
    }
}