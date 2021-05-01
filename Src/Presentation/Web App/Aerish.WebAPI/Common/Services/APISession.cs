using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aerish.Constants;
using Aerish.Interfaces;

using Microsoft.AspNetCore.Http;

namespace Aerish.WebAPI.Common
{
    public class APISession : IAppSession
    {
        private readonly IHttpContextAccessor p_HttpContext;

        public APISession(IHttpContextAccessor httpContext)
        {
            p_HttpContext = httpContext;
        }

        public virtual int? PersonID
        {
            get
            {
                var personId = p_HttpContext.HttpContext.Request.Headers["PersonId"];

                if (string.IsNullOrWhiteSpace(personId))
                {
                    return null;
                }

                if (int.TryParse(personId, out int pID))
                {
                    return pID;
                }

                return null;
            }
        }

        public virtual short ClientID
        {
            get
            {
                short defaultClient = ClientConstant.Default;

                var clientId = p_HttpContext.HttpContext.Request.Headers["ClientId"];

                if (string.IsNullOrWhiteSpace(clientId))
                {
                    return defaultClient;
                }

                if (short.TryParse(clientId, out short cID))
                {
                    return cID;
                }

                return defaultClient;
            }
        }

        public short PlanYear
        {
            get
            {
                short defaultPY = (short)DateTime.Now.Year;

                var py = p_HttpContext.HttpContext.Request.Headers["PlanYear"];

                if (string.IsNullOrWhiteSpace(py))
                {
                    return defaultPY;
                }

                if (short.TryParse(py, out short pyData))
                {
                    return pyData;
                }

                return defaultPY;
            }
        }
    }
}