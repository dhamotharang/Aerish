using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Aerish.Infrastructure.Constants;
using Aerish.Infrastructure.Persistence;
using Aerish.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Aerish.DbMigration.SqlServer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureUseSqlServer
            (
                this IServiceCollection services,
                IConfiguration configuration,
                ILoggerFactory loggerFactory = null
            )
        {
            services.AddDbContext<AerishDbContext>((svc, options) =>
            {
                options.UseSqlServer
                (
                    connectionString: configuration.GetConnectionString($"{nameof(AerishDbContext)}_MSSQLConStr"),
                    sqlServerOptionsAction: opt =>
                    {
                        opt.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                        opt.MigrationsHistoryTable("MigrationHistory", SchemaConstant.Admin);
                    }
                );
            });

            services.AddScoped<IAerishDbContext>(provider => provider.GetService<AerishDbContext>());
            services.AddScoped<DbContext>(provider => provider.GetService<AerishDbContext>());

            return services;
        }
    }
}
