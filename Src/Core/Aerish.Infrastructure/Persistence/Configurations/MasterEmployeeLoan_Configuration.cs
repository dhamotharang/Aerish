using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Constants;
using Aerish.Domain.Entities.CalcData;
using Aerish.Infrastructure.Constants;

using Microsoft.EntityFrameworkCore;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class MasterEmployeeLoan_Configuration
    {
        protected override string Schema => SchemaConstant.CalcData;

        protected override void KeyBuilder(BaseKeyBuilder<MasterEmployeeLoan> builder)
        {
            builder.HasKey(a => new
            {
                a.MasterEmployeeLoanID,
                a.CalcID,
                a.PlanYear,
                a.PayRunID,
                a.EmployeeID,
                a.LoanID,
                a.ClientID
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<MasterEmployeeLoan> builder)
        {
            builder.Property(a => a.MasterEmployeeLoanID)
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

        protected override void ConfigureRelationship(BaseRelationshipBuilder<MasterEmployeeLoan> builder)
        {
            builder.HasOne<MasterEmployee>()
                .WithMany(a => a.N_MasterEmployeeLoans)
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

            builder.HasOne(a => a.N_Loan)
                .WithMany()
                .HasForeignKey(a => a.LoanID);
        }
    }
}
