using Aerish.Constants;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class Table_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<Table> builder)
        {
            builder.HasKey(a => new
            {
                a.TableID,
                a.Code
            });
        }

        protected override void ConfigureProperty(BasePropertyBuilder<Table> builder)
        {
            builder.Property(p => p.Code)
               .IsRequired()
               .HasMaxLength(StringLengthConstant.ShortDesc);

            builder.Property(p => p.ShortDesc)
                .IsRequired()
                .HasMaxLength(StringLengthConstant.ShortDesc);

            builder.Property(p => p.LongDesc)
               .IsRequired()
               .HasMaxLength(StringLengthConstant.LongDesc);

            builder.Property(p => p.AltDesc)
               .HasMaxLength(StringLengthConstant.AltDesc);
        }

        protected override void SeedData(BaseSeeder<Table> builder)
        {
            builder.HasData(new Table
            {
                TableID = 1,
                Code = TableCodeConstants.TaxTable,
                ShortDesc = "REVISED WITHHOLDING TAX TABLE",
                LongDesc = "REVISED WITHHOLDING TAX TABLE",
                EffectiveStartOn = new DateTime(2018, 1, 1),
                EffectiveEndOn = new DateTime(2022, 12, 31)
            });

            builder.HasData(new Table
            {
                TableID = 2,
                Code = TableCodeConstants.PhilHealth,
                ShortDesc = "PhilHealth",
                LongDesc = "PhilHealth",
                EffectiveStartOn = new DateTime(2020, 1, 1),
                EffectiveEndOn = new DateTime(2020, 12, 31),
                Reference = "https://www.philhealth.gov.ph/circulars/2019/circ2019-0009.pdf"
            });

            builder.HasData(new Table
            {
                TableID = 3,
                Code = TableCodeConstants.PhilHealth,
                ShortDesc = "PhilHealth",
                LongDesc = "PhilHealth",
                EffectiveStartOn = new DateTime(2021, 1, 1),
                EffectiveEndOn = new DateTime(2021, 12, 31),
                Reference = "https://www.philhealth.gov.ph/circulars/2020/circ2020-0005.pdf"
            });

            builder.HasData(new Table
            {
                TableID = 4,
                Code = TableCodeConstants.SSS,
                ShortDesc = "SSS",
                LongDesc = "PhilHSSSealth",
                EffectiveStartOn = new DateTime(2021, 1, 1),
                EffectiveEndOn = new DateTime(2021, 12, 31),
                Reference = "https://www.sss.gov.ph/sss/DownloadContent?fileName=2021-CONTRIBUTION-SCHEDULE.pdf"
            });
        }
    }
}
