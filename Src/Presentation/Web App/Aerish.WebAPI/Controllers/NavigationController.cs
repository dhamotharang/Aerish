using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Aerish.Domain.Models;
using Aerish.Queries.NavigationQrs;

using Microsoft.AspNetCore.Mvc;

using TasqR;

namespace Aerish.WebAPI.Controllers
{
    [Route("[controller]")]
    public class NavigationController : AerishBaseController
    {
        public NavigationController(ITasqR tasqR) : base(tasqR)
        {
        }

        [HttpGet]
        public async Task<NodeItemSetBO> Get
            (
                int? employeeId = null,
                string filter = null,
                string currentUri = null
            )
        {
            var navigations = await TasqR.RunAsync(new GetNavigationQr(employeeId, filter, currentUri));

            return navigations;
        }
    }
}
