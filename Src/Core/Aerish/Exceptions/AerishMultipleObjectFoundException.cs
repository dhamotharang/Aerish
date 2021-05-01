using System;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Aerish
{
    [Serializable]
    public class AerishMultipleObjectFoundException<TType> : Exception where TType : class
    {
        public AerishMultipleObjectFoundException()
        {

        }

        public AerishMultipleObjectFoundException(object objectKey)
            : base($"Multiple {typeof(TType).Name} result found for objectKey: {ParseObjectKey(objectKey)}")
        {

        }

        public AerishMultipleObjectFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected AerishMultipleObjectFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        private static string ParseObjectKey(object objectKey)
        {
            return JsonSerializer.Serialize(objectKey);
        }
    }
}
