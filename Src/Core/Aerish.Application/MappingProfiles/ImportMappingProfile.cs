using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Application.Common.Entities.Staging;
using Aerish.Domain.Entities.Staging;
using Aerish.Domain.Models;
using Aerish.Domain.Models.Imports;

using AutoMapper;

namespace Aerish.Application.MappingProfiles
{
    public class ImportMappingProfile : Profile
    {
        public ImportMappingProfile()
        {
            RecognizePrefixes("N_");

            CreateMap<StagingPerson, StagingPersonBO>()
                .ForMember(a => a.MappingError, a => a.MapFrom(b => b.Err_UnmappedRow != null ?
                    new MappingError
                    {
                        ColumnIndex = b.Err_ColumnIndex,
                        UnmappedRow = b.Err_UnmappedRow,
                        Value = b.Err_Value
                    } : null));
            CreateMap<StagingPersonBO, StagingPerson>();

            CreateMap<StagingBasicPay, StagingBasicPayBO>()
                .ForMember(a => a.MappingError, a => a.MapFrom(b => b.Err_UnmappedRow != null ?
                    new MappingError
                    {
                        ColumnIndex = b.Err_ColumnIndex,
                        UnmappedRow = b.Err_UnmappedRow,
                        Value = b.Err_Value
                    } : null));
            CreateMap<StagingBasicPayBO, StagingBasicPay>();

            CreateMap<ValidationFailure, ValidationFailureBO>();
            CreateMap<ValidationFailureBO, ValidationFailure>();
        }
    }
}