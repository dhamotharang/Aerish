using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Domain.Entities.Staging
{
    public class ValidationFailure
    {
        public long ValidationFailureID { get; set; }
        public long RowIndex { get; set; }
        public int ProcessInstanceID { get; set; }

        public string PropertyName { get; set; }

        public string ErrorMessage { get; set; }
    }
}
