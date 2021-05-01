using Aerish.Constants;
using Aerish.Domain.Common;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.EarningQrs;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TasqR;

namespace Aerish.Application.Queries.EarningQrs
{
    public class GetEarningListQrHandler : TasqHandler<GetEarningListQr, IEnumerable<EarningBO>>
    {
        protected const string CacheKey = "EarningList";

        private readonly IAerishDbContext dbContext;
        private readonly IMemoryCache memoryCache;
        private readonly IAppSession p_AppSession;
        private readonly IMapper p_Mapper;

        public GetEarningListQrHandler
            (
                IAerishDbContext dbContext,
                IMemoryCache memoryCache,
                IAppSession appSession,
                IMapper mapper
            )
        {
            this.dbContext = dbContext;
            this.memoryCache = memoryCache;
            p_AppSession = appSession;
            p_Mapper = mapper;
        }

        public override IEnumerable<EarningBO> Run(GetEarningListQr process)
        {
            var retVal = memoryCache.Get<IEnumerable<EarningBO>>(CacheKey);

            if (retVal == null)
            {
                retVal = dbContext.Earnings
                    .AsNoTracking()
                    .Include(a => a.N_EarningType)
                    .Include(a => a.N_TaskHandlerProvider)
                    .Where(a => a.IsEnabled)
                    .ProjectTo<EarningBO>(p_Mapper.ConfigurationProvider)
                    .ToList();

                memoryCache.Set(CacheKey, retVal);
            }

            return process.ClientSpecific ? GetClientSpecific(retVal) : retVal;
        }

        protected virtual IEnumerable<EarningBO> GetClientSpecific(IEnumerable<EarningBO> allEarnings)
        {
            var retVal = new List<EarningBO>();

            var defaults = allEarnings
                .Where(a => a.ClientID == ClientConstant.Default)
                .ToList();

            var clientSpecifics = allEarnings
                .Where(a => a.ClientID == p_AppSession.ClientID)
                .ToList();

            retVal.AddRange(defaults.Where(a => !clientSpecifics.Any(b => b.Code == a.Code)));
            retVal.AddRange(clientSpecifics.Where(a => a.IsEnabled));

            return retVal;
        }
    }
}