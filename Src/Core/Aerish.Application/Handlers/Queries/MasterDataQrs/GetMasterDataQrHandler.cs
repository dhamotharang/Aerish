using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aerish.Application.Common.Extensions;
using Aerish.Common.Models;
using Aerish.Domain.Common;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.MasterDataQrs;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;

using TasqR;

namespace Aerish.Application.Handlers.Queries.MasterDataQrs
{
    public class GetMasterDataQrHandler : TasqHandler<GetMasterDataQr, QueryResult<MasterDataSummaryBO>>
    {
        private readonly IAerishDbContext p_DbContext;
        private readonly IMapper p_Mapper;

        public GetMasterDataQrHandler(IAerishDbContext dbContext, IMapper mapper)
        {
            p_DbContext = dbContext;
            p_Mapper = mapper;
        }

        public override QueryResult<MasterDataSummaryBO> Run(GetMasterDataQr request)
        {
            return p_DbContext.MasterEmployees
               .Include(a => a.N_Employee)
               .Include(a => a.N_PayRun)
               .Where(a => a.PlanYear == request.PlanYear
                   && a.EmployeeID == request.PersonId
                   && a.RecordStatus == RecordStatus.Active)
               .ProjectTo<MasterDataSummaryBO>(p_Mapper.ConfigurationProvider)
               .ApplyRequestParameter(request.QueryParameter);
        }
    }
}
