using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class JobParameterBO
    {
        public string Name { get; set; }
        public string Display { get; set; }

        public string DefaultValue { get; set; }
        public string DataType { get; set; }
        public int? MaxLength { get; set; }


        public bool IsRequired { get; set; }
        public short Order { get; set; }
    }
}
