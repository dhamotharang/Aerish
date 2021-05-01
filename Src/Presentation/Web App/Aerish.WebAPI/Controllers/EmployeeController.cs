using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Aerish.Domain.Common;
using Aerish.Queries.EmployeeQrs;
using Aerish.ViewModels;
using Aerish.WebAPI.Common;

using Microsoft.AspNetCore.Mvc;

using TasqR;

namespace Aerish.WebAPI.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : AerishBaseController
    {
        public EmployeeController(ITasqR tasqR) : base(tasqR)
        {
        }

        [HttpGet("/Employee/Search")]
        public async Task<QueryResult<EmployeeSummaryBO>> Search([FromQuery] QueryParameter requestParameter, CancellationToken cancellationToken = default)
        {
            var result = await TasqR.RunAsync(new GetEmployeesQr(requestParameter.Filter.Value, DataResultType.Summary), cancellationToken);

            return new QueryResult<EmployeeSummaryBO>
            {
                Count = result.Count,
                Data = result.Data
            };
        }
    }
}
