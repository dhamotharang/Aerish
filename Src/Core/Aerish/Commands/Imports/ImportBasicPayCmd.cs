using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Aerish.Commands.Base;
using Aerish.Domain.Models;
using Aerish.Domain.Models.Imports;
using Aerish.Interfaces;

using TasqR;

namespace Aerish.Commands.Imports
{
    public class ImportBasicPayCmd : BaseImportCommand, ITasq<StagingBasicPayBO, StagingBasicPayBO>
    {
        public ImportBasicPayCmd(IProcessTrackerBase processTracker) : base(processTracker) { }

        public ImportBasicPayCmd(IProcessTrackerBase processTracker, string data) : base(processTracker)
        {
            if (!string.IsNullOrWhiteSpace(data))
            {
                Data = data;
                LoadType = ImportLoadType.Data;
            }
        }
    }
}
