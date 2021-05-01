using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Common.Models;
using Aerish.Interfaces;

namespace Aerish.Commands.Base
{
    public abstract class BaseCalculationCommand : JobBase
    {
        public readonly MasterDataBO m_OldMasterData;
        public readonly MasterDataBO m_NewMasterData;
        public readonly object m_Reference;

        protected BaseCalculationCommand(IProcessTrackerBase processTracker, MasterDataBO oldMasterData, MasterDataBO newMasterData, object reference)
            : base(processTracker)
        {
            m_OldMasterData = oldMasterData;
            m_NewMasterData = newMasterData;
            m_Reference = reference;
        }
    }
}
