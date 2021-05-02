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
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;

namespace Aerish.Application.Queries.ClientQrs
{
    public class GetClientsQrHandler : TasqHandler<GetClientsQr, IEnumerable<ClientBO>>
    {
        protected const string CacheKey = "ClientList";
        private readonly IAerishDbContext p_DbContext;
        private readonly IMemoryCache p_MemoryCache;
        private readonly IMapper p_Mapper;

        public GetClientsQrHandler
            (
                IAerishDbContext dbContext,
                IMemoryCache memoryCache,
                IMapper mapper
            )
        {
            p_DbContext = dbContext;
            p_MemoryCache = memoryCache;
            p_Mapper = mapper;
        }

        public override IEnumerable<ClientBO> Run(GetClientsQr request)
        {
            var client = p_MemoryCache.GetOrCreate(CacheKey,
                factory => p_DbContext.Clients
                    .AsNoTracking()
                    .ProjectTo<ClientBO>(p_Mapper.ConfigurationProvider)
                    .ToArray());

            if (client.Length == 0)
            {
                throw new AerishNullReferenceException(nameof(Client), "Default Client");
            }

            return client;
        }
    }
}