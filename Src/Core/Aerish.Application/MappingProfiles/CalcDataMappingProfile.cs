using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Common.Models;
using Aerish.Domain.Entities.CalcData;
using Aerish.Domain.Models;

using AutoMapper;

namespace Aerish.Application.MappingProfiles
{
    public partial class CalcDataMappingProfile : Profile
    {
        public CalcDataMappingProfile()
        {
            RecognizePrefixes("N_");

            CreateMap<MasterEmployee, MasterDataSummaryBO>();

            CreateMap<MasterEmployee, MasterDataBO>();
            CreateMap<MasterDataBO, MasterEmployee>()
                .ForMember(a => a.N_Employee, a => a.Ignore());

            CreateMap<MasterEmployeeDeduction, MasterEmployeeDeductionBO>();
            CreateMap<MasterEmployeeDeductionBO, MasterEmployeeDeduction>();

            CreateMap<MasterEmployeeEarning, MasterEmployeeEarningBO>();
            CreateMap<MasterEmployeeEarningBO, MasterEmployeeEarning>();

            CreateMap<MasterEmployeeLoan, MasterEmployeeLoanBO>();
            CreateMap<MasterEmployeeLoanBO, MasterEmployeeLoan>();
        }
    }
}
