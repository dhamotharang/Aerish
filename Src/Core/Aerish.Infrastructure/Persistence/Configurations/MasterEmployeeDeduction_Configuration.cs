using Aerish.Constants;
using Aerish.Domain.Entities.CalcData;
using Aerish.Infrastructure.Constants;

using Microsoft.EntityFrameworkCore;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class MasterEmployeeDeduction_Configuration
    {
        protected override string Schema => SchemaConstant.CalcData;

        protected override void KeyBuilder(BaseKeyBuilder<MasterEmployeeDeduction> builder)
        {
            builder.HasKey(a => new
            {
                a.MasterEmployeeDeductionID,
                a.CalcID,
                a.PlanYear,
                a.PayRunID,
                a.EmployeeID,
                a.DeductionID,
                a.ClientID
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<MasterEmployeeDeduction> builder)
        {
            builder.Property(a => a.MasterEmployeeDeductionID)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ShortDesc)
               .IsRequired()
               .HasMaxLength(StringLengthConstant.ShortDesc);

            builder.Property(p => p.LongDesc)
               .IsRequired()
               .HasMaxLength(StringLengthConstant.LongDesc);

            builder.Property(p => p.AltDesc)
               .HasMaxLength(StringLengthConstant.AltDesc);

            builder.Property(a => a.RecordStatus)
                .HasConversion<string>()
                .HasMaxLength(StringLengthConstant.Enums);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<MasterEmployeeDeduction> builder)
        {
            builder.HasOne<MasterEmployee>()
                .WithMany(a => a.N_MasterEmployeeDeductions)
                .HasForeignKey(a => new
                {
                    a.EmployeeID,
                    a.ClientID,
                    a.CalcID,
                    a.PlanYear,
                    a.PayRunID
                })
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.N_PayRun)
                .WithMany()
                .HasForeignKey(a => new
                {
                    a.ClientID,
                    a.PayRunID,
                    a.PlanYear
                })
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.N_Deduction)
                .WithMany()
                .HasForeignKey(a => a.DeductionID);
        }
    }
}