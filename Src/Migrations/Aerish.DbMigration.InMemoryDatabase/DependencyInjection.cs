using System;

using Aerish.Infrastructure.Persistence;
using Aerish.Infrastructure.Persistence.Configurations;
using Aerish.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Aerish.DbMigration.InMemoryDatabase
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureUseInMemory(this IServiceCollection services)
        {
            services.AddDbContext<AerishDbContext>((svc, options) =>
            {
                options.UseInMemoryDatabase($"Test:{Guid.NewGuid().ToString().Substring(0, 8)}");
                options.ConfigureWarnings(a => a.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            services.AddScoped<IAerishDbContext>(provider => provider.GetService<AerishDbContext>().LoadSeeds());
            services.AddScoped<DbContext>(provider => provider.GetService<AerishDbContext>().LoadSeeds());

            return services;
        }

        private static AerishDbContext LoadSeeds(this AerishDbContext dbContext)
        {
            if (dbContext.HasSeedData)
            {
                return dbContext;
            }

            new Job_Configuration().LoadSeedDataTo(dbContext.Jobs);
            new JobParameter_Configuration().LoadSeedDataTo(dbContext.JobParameters);

            dbContext.SaveChanges();

            dbContext.HasSeedData = true;

            return dbContext;
        }
    }    
}