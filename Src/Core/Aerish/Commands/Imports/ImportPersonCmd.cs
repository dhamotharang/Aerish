using System.IO;

using Aerish.Commands;
using Aerish.Commands.Base;
using Aerish.Domain.Models;
using Aerish.Interfaces;

using TasqR;

namespace Aerish.Commands.Imports
{
    public class ImportPersonCmd : BaseImportCommand, ITasq<StagingPersonBO, StagingPersonBO>
    {
        public ImportPersonCmd(IProcessTrackerBase processTracker) : base(processTracker) { }

        public ImportPersonCmd(IProcessTrackerBase processTracker, string data) : base(processTracker)
        {
            if (!string.IsNullOrWhiteSpace(data))
            {
                Data = data;
                LoadType = ImportLoadType.Data;
            }
        }
    }
}