using Aerish.Constants;
using Aerish.Domain.Entities.CalcData;
using Aerish.Infrastructure.Constants;

using Microsoft.EntityFrameworkCore;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class MasterEmployeeEarning_Configuration
    {
        protected override string Schema => SchemaConstant.CalcData;

        protected override void KeyBuilder(BaseKeyBuilder<MasterEmployeeEarning> builder)
        {
            builder.HasKey(a => new
            {
                a.MasterEmployeeEarningID,
                a.CalcID,
                a.PlanYear,
                a.PayRunID,
                a.EmployeeID,
                a.EarningID,
                a.ClientID
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<MasterEmployeeEarning> builder)
        {
            builder.Property(a => a.MasterEmployeeEarningID)
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

        protected override void ConfigureRelationship(BaseRelationshipBuilder<MasterEmployeeEarning> builder)
        {
            builder.HasOne<MasterEmployee>()
                .WithMany(a => a.N_MasterEmployeeEarnings)
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

            builder.HasOne(a => a.N_Earning)
                .WithMany()
                .HasForeignKey(a => a.EarningID);
        }
    }
}
