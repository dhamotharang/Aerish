using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Aerish.Common.Models;
using Aerish.Domain.Entities.Common;
using Aerish.Interfaces;
using Aerish.Queries.EmployeeQrs;
using Aerish.ViewModels;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;

using TasqR;

namespace Aerish.Application.Handlers.Queries.EmployeeQrs
{
    public class GetEmployeesQrHandler : TasqHandlerAsync<GetEmployeesQr, CollectionResult<EmployeeSummaryBO>>
    {
        public GetEmployeesQrHandler(IAerishDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public IAerishDbContext DbContext { get; }
        public IMapper Mapper { get; }

        public async override Task<CollectionResult<EmployeeSummaryBO>> RunAsync(GetEmployeesQr request, CancellationToken cancellationToken = default)
        {
            var result = new CollectionResult<EmployeeSummaryBO>();
            IQueryable<Employee> query = DbContext.Employees
                .Include(a => a.N_Person);

            result.Count = await query.CountAsync();

            switch (request.FilterField)
            {
                case EmployeeFilterField.EmployeeSysID:
                    query = query.Where(a => a.EmployeeSysID == request.Filter);
                    break;
                case EmployeeFilterField.PersonID:
                    int personId = int.Parse(request.Filter);
                    query = query.Where(a => a.N_Person.PersonID == personId);
                    break;
                case EmployeeFilterField.FullName:
                    query = query.Where(a => a.N_Person.FirstName.StartsWith(request.Filter));
                    break;
                case EmployeeFilterField.LastName:
                    break;
                case EmployeeFilterField.None:
                default:
                    break;
            }

            if (request.DataResultType == DataResultType.Summary)
            {
                result.Data = await query.ProjectTo<EmployeeSummaryBO>(Mapper.ConfigurationProvider)
                    .ToListAsync();
            }
            else
            {
                result.Data = await query.ProjectTo<EmployeeBO>(Mapper.ConfigurationProvider)
                    .ToListAsync();
            }

            return result;
        }
    }
}
