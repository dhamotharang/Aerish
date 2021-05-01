using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aerish.Commands;
using Aerish.Constants;
using Aerish.Domain.Models;
using Aerish.Domain.Models.JobParameters;
using Aerish.Interfaces;

using Microsoft.AspNetCore.Mvc;

using TasqR;

namespace Aerish.WebAPI.Controllers
{
    [Route("[controller]")]
    public class JobController : AerishBaseController
    {
        private readonly IAppSession p_AppSession;

        public JobController(ITasqR tasqR, IAppSession appSession) : base(tasqR)
        {
            p_AppSession = appSession;
        }

        [HttpPost("Calculate")]
        public IProcessTrackerBase Calculate(CalculateParameter parameter)
        {
            parameter["PersonId"] = p_AppSession.PersonID?.ToString();

            var cmd = new MasterProcessCmd(MainConstants.Job.MainCalc, parameter);

            return TasqR.Run(cmd);
        }

        [HttpPost("ImportPerson")]
        public IProcessTrackerBase ImportPerson(ImportPersonParameter parameter)
        {
            var cmd = new MasterProcessCmd(MainConstants.Job.ImportPerson, parameter);

            return TasqR.Run(cmd);
        }
    }
}
