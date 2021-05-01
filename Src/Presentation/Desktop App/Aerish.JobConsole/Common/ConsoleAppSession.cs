using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Interfaces;

namespace Aerish.JobConsole.Common
{
    public class ConsoleAppSession : IAppSession
    {
        public short ClientID { get; }
        public int? PersonID { get; }
        public short PlanYear { get; }

        public ConsoleAppSession(short clientID)
        {
            ClientID = clientID;
        }
    }
}
