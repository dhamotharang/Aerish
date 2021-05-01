using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Constants;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Infrastructure.Constants;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class OTRate_Configuration
    {
        protected override string Schema => SchemaConstant.Parameter;

        protected override void KeyBuilder(BaseKeyBuilder<OTRate> builder)
        {
            builder.HasKey(a => a.OTRateID);
        }
    }
}
