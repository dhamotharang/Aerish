using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aerish.Domain.Common;
using Aerish.Domain.Models;
using Aerish.Queries.MasterDataQrs;
using Aerish.Queries.PlanYearQrs;
using Aerish.WebAPI.Common;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using TasqR;

namespace Aerish.WebAPI.Controllers
{
    [Route("[controller]")]
    public class PlanYearController : AerishBaseController
    {
        public PlanYearController(ITasqR tasqR) : base(tasqR)
        {

        }

        [HttpGet]
        public QueryResult<PlanYearBO> Get([FromQuery] QueryParameter requestParameter)
        {
            return TasqR.Run(new GetPlanYearQr(requestParameter));
        }
    }
}