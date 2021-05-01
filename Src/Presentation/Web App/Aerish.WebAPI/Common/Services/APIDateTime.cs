using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aerish.Interfaces;

namespace Aerish.WebAPI.Common
{
    public class APIDateTime : IDateTime
    {
        public DateTime Now { get => DateTime.UtcNow; }
    }
}
