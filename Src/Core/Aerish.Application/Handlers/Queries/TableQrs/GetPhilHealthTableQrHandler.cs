using Aerish.Constants;
using Aerish.Domain.Entities.Parameters;
using Aerish.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TasqR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aerish.Queries.PayRunQrs;
using Aerish.Queries.TableQrs;
using Aerish.Domain.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Aerish.Application.Queries.TableQrs
{
    
    public class GetPhilHealthTableQrHandler : TasqHandler<GetPhilHealthTableQr, TableBO>
    {

        private readonly ITasqR p_Processor;
        private readonly IAerishDbContext p_DbContext;
        private readonly IMemoryCache p_MemoryCache;
        private readonly IAppSession p_AppSession;
        private readonly IMapper p_Mapper;
        private string CacheKey;

        public GetPhilHealthTableQrHandler
            (
                ITasqR processor,
                IAerishDbContext dbContext,
                IMemoryCache memoryCache,
                IAppSession appSession,
                IMapper mapper
            )
        {
            p_Processor = processor;
            p_DbContext = dbContext;
            p_MemoryCache = memoryCache;
            p_AppSession = appSession;
            p_Mapper = mapper;
        }


        public override TableBO Run(GetPhilHealthTableQr request)
        {
            CacheKey = $"PHIC_{request.PlanYear}";
            var table = p_MemoryCache.Get<TableBO>(CacheKey);
            var payPeriod = p_Processor.Run(new FindPayRunQr(request.PlanYear, request.PayRunID));

            if (table == null)
            {
                var query = p_DbContext.Tables
                    .AsNoTracking()
                    .Include(a => a.N_Ranges)
                    .ProjectTo<TableBO>(p_Mapper.ConfigurationProvider)
                    .Where(a => a.Code == TableCodeConstants.PhilHealth
                        && (a.EffectiveStartOn <= payPeriod.CutOffEnd && payPeriod.CutOffEnd <= a.EffectiveEndOn))
                    .ToList();

                if (query.Count > 1)
                {
                    throw new AerishException("Multiple Philhealth table found");
                }

                table = query.SingleOrDefault();

                if (table == null)
                {
                    throw new AerishException("Philhealth table not configured for this planyear");
                }

                p_MemoryCache.Set(CacheKey, table);
            }

            return table;
        }
    }
}