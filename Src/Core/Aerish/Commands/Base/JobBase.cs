using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Interfaces;

namespace Aerish.Commands
{
    public abstract class JobBase
    {
        public IProcessTrackerBase ProcessTracker { get; set; }

        protected JobBase(IProcessTrackerBase processTracker)
        {
            ProcessTracker = processTracker;
        }
    }
}
