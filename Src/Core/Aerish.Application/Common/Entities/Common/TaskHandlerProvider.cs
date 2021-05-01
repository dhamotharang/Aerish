using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Application.Common.Entities.Base;

namespace Aerish.Domain.Entities.Common
{
    public class TaskHandlerProvider : BaseEntity
    {
        public int ID { get; set; }

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
