using System;
using System.Linq;
using Aerish.Constants;
using Aerish.Domain.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.PayRunQrs;
using Aerish.Queries.TableQrs;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TasqR;

namespace Aerish.Application.Queries.TableQrs
{
    public class GetTaxTableQrHandler : TasqHandler<GetTaxTableQr, TableBO>
    {
        private readonly ITasqR p_Processor;
        private readonly IAerishDbContext p_DbContext;
        private readonly IMemoryCache p_MemoryCache;
        private readonly IAppSession p_AppSession;
        private readonly IMapper p_Mapper;
        private string CacheKey;


        public GetTaxTableQrHandler
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

        public override TableBO Run(GetTaxTableQr request)
        {
            CacheKey = $"TaxTable_{request.PlanYear}_{request.PayRunID}";

            var table = p_MemoryCache.Get<TableBO>(CacheKey);
            var payPeriod = p_Processor.Run(new FindPayRunQr(request.PlanYear, request.PayRunID));

            if (table == null)
            {
                var query = p_DbContext.Tables
                    .AsNoTracking()
                    .Include(a => a.N_Ranges)
                    .ProjectTo<TableBO>(p_Mapper.ConfigurationProvider)
                    .Where(a => a.Code == TableCodeConstants.TaxTable
                        && (a.EffectiveStartOn < payPeriod.PayoutDate && payPeriod.PayoutDate < a.EffectiveEndOn))
                    .ToList();

                if (query.Count > 1)
                {
                    throw new AerishException("Multiple Tax table found");
                }

                table = query.SingleOrDefault();

                if (table == null)
                {
                    throw new AerishException("Tax table not configured for this planyear");
                }

                p_MemoryCache.Set(CacheKey, table);
            }

            return table;
        }
    }
}