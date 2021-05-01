using Aerish.Constants;
using Aerish.Domain.Entities.CalcData;
using Aerish.Infrastructure.Constants;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class SpecialGroupMember_Configuration
    {
        protected override string Schema => SchemaConstant.CalcData;

        protected override void KeyBuilder(BaseKeyBuilder<SpecialGroupMember> builder)
        {
            builder.HasKey(p => new
            {
                p.GroupID,
                p.EmployeeID
            });
        }
    }
}
