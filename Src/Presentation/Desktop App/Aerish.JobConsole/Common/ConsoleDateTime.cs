using System;
using Aerish.Interfaces;

namespace Aerish.JobConsole.Common
{
    public class ConsoleDateTime : IDateTime
    {
        public DateTime Now { get => DateTime.UtcNow; }
    }
}
