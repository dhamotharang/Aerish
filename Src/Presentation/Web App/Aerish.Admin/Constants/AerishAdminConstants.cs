using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aerish.Admin
{
    public abstract class AerishAdminConstants
    {
        protected AerishAdminConstants() { }

        public abstract class Uri
        {
            protected Uri() { }


            public const string CalculateMasterData = "MasterData/Calculate";
            public const string MasterData = "MasterData";
            public const string PlanYear = "PlanYear";
            public const string PayRun = "PayRun";
        }
    }
}
