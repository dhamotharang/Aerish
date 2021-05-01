using System;
using System.IO;
using System.Reflection;

using Aerish.Infrastructure.Constants;
using Aerish.Infrastructure.Persistence;
using Aerish.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aerish.DbMigration.PostgreSQL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureUsePostgreSQL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AerishDbContext>((svc, options) =>
            {
                options.UseNpgsql
                (
                    connectionString: configuration.GetConnectionString($"{nameof(AerishDbContext)}_PostgreSQLConStr"),
                    npgsqlOptionsAction: opt =>
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