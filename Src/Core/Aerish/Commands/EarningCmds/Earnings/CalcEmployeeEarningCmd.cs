using System;
using System.Collections.Generic;
using System.Text;
using Aerish.Commands.Base;
using Aerish.Common.Models;
using Aerish.Domain.Models;
using Aerish.Interfaces;

using TasqR;

namespace Aerish.Commands.EarningCmds.Earnings
{
    public class CalcEmployeeEarningCmd : BaseCalculationCommand, ITasq
    {

        public CalcEmployeeEarningCmd(IProcessTracker processTracker, MasterDataBO oldMasterData, MasterDataBO newMasterData, EarningBO reference)
            : base(processTracker, oldMasterData, newMasterData, reference)
        {
            Earning = reference;
        }

        public EarningBO Earning { get; }
    }
}
