using Aerish.Commands.Base;
using Aerish.Common.Models;
using Aerish.Interfaces;

using TasqR;

namespace Aerish.Application.Commands.CalcCmds
{
    public class CalcDaysFactorCmd : BaseCalculationCommand, ITasq
    {
        public CalcDaysFactorCmd(IProcessTrackerBase processTracker, MasterDataBO oldMasterData, MasterDataBO newMasterData)
            : base(processTracker, oldMasterData, newMasterData, null)
        {

        }

        public class CalcDaysFactorCmdHandler : TasqHandler<CalcDaysFactorCmd>
        {
            public override void Run(CalcDaysFactorCmd process)
            {
                process.m_NewMasterData.DaysFactor = 262;
            }
        }
    }
}
