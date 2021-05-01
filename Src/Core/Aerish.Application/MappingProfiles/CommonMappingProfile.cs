using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Entities.Common;
using Aerish.Domain.Models;
using Aerish.ViewModels;

using AutoMapper;

namespace Aerish.Application.MappingProfiles
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
            RecognizePrefixes("N_");

            CreateMap<Employee, EmployeeBO>();
            CreateMap<EmployeeBO, Employee>();

            CreateMap<Earning, EarningBO>();
            CreateMap<EarningBO, Earning>();

            CreateMap<Deduction, DeductionBO>();
            CreateMap<DeductionBO, Deduction>();

            CreateMap<DeductionType, DeductionTypeBO>();
            CreateMap<DeductionTypeBO, DeductionType>();

            CreateMap<Loan, LoanBO>();
            CreateMap<LoanBO, Loan>();

            CreateMap<LoanType, LoanTypeBO>();
            CreateMap<LoanTypeBO, LoanType>();
        }
    }
}
