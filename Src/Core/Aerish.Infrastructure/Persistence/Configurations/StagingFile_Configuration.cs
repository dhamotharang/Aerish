using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Constants;
using Aerish.Domain.Entities.Staging;

namespace Aerish.Infrastructure.Persistence.Configurations
{
    public partial class BatchFile_Configuration
    {
        protected override void KeyBuilder(BaseKeyBuilder<BatchFile> builder)
        {
            builder.HasKey(a => a.FileID);
        }

    }
}
