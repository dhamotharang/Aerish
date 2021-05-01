using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class LoanTypeBO
    {
        public short LoanTypeID { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string AltDesc { get; set; }
    }
}
