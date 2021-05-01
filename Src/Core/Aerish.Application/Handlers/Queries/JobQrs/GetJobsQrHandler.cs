using Aerish.Constants;
using Aerish.Domain.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TasqR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aerish.Queries.JobQrs;
using Aerish.Domain.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Aerish.Application.Queries.JobQrs
{
    public class GetJobsQrHandler : TasqHandler<GetJobsQr, IEnumerable<JobBO>>
    {
        private readonly IAerishDbContext p_DbContext;
        private readonly IMemoryCache p_MemoryCache;
        private readonly IAppSession p_AppSession;
        private readonly IMapper p_Mapper;
        private readonly string CacheKey;

        public GetJobsQrHandler
            (
                IAerishDbContext dbContext, 
                IMemoryCache memoryCache, 
                IAppSession appSession,
                IMapper mapper
            )
        {
            p_DbContext = dbContext;
            p_MemoryCache = memoryCache;
            p_AppSession = appSession;
            p_Mapper = mapper;
            CacheKey = $"JobList_{appSession.ClientID}";

        }

        public override IEnumerable<JobBO> Run(GetJobsQr request)
        {
            var retVal = p_MemoryCache.Get<IEnumerable<JobBO>>(CacheKey);

            if (retVal == null)
            {
                var jobList = new List<JobBO>();

                var clientSpecificJobs = p_DbContext.Jobs
                    .AsNoTracking()
                    .Include(a => a.N_TaskHandlerProvider)
                    .Include(a => a.N_JobParameters.OrderBy(a => a.Order))
                    .Where(a => a.ClientID == p_AppSession.ClientID && a.IsEnabled)
                    .ProjectTo<JobBO>(p_Mapper.ConfigurationProvider)
                    .ToList();

                var defaultJobs = p_DbContext.Jobs
                    .AsNoTracking()
                    .Include(a => a.N_TaskHandlerProvider)
                    .Include(a => a.N_JobParameters.OrderBy(a => a.Order))
                    .Where(a => a.ClientID == ClientConstant.Default && a.IsEnabled)
                    .ProjectTo<JobBO>(p_Mapper.ConfigurationProvider)
                    .ToList();

                jobList.AddRange(clientSpecificJobs);

                foreach (var job in defaultJobs)
                {
                    if (!jobList.Any(a => a.JobID == job.JobID))
                    {
                        jobList.Add(job);
                    }
                }

                jobList.ForEach(j =>
                {
                    j.JobParameters = j.JobParameters.OrderBy(a => a.Order);
                });

                retVal = jobList;

                p_MemoryCache.Set(CacheKey, retVal);
            }

            return retVal;
        }
    }
}