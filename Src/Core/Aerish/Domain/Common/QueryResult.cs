using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Common
{
    public class QueryResult<T>
    {
        public int Count { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
