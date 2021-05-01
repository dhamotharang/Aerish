using Aerish.Commands.LoanCmds.CompanyLoans;
using Aerish.Constants;
using Aerish.Domain.Entities.Common;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class Loan_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<Loan> builder)
        {
            builder.HasKey(a => a.LoanID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<Loan> builder)
        {
            builder.Property(a => a.LoanID).ValueGeneratedOnAdd();

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

        protected override void ConfigureIndex(BaseIndexBuilder<Loan> builder)
        {
            builder.HasIndex(a => new
            {
                a.Code,
                a.ClientID,
                a.IsEnabled
            });
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<Loan> builder)
        {
            builder.HasOne(a => a.N_LoanType)
                .WithMany()
                .HasForeignKey(a => a.LoanTypeID);

            builder.HasOne(a => a.N_TaskHandlerProvider)
                .WithMany()
                .HasForeignKey(a => a.TaskHandlerProviderID);
        }

        protected override void SeedData(BaseSeeder<Loan> builder)
        {
            builder.HasData(new Loan
            {
                LoanID = 1,
                LoanTypeID = 1,
                ShortDesc = "HMO Premium Payable",
                LongDesc = "HMO Premium Payable",
                ClientID = ClientConstant.Default,
                Code = LoanCodeConstants.HMOPremiumPayable,
                IsEnabled = true,
                TaskHandlerProviderID = TaskHandlerProviderConstants.HMOPremiumPayableLoan
            });
        }
    }
}
