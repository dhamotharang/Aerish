using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Common.Utilities
{
    public class DateTimeUtility
    {
        public virtual DateTime ParseDateTime(string data)
        {
            if (DateTime.TryParse(data, out DateTime result))
            {
                return result;
            }

            return DateTime.MinValue;
        }

        public virtual DateTime? ParseDateTimeOrNull(string data)
        {
            if (DateTime.TryParse(data, out DateTime result))
            {
                return result;
            }

            return null;
        }
    }
}
