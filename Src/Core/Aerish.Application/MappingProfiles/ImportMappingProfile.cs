using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Entities.Staging;
using Aerish.Domain.Models;

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

            CreateMap<ValidationFailure, ValidationFailureBO>();
            CreateMap<ValidationFailureBO, ValidationFailure>();
        }
    }
}