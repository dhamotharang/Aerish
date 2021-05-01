using Aerish.Constants;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

using System;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class BasicPay_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<BasicPay> builder)
        {
            builder.HasKey(a => new
            {
                a.BasicPayID,
                a.EmployeeID,
                a.ClientID
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<BasicPay> builder)
        {
            builder.Property(a => a.AmountBasis)
                .HasConversion<string>()
                .HasMaxLength(StringLengthConstant.Enums);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<BasicPay> builder)
        {
            builder.HasOne(a => a.N_Employee)
                .WithMany(a => a.N_BasicPays)
                .HasForeignKey(a => new
                {
                    a.EmployeeID,
                    a.ClientID
                });

            builder.HasOne(a => a.N_PeriodStart)
                .WithMany()
                .HasForeignKey(a => a.PeriodStartID);

            builder.HasOne(a => a.N_PeriodEnd)
                .WithMany()
                .HasForeignKey(a => a.PeriodEndID);
        }
    }
}
