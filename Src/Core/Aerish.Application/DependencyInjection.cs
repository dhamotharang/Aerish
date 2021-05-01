using System.Reflection;
using Aerish.Application.Commands.JobInstanceCmds;
using Aerish.Application.Common.Extensions;
using Aerish.Commands.JobInstanceCmds;
using Aerish.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using TasqR;

namespace Aerish.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, bool includeValidators = false)
        {
            services.AddTasqR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            if (includeValidators)
            {
                services.AddValidators(Assembly.GetExecutingAssembly());
            }

            return services;
        }
    }
}
