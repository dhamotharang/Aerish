using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Aerish.Application.Common.Extensions;
using Aerish.Domain.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.PlanYearQrs;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

using TasqR;

namespace Aerish.Application.Handlers.Queries.PlanYearQrs
{
    public class GetPlanYearQrHandler : TasqHandler<GetPlanYearQr, QueryResult<PlanYearBO>>
    {
        private readonly IAerishDbContext p_DbContext;
        private readonly IMemoryCache p_MemoryCache;
        private readonly IMapper p_Mapper;

        const string CacheKey = "PlanYears";

        public GetPlanYearQrHandler(IAerishDbContext dbContext, IMemoryCache memoryCache, IMapper mapper)
        {
            p_DbContext = dbContext;
            p_MemoryCache = memoryCache;
            p_Mapper = mapper;
        }

        public override QueryResult<PlanYearBO> Run(GetPlanYearQr request)
        {
            var planYears = p_MemoryCache.GetOrCreate(CacheKey,
                factory => p_DbContext.PlanYears
                    .AsNoTracking()
                    .ProjectTo<PlanYearBO>(p_Mapper.ConfigurationProvider)
                    .ToArray());

            return planYears.ApplyRequestParameter(request.QueryParameter);
        }
    }
}