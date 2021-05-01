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
    public partial class EmployeeEarningRef_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<EmployeeEarningRef> builder)
        {
            builder.HasKey(a => new
            {
                a.ClientID,
                a.EmployeeEarningRefID,
                a.EmployeeID,
                a.EarningID
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<EmployeeEarningRef> builder)
        {
            builder.Property(a => a.EmployeeEarningRefID)
               .ValueGeneratedOnAdd();

            builder.Property(p => p.OvrdShortDesc)
               .HasMaxLength(StringLengthConstant.ShortDesc);

            builder.Property(p => p.OvrdLongDesc)
               .HasMaxLength(StringLengthConstant.LongDesc);

            builder.Property(p => p.OvrdAltDesc)
               .HasMaxLength(StringLengthConstant.AltDesc);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<EmployeeEarningRef> builder)
        {
            builder.HasOne(a => a.N_Earning)
                .WithMany()
                .HasForeignKey(a => a.EarningID)
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
