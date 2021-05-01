using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aerish.Domain.Common;

namespace Aerish.Application.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static QueryResult<T> ApplyRequestParameter<T>(this IEnumerable<T> query, QueryParameter requestParameter)
        {
            return new QueryResult<T>
            {
                Count = query.Count(),
                Data = requestParameter == null
                    ? query
                    : query.Skip((requestParameter.PageNumber - 1) * requestParameter.PageSize)
                    .Take(requestParameter.PageSize)
                    .ToList()
            };
        }
    }
}