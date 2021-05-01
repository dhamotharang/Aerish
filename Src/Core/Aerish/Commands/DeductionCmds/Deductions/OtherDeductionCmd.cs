using System;
using System.Collections.Generic;
using System.Text;
using Aerish.Commands.Base;
using Aerish.Common.Models;
using Aerish.Domain.Models;
using Aerish.Interfaces;

using TasqR;

namespace Aerish.Commands.DeductionCmds.Deductions
{
    public class OtherDeductionCmd : BaseCalculationCommand, ITasq
    {
        private readonly DeductionBO p_Deduction;

        public OtherDeductionCmd(IProcessTrackerBase processTracker, MasterDataBO oldMasterData, MasterDataBO newMasterData, DeductionBO reference)
            : base(processTracker, oldMasterData, newMasterData, reference)
        {
            p_Deduction = reference;
        }
    }
}
