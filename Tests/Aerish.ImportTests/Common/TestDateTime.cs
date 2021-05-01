using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aerish.Interfaces;

namespace Aerish.ImportTests.Common
{
    public class TestDateTime : IDateTime
    {
        public DateTime Now { get => DateTime.UtcNow; }
    }
}
