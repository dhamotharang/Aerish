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
    public partial class EmployeeLoan_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<EmployeeLoan> builder)
        {
            builder.HasKey(a => a.EmployeeLoanID);
        }

        protected override void ConfigureRelationship(BaseRelationshipBuilder<EmployeeLoan> builder)
        {
            builder.HasOne(a => a.N_EmployeeLoanRef)
                .WithMany(a => a.N_EmployeeLoans)
                .HasForeignKey(a => new
                {
                    a.EmployeeLoanRefID,
                    a.EmployeeID,
                    a.ClientID,
                    a.LoanID
                });

            builder.HasOne<Loan>()
                .WithMany()
                .HasForeignKey(a => a.LoanID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<PayRun>()
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
