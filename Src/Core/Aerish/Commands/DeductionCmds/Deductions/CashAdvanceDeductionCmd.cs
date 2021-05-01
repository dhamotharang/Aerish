using System;
using System.Collections.Generic;
using System.Text;
using Aerish.Commands.Base;
using Aerish.Common.Models;
using Aerish.Interfaces;

using TasqR;

namespace Aerish.Commands.DeductionCmds.Deductions
{
    public class CashAdvanceDeductionCmd : BaseCalculationCommand, ITasq
    {
        public CashAdvanceDeductionCmd(IProcessTrackerBase processTracker, MasterDataBO oldMasterData, MasterDataBO newMasterData, object reference)
            : base(processTracker, oldMasterData, newMasterData, reference)
        {
        }
    }
}
