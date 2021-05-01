using System;
using System.Collections.Generic;
using System.Text;
using Aerish.Commands.Base;
using Aerish.Common.Models;
using Aerish.Domain.Models;
using Aerish.Interfaces;

using TasqR;

namespace Aerish.Commands.CalcCmds
{
    public class CalcBasicPayCmd : BaseCalculationCommand, ITasq
    {
        public CalcBasicPayCmd(IProcessTrackerBase processTracker, MasterDataBO oldMasterData, MasterDataBO newMasterData, EarningBO reference)
            : base(processTracker, oldMasterData, newMasterData, reference)
        {
            BasicPay = reference;
        }

        public EarningBO BasicPay { get; }
    }
}
