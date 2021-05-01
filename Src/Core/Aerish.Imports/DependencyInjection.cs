using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TasqR;

namespace Aerish.Imports
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddImports(this IServiceCollection services, bool includeValidators = false)
        {
            services.AddTasqR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

           // services.AddTransient(typeof(ImportPersonCmd));


            return services;
        }
    }
}