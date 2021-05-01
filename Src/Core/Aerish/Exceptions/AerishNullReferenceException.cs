using System;

namespace Aerish
{
    public class AerishNullReferenceException : NullReferenceException
    {
        public AerishNullReferenceException(string typeName, object reference) : base($"No object found for {typeName}: {reference}")
        {

        }
    }
}
