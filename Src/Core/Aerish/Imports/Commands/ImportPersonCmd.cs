

using System.IO;

using Aerish.Commands;
using Aerish.Commands.Base;
using Aerish.Domain.Models;
using Aerish.Interfaces;

using TasqR;

namespace Aerish.Imports.Commands
{
    public class ImportPersonCmd : BaseImportCommand, ITasq<StagingPersonBO, StagingPersonBO>
    {
        public ImportPersonCmd(IProcessTrackerBase processTracker) : base(processTracker)
        {
            if (processTracker is IProcessTracker procTracker)
            {
                Path = procTracker.Parameters?.GetAs<string>("path");

                if (!string.IsNullOrWhiteSpace(Path))
                {
                    if (!File.Exists(Path))
                    {
                        throw new AerishException($"Path doesnt exist: {Path}");
                    }

                    LoadType = ImportLoadType.File;
                }
            }
        }

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