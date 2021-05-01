using Aerish.Interfaces;

namespace Aerish.JobConsole.Common
{
    public class ConsoleAppEnvironment : IAppEnvironment
    {
        public bool IsDevelopment()
        {
            return false;
        }

        public bool IsProduction()
        {
            return true;
        }

        public bool IsStaging()
        {
            return false;
        }
    }
}
