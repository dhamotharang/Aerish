
using Aerish.Interfaces;

using TasqR;

namespace Aerish.Commands.CalcCmds
{

    public class MainCalcCmd : JobBase, ITasq<int, bool>
    {
        public MainCalcCmd(IProcessTrackerBase processTracker) : base(processTracker)
        {

        }
    }
}
