using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aerish.Interfaces;

namespace Aerish.WebAPI.Common
{
    public class APIEnvironment : IAppEnvironment
    {
        public bool IsDevelopment()
        {
            return true;
        }

        public bool IsProduction()
        {
            return false;   
        }

        public bool IsStaging()
        {
            return false;   
        }
    }
}
