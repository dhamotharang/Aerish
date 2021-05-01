using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerish.Interfaces
{
    public interface IAppSession
    {
        int? PersonID { get; }
        short ClientID { get; }
        short PlanYear { get; }
    }
}
