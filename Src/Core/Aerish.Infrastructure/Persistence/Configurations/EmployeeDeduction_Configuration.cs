using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Constants;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

using Microsoft.EntityFrameworkCore;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class EmployeeDeduction_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<EmployeeDeduction> builder)
        {
            builder.HasKey(a => new
            {
                a.ClientID,
                a.EmployeeDeductionID,
                a.EmployeeID
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<EmployeeDeduction> builder)
        {
            builder.Property(a => a.EmployeeDeductionID)
                .ValueGeneratedOnAdd();
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<EmployeeDeduction> builder)
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

            builder.HasOne<Deduction>()
                .WithMany()
                .HasForeignKey(a => a.DeductionID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<EmployeeDeductionRef>()
                .WithMany(a => a.N_EmployeeDeductions)
                .HasForeignKey(a => new
                {
                    a.ClientID,
                    a.EmployeeDeductionRefID,
                    a.EmployeeID,
                    a.DeductionID
                });
        }
    }
}