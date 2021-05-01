using Aerish.Constants;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

using Microsoft.EntityFrameworkCore;
using System;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class EmployeeEarning_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<EmployeeEarning> builder)
        {
            builder.HasKey(a => new
            {
                a.ClientID,
                a.EmployeeEarningID,
                a.EmployeeID,
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<EmployeeEarning> builder)
        {
            builder.Property(a => a.EmployeeEarningID)
                .ValueGeneratedOnAdd();
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<EmployeeEarning> builder)
        {
            builder.HasOne<PayRun>()
                .WithMany()
                .HasForeignKey(a => new
                {
                    a.ClientID,
                    a.PayRunID,
                    a.PlanYear
                })
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Earning>()
                .WithMany()
                .HasForeignKey(a => a.EarningID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<EmployeeEarningRef>()
                .WithMany(a => a.N_EmployeeEarnings)
                .HasForeignKey(a => new
                {
                    a.ClientID,
                    a.EmployeeEarningRefID,
                    a.EmployeeID,
                    a.EarningID
                });
        }
    }
}
