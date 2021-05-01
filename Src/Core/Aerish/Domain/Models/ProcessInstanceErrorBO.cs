using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class ProcessInstanceErrorBO
    {
        public string ErrorType { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
