using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

using Aerish.Infrastructure.Persistence;
using Aerish.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aerish.DbMigration.SQLite
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureUseSQLite(this IServiceCollection services, IConfiguration configuration)
        {
            string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (configuration["AppDataDirectory"] != null)
            {
                appDataDirectory = configuration["AppDataDirectory"];
            }

            if (!Directory.Exists(appDataDirectory))
            {
                Directory.CreateDirectory(appDataDirectory);
            }

            string conString = $"Filename={Path.Combine(appDataDirectory, $"AerishDb_SQLite.db3")}";
            string conStringFromSettings = configuration.GetConnectionString($"{nameof(AerishDbContext)}_SQLiteConStr");

            if (!string.IsNullOrEmpty(conStringFromSettings))
            {
                conString = conStringFromSettings;
            }

            services.AddDbContext<AerishDbContext>((svc, options) =>
            {
                options.UseSqlite
                (
                    connectionString: conString,
                    sqliteOptionsAction: opt =>
                    {
                        opt.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                    }
                );
            });

            services.AddScoped<IAerishDbContext>(provider => provider.GetService<AerishDbContext>());
            services.AddScoped<DbContext>(provider => provider.GetService<AerishDbContext>());

            return services;
        }
    }
}
