using Aerish.Constants;
using Aerish.Domain.Entities.Common;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class Lookup_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<Lookup> builder)
        {
            builder.HasKey(a => new
            {
                a.Type,
                a.Code
            });
        }
    }
}
