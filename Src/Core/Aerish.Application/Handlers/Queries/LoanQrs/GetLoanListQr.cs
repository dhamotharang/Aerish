using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerish.Constants;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.LoanQrs;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TasqR;

namespace Aerish.Application.Queries.LoanQrs
{
    

    public class GetLoanListQrHandler : TasqHandler<GetLoanListQr, IEnumerable<LoanBO>>
    {
        private string p_CacheKey = "LoanList";

        private readonly IAerishDbContext p_DbContext;
        private readonly IMemoryCache p_MemoryCache;
        private readonly IAppSession p_AppSession;
        private readonly IMapper p_Mapper;

        public GetLoanListQrHandler
            (
                IAerishDbContext dbContext,
                IMemoryCache memoryCache,
                IAppSession appSession,
                IMapper mapper
            )
        {
            this.p_DbContext = dbContext;
            this.p_MemoryCache = memoryCache;
            p_AppSession = appSession;
            p_Mapper = mapper;
        }

        public override IEnumerable<LoanBO> Run(GetLoanListQr request)
        {
            var retVal = p_MemoryCache.Get<IEnumerable<LoanBO>>(p_CacheKey);

            if (retVal == null)
            {
                retVal = p_DbContext.Loans
                    .AsNoTracking()
                    .Include(a => a.N_TaskHandlerProvider)
                    .Include(a => a.N_LoanType)
                    .ProjectTo<LoanBO>(p_Mapper.ConfigurationProvider)
                    .ToList();

                p_MemoryCache.Set(p_CacheKey, retVal);
            }

            return request.ClientSpecific ? GetClientSpecific(retVal) : retVal;
        }

        protected virtual IEnumerable<LoanBO> GetClientSpecific(IEnumerable<LoanBO> allLoans)
        {
            var retVal = new List<LoanBO>();

            var defaults = allLoans
                .Where(a => a.ClientID == ClientConstant.Default)
                .ToList();

            var clientSpecifics = allLoans
                .Where(a => a.ClientID == p_AppSession.ClientID)
                .ToList();

            retVal.AddRange(defaults.Where(a => !clientSpecifics.Any(b => b.Code == a.Code)));
            retVal.AddRange(clientSpecifics.Where(a => a.IsEnabled));

            return retVal;
        }
    }
}
