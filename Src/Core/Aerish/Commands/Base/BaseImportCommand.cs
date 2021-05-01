using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Interfaces;

namespace Aerish.Commands.Base
{
    public abstract class BaseImportCommand : JobBase
    {
        public ImportLoadType LoadType { get; protected set; } = ImportLoadType.None;
        public string Path { get; protected set; }
        public string Data { get; protected set; }

        protected BaseImportCommand(IProcessTrackerBase processTracker) : base(processTracker)
        {
        }
    }
}
