using System;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Aerish
{
    [Serializable]
    public class AerishObjectNotFoundException<TType> : Exception where TType : class
    {
        public AerishObjectNotFoundException()
        {

        }

        public AerishObjectNotFoundException(object objectKey)
            : base($"Object {typeof(TType).Name} not found for objectKey: {ParseObjectKey(objectKey)}")
        {

        }

        public AerishObjectNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected AerishObjectNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        private static string ParseObjectKey(object objectKey)
        {
            return JsonSerializer.Serialize(objectKey);
        }
    }
}
