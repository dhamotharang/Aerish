using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Commands.Base;
using Aerish.Common.Models;
using Aerish.Interfaces;

using TasqR;

namespace Aerish.Commands.DeductionCmds.Contributions
{
    public class ContributionDeductionCmd : BaseCalculationCommand, ITasq
    {
        public ContributionDeductionCmd(IProcessTracker processTracker, MasterDataBO oldMasterData, MasterDataBO newMasterData, object reference) 
            : base(processTracker, oldMasterData, newMasterData, reference)
        {
        }
    }
}
