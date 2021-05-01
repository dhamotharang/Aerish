using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.JobQrs
{
    public class FindJobQr : ITasq<JobBO>
    {
        public FindJobQr(short jobID)
        {
            JobID = jobID;
        }

        public short JobID { get; }
    }
}
