using System;

using Aerish.Application;
using Aerish.DbMigration.InMemoryDatabase;
using Aerish.Imports;
using Aerish.ImportTests.Common;
using Aerish.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aerish.ImportTests
{
    public class BaseAerishTests
    {
        protected static IServiceProvider ServiceProvider = null;
        protected static IConfiguration Configuration = null;

        [TestInitialize]
        public void TestInit()
        {
            if (ServiceProvider == null)
            {
                Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

                var services = new ServiceCollection();

                services.AddMemoryCache();
                services.AddApplication();
                services.AddImports();
                services.AddInfrastructureUseInMemory();

                services.AddScoped<IAppSession, TestAppSession>();
                services.AddScoped<IDateTime, TestDateTime>();

                ServiceProvider = services.BuildServiceProvider();
            }
        }
    }
}
