using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Common.Models
{
    public class ChangeTracker
    {
        public string Property { get; set; }
        public string OriginalValue { get; set; }
        public string NewValue { get; set; }
    }
}
