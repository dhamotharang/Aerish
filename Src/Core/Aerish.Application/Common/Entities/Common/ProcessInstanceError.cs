using System;

namespace Aerish.Domain.Entities.Common
{
    public class ProcessInstanceError
    {
        public int ProcessInstanceID { get; set; }
        public int JobErrorID { get; set; }

        public string ErrorType { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
