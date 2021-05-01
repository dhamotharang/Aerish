using Aerish.Application.Common.Models;
using Aerish.Common.Models;
using Aerish.Domain.Common;
using Aerish.Domain.Entities.CalcData;
using Aerish.Interfaces;
using Aerish.Queries.MasterDataQrs;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TasqR;

namespace Aerish.Application.Queries.MasterDataQrs
{
    public class GetPreviousMasterDataQrHandler : TasqHandler<GetPreviousMasterDataQr, MasterDataBO>
    {
        private readonly IAerishDbContext p_DbContext;
        private readonly IMapper p_Mapper;

        public GetPreviousMasterDataQrHandler(IAerishDbContext dbContext, IMapper mapper)
        {
            this.p_DbContext = dbContext;
            this.p_Mapper = mapper;
        }

        public override MasterDataBO Run(GetPreviousMasterDataQr request)
        {
            var query = p_DbContext.MasterEmployees
               .Include(a => a.N_Employee)
               .Include(a => a.N_MasterEmployeeDeductions
                    .Where(d => d.RecordStatus == RecordStatus.Active))
               .Include(a => a.N_MasterEmployeeEarnings
                    .Where(e => e.RecordStatus == RecordStatus.Active))
               .Where(a => a.PlanYear == request.PlanYear
                   && a.PayRunID == request.PayPeriodID
                   && a.EmployeeID == request.EmployeeID
                   && a.RecordStatus == RecordStatus.Active);

            var masterDataResult = query.SingleOrDefault();

            if (masterDataResult == null)
            {
                return null;
            }

            return p_Mapper.Map<MasterDataBO>(masterDataResult);
        }
    }
}