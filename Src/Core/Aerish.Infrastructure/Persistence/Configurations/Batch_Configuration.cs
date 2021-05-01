using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Domain.Entities.Common;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class Batch_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<Batch> builder)
        {
            builder.HasKey(a => a.BatchID);
        }
    }
}
