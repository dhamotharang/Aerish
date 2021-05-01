using System;
using System.Text.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Aerish.Application.Common.Helpers
{
    public static class ObjectCopier
    {
        public static T Clone<T>(T source)
        {
            string json = JsonSerializer.Serialize(source);

            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
