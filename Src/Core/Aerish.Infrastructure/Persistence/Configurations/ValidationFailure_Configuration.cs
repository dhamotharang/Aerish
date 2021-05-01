using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Constants;
using Aerish.Domain.Entities.Staging;
using Aerish.Infrastructure.Constants;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class ValidationFailure_Configuration
    {
        protected override string Schema => SchemaConstant.Staging;

        protected override void KeyBuilder(BaseKeyBuilder<ValidationFailure> builder)
        {
            builder.HasKey(a => a.ValidationFailureID);
        }

        protected override void ConfigureProperty(BasePropertyBuilder<ValidationFailure> builder)
        {
            builder.Property(a => a.PropertyName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.ErrorMessage)
                .IsRequired()
                .HasMaxLength(400);
        }
    }
}
