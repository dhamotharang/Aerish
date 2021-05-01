using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Commands.DeductionCmds.Contributions;

using TasqR;

namespace Aerish.Application.Commands.DeductionCmds.Contributions
{
    public class BaseContributionDeductionCmdHandler : TasqHandler<ContributionDeductionCmd>
    {
        public override void Run(ContributionDeductionCmd request)
        {
            throw new NotImplementedException();
        }
    }
}
