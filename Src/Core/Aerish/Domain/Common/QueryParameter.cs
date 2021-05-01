using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Common
{
    public class QueryParameter
    {
        private readonly int maxPageSize = 50;

        public FilterDescriptor Filter { get; set; }

        private int pageSize = 10;
        public int PageSize 
        { 
            get => pageSize; 
            set => pageSize = value > maxPageSize ? maxPageSize : value; 
        }

        private int pageNumber = 1;
        public int PageNumber 
        { 
            get => pageNumber; 
            set => pageNumber = value < 1 ? 1 : value; 
        }

        public T GetFromFilter<T>(string key)
        {
            if (Filter != null && Filter.Member == key)
            {
                return System.Text.Json.JsonSerializer.Deserialize<T>(Filter.Value);
            }

            return default;
        }
    }

    public class FilterDescriptor
    {
        public string Member { get; set; }
        public string Value { get; set; }
    }
}
