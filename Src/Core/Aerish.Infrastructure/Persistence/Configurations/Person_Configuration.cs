using Aerish.Constants;
using Aerish.Domain.Entities;
using Aerish.Domain.Entities.Common;
using Aerish.Infrastructure.Constants;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class Person_Configuration
    {
        protected override string Schema => SchemaConstant.CommonDataModel;

        protected override void KeyBuilder(BaseKeyBuilder<Person> builder)
        {
            builder.HasKey(a => a.PersonID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<Person> builder)
        {
            builder.Property(a => a.TaxIdNumber).HasMaxLength(11);
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.MiddleName).HasMaxLength(50);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Gender)
                .HasConversion<string>()
                .HasMaxLength(StringLengthConstant.Enums);
        }
    }
}
