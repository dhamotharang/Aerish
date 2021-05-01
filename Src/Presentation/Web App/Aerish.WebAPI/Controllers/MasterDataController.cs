using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Aerish.Application.Queries.JobQrs;
using Aerish.Commands;
using Aerish.Common.Models;
using Aerish.Constants;
using Aerish.Domain.Common;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.JobQrs;
using Aerish.Queries.MasterDataQrs;
using Aerish.WebAPI.Common;

using Microsoft.AspNetCore.Mvc;

using TasqR;

namespace Aerish.WebAPI.Controllers
{
    [Route("[controller]")]
    public class MasterDataController : AerishBaseController
    {
        private readonly IAppSession p_AppSession;

        public MasterDataController(ITasqR tasqR, IAppSession appSession) : base(tasqR)
        {
            p_AppSession = appSession;
        }

        [HttpGet]
        public QueryResult<MasterDataSummaryBO> Get([FromQuery]QueryParameter requestParameter)
        {
            var personId = p_AppSession.PersonID;

            var query = TasqR.Run(new GetMasterDataQr(p_AppSession.PlanYear, personId));

            return query;
        }

        [HttpGet("CanCalculate")]
        public bool CanCalculate()
        {
            return true;
        }

        
    }
}
