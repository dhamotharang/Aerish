using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aerish.Domain.Common;
using Aerish.Domain.Models;
using Aerish.Queries.PayRunQrs;

using Microsoft.AspNetCore.Mvc;

using TasqR;

namespace Aerish.WebAPI.Controllers
{
    [Route("[controller]")]
    public class PayRunController : AerishBaseController
    {
        public PayRunController(ITasqR tasqR) : base(tasqR)
        {
        }

        [HttpGet]
        public QueryResult<PayRunBO> Get([FromQuery] QueryParameter requestParameter)
        {
            short planYear = requestParameter.GetFromFilter<short>("PlanYear");

            var query = TasqR.Run(new GetPayRunQr(planYear));

            return query;
        }
    }
}
