using Aerish.Constants;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class EmployeeLoanRef_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<EmployeeLoanRef> builder)
        {
            builder.HasKey(a => new
            {
                a.EmployeeLoanRefID,
                a.EmployeeID,
                a.ClientID,
                a.LoanID
            });
        }

        protected override void ConfigureEntity(EntityTypeBuilder<EmployeeLoanRef> builder)
        {
            builder.Ignore(a => a.TotalLoan);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<EmployeeLoanRef> builder)
        {
            builder.Property(p => p.OvrdShortDesc)
                .HasMaxLength(StringLengthConstant.ShortDesc);

            builder.Property(p => p.OvrdLongDesc)
               .HasMaxLength(StringLengthConstant.LongDesc);

            builder.Property(p => p.OvrdAltDesc)
               .HasMaxLength(StringLengthConstant.AltDesc);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<EmployeeLoanRef> builder)
        {
            builder.HasOne(a => a.N_Loan)
               .WithMany()
               .HasForeignKey(a => a.LoanID)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.N_Employee)
                .WithMany()
                .HasForeignKey(a => new
                {
                    a.EmployeeID,
                    a.ClientID
                });
        }
    }
}
