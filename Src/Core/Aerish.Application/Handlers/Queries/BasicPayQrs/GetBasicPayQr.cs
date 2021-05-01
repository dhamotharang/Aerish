using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.BasicPayQrs;
using Aerish.Queries.PayRunQrs;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;
using TasqR;

namespace Aerish.Application.Queries.BasicPayQrs
{
    public class GetBasicPayQrHandler : TasqHandlerAsync<GetBasicPayQr, BasicPayBO>
    {
        private readonly IAerishDbContext p_DbContext;
        private readonly IAppSession p_AppSession;
        private readonly ITasqR p_Processor;
        private readonly IMapper p_Mapper;

        public GetBasicPayQrHandler
            (
                IAerishDbContext dbContext,
                IAppSession appSession,
                ITasqR processor,
                IMapper mapper
            )
        {
            p_DbContext = dbContext;
            p_AppSession = appSession;
            p_Processor = processor;
            p_Mapper = mapper;
        }


        public async override Task<BasicPayBO> RunAsync(GetBasicPayQr request, CancellationToken cancellationToken = default)
        {
            var payRun = await p_Processor.RunAsync(new FindPayRunQr(request.PlanYear, request.PayPeriodID));

            var basicPays = await p_DbContext.BasicPays
                .AsNoTracking()
                .Include(a => a.N_PeriodStart)
                .Where(a => a.ClientID == p_AppSession.ClientID
                        && a.EmployeeID == request.EmployeeID
                        && a.Effectivity < payRun.PeriodStart)
                .ProjectTo<BasicPayBO>(p_Mapper.ConfigurationProvider)
                .OrderByDescending(a => a.Effectivity)
                .ToListAsync();

            if (basicPays.Count == 0)
            {
                throw new AerishObjectNotFoundException<BasicPay>(new
                {
                    p_AppSession.ClientID,
                    request.EmployeeID
                });
            }

            return basicPays.FirstOrDefault();

        }
    }
}
