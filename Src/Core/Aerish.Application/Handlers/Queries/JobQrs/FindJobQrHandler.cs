using Aerish.Domain.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TasqR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aerish.Domain.Models;
using System;
using Aerish.Queries.JobQrs;

namespace Aerish.Application.Queries.JobQrs
{
    public class FindJobQrHandler : TasqHandler<FindJobQr, JobBO>
    {
        protected const string CacheKey = "JobList";
        private readonly ITasqR processor;

        public FindJobQrHandler(ITasqR processor)
        {
            this.processor = processor;
        }

        public override JobBO Run(FindJobQr request)
        {
            var jobs = processor.Run(new GetJobsQr());

            return jobs.SingleOrDefault(a => a.JobID == request.JobID);
        }
    }
}