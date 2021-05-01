using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class DeductionTypeBO
    {
        public short DeductionTypeID { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }
    }
}
