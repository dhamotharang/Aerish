using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Models;

using AutoMapper;

namespace Aerish.Application.MappingProfiles
{
    public class ParameterMappingProfile : Profile
    {
        public ParameterMappingProfile()
        {
            RecognizePrefixes("N_");

            CreateMap<PlanYear, PlanYearBO>();
            CreateMap<PlanYearBO, PlanYear>();

            CreateMap<PayRun, PayRunBO>();
            CreateMap<PayRunBO, PayRun>();

            CreateMap<BasicPay, BasicPayBO>();
            CreateMap<BasicPayBO, BasicPay>();

            CreateMap<Table, TableBO>();
            CreateMap<TableBO, Table>();

            CreateMap<TableRange, TableRangeBO>();
            CreateMap<TableRangeBO, TableRange>();
        }
    }
}
