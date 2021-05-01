using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using TasqR;

namespace Aerish.WebAPI.Controllers
{
    [ApiController]
    //[Authorize]
    public class AerishBaseController : ControllerBase
    {
        public AerishBaseController(ITasqR tasqR)
        {
            TasqR = tasqR;
        }

        public ITasqR TasqR { get; }
    }
}
