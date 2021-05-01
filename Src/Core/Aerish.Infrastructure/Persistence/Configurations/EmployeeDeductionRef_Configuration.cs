using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Constants;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

using Microsoft.EntityFrameworkCore;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class EmployeeDeductionRef_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<EmployeeDeductionRef> builder)
        {
            builder.HasKey(a => new
            {
                a.ClientID,
                a.EmployeeDeductionRefID,
                a.EmployeeID,
                a.DeductionID
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<EmployeeDeductionRef> builder)
        {
            builder.Property(a => a.EmployeeDeductionRefID)
               .ValueGeneratedOnAdd();

            builder.Property(p => p.OvrdShortDesc)
               .HasMaxLength(StringLengthConstant.ShortDesc);

            builder.Property(p => p.OvrdLongDesc)
               .HasMaxLength(StringLengthConstant.LongDesc);

            builder.Property(p => p.OvrdAltDesc)
               .HasMaxLength(StringLengthConstant.AltDesc);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<EmployeeDeductionRef> builder)
        {
            builder.HasOne(a => a.N_Deduction)
                .WithMany()
                .HasForeignKey(a => a.DeductionID)
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
