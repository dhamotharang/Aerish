using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aerish.Domain.Entities.Common;
using Aerish.Domain.Models;

namespace Aerish.Domain.Common
{
    public class BaseStagingEntity
    {
        public long ID { get; set; }

        public LoadStatus LoadStatus { get; set; }


        public int RowIndex { get; set; }
        public bool ImportIsValid { get; set; }
        public int? Err_ColumnIndex { get; set; }
        public string Err_Value { get; set; }
        public string Err_UnmappedRow { get; set; }


        public bool ValidationIsValid { get; set; } = true;


        public int ProcessInstanceID { get; set; }
        public ProcessInstance N_JobInstance { get; set; }
    }
}
