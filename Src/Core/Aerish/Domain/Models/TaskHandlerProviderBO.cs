using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class TaskHandlerProviderBO
    {
        public string TaskAssembly { get; set; }
        public string TaskClass { get; set; }

        public string HandlerAssembly { get; set; }
        public string HandlerClass { get; set; }

        public bool IsDefaultHandler
        {
            get
            {
                return string.IsNullOrWhiteSpace(HandlerAssembly) || string.IsNullOrWhiteSpace(HandlerClass);
            }
        }
    }
}
