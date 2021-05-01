using Aerish.Commands.DeductionCmds.Contributions;
using Aerish.Commands.DeductionCmds.Deductions;
using Aerish.Constants;
using Aerish.Domain.Entities.Common;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class Deduction_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<Deduction> builder)
        {
            builder.HasKey(a => a.DeductionID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<Deduction> builder)
        {
            builder.Property(a => a.DeductionID).ValueGeneratedOnAdd();

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

        protected override void ConfigureIndex(BaseIndexBuilder<Deduction> builder)
        {
            builder.HasIndex(a => new
            {
                a.Code,
                a.ClientID,
                a.IsEnabled
            });
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<Deduction> builder)
        {
            builder.HasOne(a => a.N_DeductionType)
                .WithMany()
                .HasForeignKey(a => a.DeductionTypeID);

            builder.HasOne(a => a.N_TaskHandlerProvider)
                .WithMany()
                .HasForeignKey(a => a.TaskHandlerProviderID);
        }

        protected override void SeedData(BaseSeeder<Deduction> builder)
        {
            builder.HasData(new Deduction
            {
                ClientID = ClientConstant.Default,
                Code = DeductionCodeConstants.CashAdvance,
                DeductionID = 1,
                DeductionTypeID = 1,
                ShortDesc = "Cash Advance",
                LongDesc = "Cash Advance",
                IsEnabled = false,
                IsExcludedInTax = false,
                TaskHandlerProviderID = TaskHandlerProviderConstants.CashAdvanceDeduction
            });

            builder.HasData(new Deduction
            {
                ClientID = ClientConstant.Default,
                Code = DeductionCodeConstants.SSS,
                DeductionID = 2,
                DeductionTypeID = 2,
                ShortDesc = "SSS Contribution",
                LongDesc = "SSS Contribution",
                IsEnabled = true,
                IsExcludedInTax = true,
                TaskHandlerProviderID = TaskHandlerProviderConstants.ContributionDeductionSSS
            });

            builder.HasData(new Deduction
            {
                ClientID = ClientConstant.Default,
                Code = DeductionCodeConstants.PagIBIG,
                DeductionID = 3,
                DeductionTypeID = 2,
                ShortDesc = "Pag-IBIG Contribution",
                LongDesc = "Pag-IBIG Contribution",
                IsEnabled = true,
                IsExcludedInTax = true,
                TaskHandlerProviderID = TaskHandlerProviderConstants.ContributionDeductionPagIBIG
            });

            builder.HasData(new Deduction
            {
                ClientID = ClientConstant.Default,
                Code = DeductionCodeConstants.PhilHealth,
                DeductionID = 4,
                DeductionTypeID = 2,
                ShortDesc = "PhilHealth Contribution",
                LongDesc = "PhilHealth Contribution",
                IsEnabled = true,
                IsExcludedInTax = true,
                TaskHandlerProviderID = TaskHandlerProviderConstants.ContributionDeductionPhilHealth
            });

            builder.HasData(new Deduction
            {
                ClientID = ClientConstant.Default,
                Code = DeductionCodeConstants.Others,
                DeductionID = 9,
                DeductionTypeID = 1,
                ShortDesc = "Others",
                LongDesc = "Others",
                IsEnabled = true,
                IsExcludedInTax = true,
                TaskHandlerProviderID = TaskHandlerProviderConstants.OtherDeduction
            });
        }
    }
}
