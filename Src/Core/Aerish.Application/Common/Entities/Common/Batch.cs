using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Domain.Entities.Staging;

namespace Aerish.Domain.Entities.Common
{
    public class Batch
    {
        public int BatchID { get; set; }

        public int? FileID { get; set; }

        public BatchFile N_File { get; set; }
    }
}
