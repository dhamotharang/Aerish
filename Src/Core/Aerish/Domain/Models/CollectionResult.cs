using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Common.Models
{
    public class CollectionResult<T>
    {
        public int Count { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
