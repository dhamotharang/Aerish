using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Constants;
using Aerish.Domain.Entities.Common;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class LoanType_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<LoanType> builder)
        {
            builder.HasKey(a => a.LoanTypeID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<LoanType> builder)
        {
            builder.Property(p => p.ShortDesc)
                .IsRequired()
                .HasMaxLength(StringLengthConstant.ShortDesc);

            builder.Property(p => p.LongDesc)
               .IsRequired()
               .HasMaxLength(StringLengthConstant.LongDesc);

            builder.Property(p => p.AltDesc)
               .HasMaxLength(StringLengthConstant.AltDesc);
        }

        protected override void SeedData(BaseSeeder<LoanType> builder)
        {
            builder.HasData(new LoanType
            {
                LoanTypeID = 1,
                ShortDesc = "Company Loan",
                LongDesc = "Company Loan"
            });
        }
    }
}
