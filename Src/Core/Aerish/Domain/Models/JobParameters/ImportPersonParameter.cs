using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Common;

namespace Aerish.Domain.Models.JobParameters
{
    public class ImportPersonParameter : ParameterDictionary
    {
        public string Path
        {
            get => GetAs<string>(nameof(Path));
            set => this[nameof(Path)] = new ParameterBO(nameof(Path), value);
        }
    }
}