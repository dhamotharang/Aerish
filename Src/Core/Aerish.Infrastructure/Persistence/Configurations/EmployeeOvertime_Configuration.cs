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
    public partial class EmployeeOvertime_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<EmployeeOvertime> builder)
        {
            builder.HasKey(a => new
            {
                a.EmployeeOvertimeID,
                a.PlanYear,
                a.EmployeeID,
                a.OTRateID
            });
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<EmployeeOvertime> builder)
        {
            builder.HasOne(a => a.N_OTRate)
                .WithMany()
                .HasForeignKey(a => a.OTRateID);

            builder.HasOne(a => a.N_PayRun)
                .WithMany()
                .HasForeignKey(a => new
                {
                    a.ClientID,
                    a.PayRunID,
                    a.PlanYear
                })
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
