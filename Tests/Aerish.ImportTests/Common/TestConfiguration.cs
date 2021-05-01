using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

namespace Aerish.ImportTests
{
    public abstract class TestConfigConstants
    {
        protected TestConfigConstants() { }

        public const string TestImportPath = "AppSettings:TestImport:Path";
    }
}
