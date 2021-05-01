using System;
using System.Collections.Generic;
using System.Text;
using Aerish.Commands.Base;
using Aerish.Common.Models;
using Aerish.Domain.Models;
using Aerish.Interfaces;

using TasqR;

namespace Aerish.Commands.LoanCmds.CompanyLoans
{
    public class HMOPremiumPayableLoanCmd : BaseCalculationCommand, ITasq
    {

        public HMOPremiumPayableLoanCmd(IProcessTrackerBase processTracker, MasterDataBO oldMasterData, MasterDataBO newMasterData, LoanBO reference)
            : base(processTracker, oldMasterData, newMasterData, reference)
        {
            Loan = reference;
        }

        public LoanBO Loan { get; }
    }
}
