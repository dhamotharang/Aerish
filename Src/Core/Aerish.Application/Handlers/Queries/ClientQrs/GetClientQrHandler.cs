using Aerish.Domain.Entities.Common;
using Aerish.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TasqR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aerish.Domain.Models;
using Aerish.Queries.ClientQrs;
using AutoMapper;

namespace Aerish.Application.Queries.ClientQrs
{
    public class GetClientQrHandler : TasqHandler<GetClientQr, ClientBO>
    {
        protected const string CacheKey = "ClientSession";
        private readonly IAerishDbContext p_DbContext;
        private readonly IAppSession p_AppSession;
        private readonly IMemoryCache p_MemoryCache;
        private readonly IMapper p_Mapper;

        public GetClientQrHandler
            (
                IAerishDbContext dbContext,
                IAppSession appSession,
                IMemoryCache memoryCache,
                IMapper mapper
            )
        {
            p_DbContext = dbContext;
            p_AppSession = appSession;
            p_MemoryCache = memoryCache;
            p_Mapper = mapper;
        }

        public override ClientBO Run(GetClientQr request)
        {
            var retVal = p_MemoryCache.Get<ClientBO>(CacheKey);

            if (retVal == null)
            {
                var client = p_DbContext.Clients
                    .AsNoTracking()
                    .FirstOrDefault(a => a.ClientID == p_AppSession.ClientID);

                if (client != null)
                {
                    retVal = p_Mapper.Map<ClientBO>(client);
                    p_MemoryCache.Set(CacheKey, retVal);
                }
            }

            if (retVal == null)
            {
                throw new AerishNullReferenceException(nameof(Client), "Default Client");
            }

            return retVal;
        }
    }
}