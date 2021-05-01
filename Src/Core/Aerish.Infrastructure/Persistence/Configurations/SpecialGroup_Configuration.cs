using Aerish.Constants;
using Aerish.Domain.Entities.CalcData;
using Aerish.Infrastructure.Constants;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class SpecialGroup_Configuration
    {
        protected override string Schema => SchemaConstant.CalcData;

        protected override void KeyBuilder(BaseKeyBuilder<SpecialGroup> builder)
        {
            builder.HasKey(a => a.GroupID);
        }
    }
}
