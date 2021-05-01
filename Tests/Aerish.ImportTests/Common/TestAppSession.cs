using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aerish.Interfaces;

namespace Aerish.ImportTests.Common
{
    public class TestAppSession : IAppSession
    {
        public int? PersonID { get => 1; }
        public short ClientID { get => 1; }
        public short PlanYear { get => (short)DateTime.Now.Year; }
    }
}
