using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Common;
using Aerish.Interfaces;

using TasqR;

namespace Aerish.Commands
{
    public delegate void Notify();

    public class MasterProcessCmd : ITasq<IProcessTrackerBase>
    {
        public MasterProcessCmd(short jobID, ParameterDictionary parameters)
        {
            JobID = jobID;
            Parameters = parameters;
        }

        public short JobID { get; }
        public ParameterDictionary Parameters { get; }
    }
}
