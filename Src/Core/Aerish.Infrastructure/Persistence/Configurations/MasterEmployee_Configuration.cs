using Aerish.Constants;
using Aerish.Domain.Entities.CalcData;
using Aerish.Infrastructure.Constants;

using Microsoft.EntityFrameworkCore;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class MasterEmployee_Configuration
    {
        protected override string Schema => SchemaConstant.CalcData;

        protected override void KeyBuilder(BaseKeyBuilder<MasterEmployee> builder)
        {
            builder.HasKey(a => new
            {
                a.EmployeeID,
                a.ClientID,
                a.CalcID,
                a.PlanYear,
                a.PayRunID
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<MasterEmployee> builder)
        {
            builder.Property(a => a.RecordStatus)
                .HasConversion<string>()
                .HasMaxLength(StringLengthConstant.Enums);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<MasterEmployee> builder)
        {
            builder.HasOne(a => a.N_Employee)
                .WithMany()
                .HasForeignKey(a => new
                {
                    a.EmployeeID,
                    a.ClientID
                });

            builder.HasOne(a => a.N_PayRun)
                .WithMany()
                .HasForeignKey(a => new
                {
                    a.ClientID,
                    a.PayRunID,
                    a.PlanYear
                })
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
