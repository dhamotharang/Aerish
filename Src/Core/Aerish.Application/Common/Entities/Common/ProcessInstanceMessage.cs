using System;

namespace Aerish.Domain.Entities.Common
{
    public class ProcessInstanceMessage
    {
        public int ProcessInstanceID { get; set; }
        public int JobMessageID { get; set; }

        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
