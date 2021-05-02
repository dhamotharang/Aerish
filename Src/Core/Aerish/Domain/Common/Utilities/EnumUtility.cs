using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Common.Utilities
{
    public class EnumUtility
    {
        public T? TryParseEnumOrNull<T>(string value) where T : struct, Enum
        {
            if (Enum.TryParse(typeof(T), value, out object result))
            {
                return (T)result;
            }

            return null;
        }

        public T TryParseEnum<T>(string value) where T : struct, Enum
        {
            if (Enum.TryParse(typeof(T), value, out object result))
            {
                return (T)result;
            }

            return default;
        }
    }
}
