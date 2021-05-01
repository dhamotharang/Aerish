using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aerish.Application.Common.Extensions;
using Aerish.Domain.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.PayRunQrs;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using TasqR;

namespace Aerish.Application.Handlers.Queries.PayRunQrs
{
    public class GetPayRunQrHandler : TasqHandler<GetPayRunQr, QueryResult<PayRunBO>>
    {
        private readonly IAerishDbContext p_DbContext;
        private readonly IMemoryCache p_MemoryCache;
        private readonly IAppSession p_AppSession;
        private readonly IMapper p_Mapper;
        
        protected string CacheKey;

        public GetPayRunQrHandler(IAerishDbContext dbContext, IMemoryCache memoryCache, IAppSession appSession, IMapper mapper)
        {
            p_DbContext = dbContext;
            p_MemoryCache = memoryCache;
            p_AppSession = appSession;
            p_Mapper = mapper;
            CacheKey = $"PayRuns_{p_AppSession.ClientID}";
        }

        public override QueryResult<PayRunBO> Run(GetPayRunQr request)
        {
            var retVal = p_MemoryCache.GetOrCreate(CacheKey, 
                factory => p_DbContext.PayRuns
                    .AsNoTracking()
                    .Where(a => a.ClientID == p_AppSession.ClientID)
                    .ProjectTo<PayRunBO>(p_Mapper.ConfigurationProvider)
                    .ToArray());

            return retVal.Where(a => a.PlanYear == request.PlanYear)
                .ApplyRequestParameter(request.Parameter);
        }
    }
}