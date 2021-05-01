using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish
{
    public class AerishException : Exception
    {
        public AerishException(string message) : base(message)
        {

        }

        public AerishException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
