using Aerish.Constants;
using Aerish.Domain.Common;
using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Models;
using Aerish.Interfaces;
using Aerish.Queries.EarningQrs;

using AutoMapper;

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TasqR;

namespace Aerish.Application.Queries.EarningQrs
{
   

    public class GetEarningQrHandler : TasqHandler<GetEarningQr, EarningBO>
    {
        private readonly ITasqR p_Processor;
        private readonly IAppSession p_AppSession;
        private readonly IMapper p_Mapper;

        public GetEarningQrHandler
            (
                ITasqR processor,
                IAppSession appSession,
                IMapper mapper
            )
        {
            p_Processor = processor;
            p_AppSession = appSession;
            p_Mapper = mapper;
        }

        public override EarningBO Run(GetEarningQr request)
        {
            var earnings = p_Processor.Run(new GetEarningListQr());

            var earning = earnings
                    .Where(a => a.Code == request.EarningCode
                        && (
                            (a.ClientID == p_AppSession.ClientID && a.IsEnabled)
                            || a.ClientID == ClientConstant.Default
                           )
                        )
                    .OrderByDescending(a => a.ClientID);

            return earning.FirstOrDefault();
        }
    }
}