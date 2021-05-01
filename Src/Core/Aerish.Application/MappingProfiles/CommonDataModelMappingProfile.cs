using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Entities.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Models;

using AutoMapper;

namespace Aerish.Application.MappingProfiles
{
    public partial class CommonDataModelMappingProfile : Profile
    {
        public CommonDataModelMappingProfile()
        {
            RecognizePrefixes("N_");

            CreateMap<Client, ClientBO>();
            CreateMap<ClientBO, Client>();

            CreateMap<Job, JobBO>();
            CreateMap<JobBO, Job>();

            CreateMap<TaskHandlerProvider, TaskHandlerProviderBO>();
            CreateMap<TaskHandlerProviderBO, TaskHandlerProvider>();

            CreateMap<JobParameter, JobParameterBO>();
            CreateMap<JobParameterBO, JobParameter>();

            CreateMap<ProcessInstance, ProcessInstanceBO>();
            CreateMap<ProcessInstanceBO, ProcessInstance>();

            CreateMap<ProcessInstanceMessage, ProcessInstanceMessageBO>();

            CreateMap<ProcessInstanceError, ProcessInstanceErrorBO>();
        }
    }
}
