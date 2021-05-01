using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class ValidationFailureBO
    {
        public long ValidationFailureID { get; set; }
        public long RowIndex { get; set; }
        public int ProcessInstanceID { get; set; }

        public string PropertyName { get; set; }

        public string ErrorMessage { get; set; }
    }
}
