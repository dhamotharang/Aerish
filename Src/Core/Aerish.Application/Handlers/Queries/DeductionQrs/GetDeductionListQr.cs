using System.Collections.Generic;
using System.Linq;
using Aerish.Constants;
using Aerish.Domain.Common;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.DeductionQrs;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TasqR;

namespace Aerish.Application.Queries.DeductionQrs
{
    

    public class GetDeductionListQrHandler : TasqHandler<GetDeductionListQr, IEnumerable<DeductionBO>>
    {
        private string p_CacheKey = "DeductionList";

        private readonly IAerishDbContext p_DbContext;
        private readonly IMemoryCache p_MemoryCache;
        private readonly IAppSession p_AppSession;
        private readonly IMapper p_Mapper;

        public GetDeductionListQrHandler
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
        }

        public override IEnumerable<DeductionBO> Run(GetDeductionListQr process)
        {
            var retVal = p_MemoryCache.Get<IEnumerable<DeductionBO>>(p_CacheKey);

            if (retVal == null)
            {
                retVal = p_DbContext.Deductions
                    .AsNoTracking()
                    .Include(a => a.N_DeductionType)
                    .Include(a => a.N_TaskHandlerProvider)
                    .ProjectTo<DeductionBO>(p_Mapper.ConfigurationProvider)
                    .ToList();

                p_MemoryCache.Set(p_CacheKey, retVal);
            }

            return process.ClientSpecific ? GetClientSpecific(retVal) : retVal;
        }

        protected virtual IEnumerable<DeductionBO> GetClientSpecific(IEnumerable<DeductionBO> allDeductions)
        {
            var retVal = new List<DeductionBO>();

            var defaults = allDeductions
                .Where(a => a.ClientID == ClientConstant.Default)
                .ToList();

            var clientSpecifics = allDeductions
                .Where(a => a.ClientID == p_AppSession.ClientID)
                .ToList();

            retVal.AddRange(defaults.Where(a => !clientSpecifics.Any(b => b.Code == a.Code)));
            retVal.AddRange(clientSpecifics.Where(a => a.IsEnabled));

            return retVal;
        }
    }
}