using System;
using System.IO;

namespace Aerish.Domain.Entities.Common
{
    public class ProcessInstanceParameter
    {
        public int ProcessInstanceParameterID { get; set; }
        public int ProcessInstanceID { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
