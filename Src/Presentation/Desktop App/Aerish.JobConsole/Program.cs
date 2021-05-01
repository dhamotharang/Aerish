using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using Aerish.Application;
using Aerish.Application.Commands.MasterCmds;
using Aerish.Application.Queries.ClientQrs;
using Aerish.Application.Queries.JobQrs;
using Aerish.Commands;
using Aerish.Commands.CalcCmds;
using Aerish.Common.Models;
using Aerish.DbMigration.PostgreSQL;
using Aerish.DbMigration.SQLite;
using Aerish.DbMigration.SqlServer;
using Aerish.Domain.Common;
using Aerish.Domain.Entities.Parameters;
using Aerish.Domain.Models;
using Aerish.Imports;
using Aerish.Infrastructure;
using Aerish.Interfaces;
using Aerish.JobConsole.Common;
using Aerish.Queries.ClientQrs;
using Aerish.Queries.JobQrs;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TasqR;

namespace Aerish.JobConsole
{
    class Program
    {
        static short ClientID = 0;

        static ConsoleColor commandColor = ConsoleColor.White;
        static ConsoleColor inputColor = ConsoleColor.Gray;
        static ConsoleColor hintColor = ConsoleColor.Green;

        static void Main(string[] args)
        {
            var mainService = CreateHostBuilder(args).Build().Services;
            var mainProcessor = mainService.GetService<ITasqR>();


            mainProcessor.OnLog += (sender, proc, args) =>
            {
                Debug.WriteLine(args.Message);
            };


            Console.ForegroundColor = commandColor;
            Console.Write("Enter ClientID: ");
            Console.ForegroundColor = inputColor;

            if (!short.TryParse(Console.ReadLine(), out ClientID)) throw new AerishException("Invalid client ID parameter");
            var client = mainProcessor.Run(new GetClientQr());

            short jobID;
            do
            {
                var scopeFactory = mainService.GetService<IServiceScopeFactory>();
                using (var scope = scopeFactory.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var processor = services.GetService<ITasqR>();
                    Console.Clear();
                    jobID = -1;

                    processor.OnLog += (sender, proc, args) =>
                    {
                        Debug.WriteLine(args.Message);
                    };

                    Console.WriteLine($"Welcome to {client.Name} Test Payroll");
                    Console.WriteLine();

                    var jobList = processor.Run(new GetJobsQr());

                    foreach (var clientJob in jobList)
                    {
                        PrintJob(clientJob);
                    }

                    Console.WriteLine();

                    Console.ForegroundColor = commandColor;
                    Console.Write("Please enter Job ID (-1 to exit): ");
                    Console.ForegroundColor = inputColor;

                    string jobInputID = Console.ReadLine();


                    if (!short.TryParse(jobInputID, out jobID))
                    {
                        jobID = short.MaxValue;

                        Console.WriteLine("Invalid JobID");
                        Console.Write("Press any key to reset console.");
                        Console.ReadKey();

                        continue;
                    }

                    if (jobID < 1)
                    {
                        Console.WriteLine("Exiting..");
                        Console.Write("Press any key to close.");
                        Console.ReadKey();
                        continue;
                    }

                    var job = processor.Run(new FindJobQr(jobID));

                    if (job == null)
                    {
                        jobID = short.MaxValue;

                        Console.WriteLine("Invalid JobID");
                        Console.Write("Press any key to reset console.");
                        Console.ReadKey();

                        continue;
                    }

                    Console.WriteLine($"Job: {job.LongDesc}");

                    var parameters = new ParameterDictionary();
                    if (job.JobParameters.Any())
                    {
                        Console.WriteLine("PARAMETERS");


                        foreach (var parameter in job.JobParameters)
                        {
                            var param = new ParameterBO
                            {
                                Name = parameter.Name,
                                IsRequired = parameter.IsRequired,
                                DataType = parameter.DataType,
                                MaxLength = parameter.MaxLength
                            };

                            do
                            {
                                Console.ForegroundColor = commandColor;
                                Console.Write($"{(parameter.IsRequired ? "*" : "")}{parameter.Display} (");
                                Console.ForegroundColor = hintColor;
                                Console.Write($"{parameter.DataType}");
                                Console.ForegroundColor = commandColor;
                                Console.Write($"): ");
                                Console.ForegroundColor = inputColor;

                                param.Value = Console.ReadLine();

                                if (param.Value.Length == 0)
                                {
                                    param.Value = null;
                                }

                            } while (!param.IsValid());

                            parameters[param.Name] = param;
                        }
                    }

                    var cmd = new MasterProcessCmd(jobID, parameters);

                    var jobTracker = (IProcessTracker)processor.Run(cmd);

                    if (jobTracker.JobErrors().Any())
                    {
                        var errors = jobTracker.JobErrors();

                        if (jobTracker.Aborted == true)
                        {
                            Console.WriteLine("Job aborted with errors.");
                        }
                        else
                        {
                            Console.WriteLine("Job done with errors.");
                        }

                        Console.WriteLine("----------------");
                        foreach (var error in errors)
                        {
                            Console.WriteLine(error.Message);
                        }
                        Console.WriteLine("----------------");
                    }
                    else
                    {
                        Console.WriteLine("Job done!");
                    }

                    Console.Write("Press any key to reset console.");

                    Console.ReadKey();
                }
            } while (jobID > 0);
        }

        static void PrintJob(JobBO job)
        {
            Console.ForegroundColor = commandColor;
            Console.WriteLine($"{job.JobID}: {job.ShortDesc}");
            Console.ForegroundColor = inputColor;
        }

        static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAppSession>(provider =>
            {
                if (ClientID == 0)
                {
                    throw new AerishException("No client selected");
                }

                return new ConsoleAppSession(ClientID);
            });
            services.AddSingleton<IAppEnvironment, ConsoleAppEnvironment>();
            services.AddScoped<IDateTime, ConsoleDateTime>();

            //services.AddInfrastructureUsePostgreSQL(configuration);
            //services.AddInfrastructureUseSQLite(configuration);
            services.AddInfrastructureUseSqlServer(configuration);
            services.AddApplication();
            services.AddImports();
            //services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddTasqR(Assembly.GetExecutingAssembly());

            services.AddMemoryCache();
        }


        #region HostBuilder
        static AppServiceBuilder CreateHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var builder = new AppServiceBuilder();

            ConfigureServices(builder.Services, config);

            return builder;
        }

        class AppServiceBuilder
        {
            public ServiceCollection Services { get; } = new ServiceCollection();
            public AppServiceProvider Build() => new AppServiceProvider(Services.BuildServiceProvider());
        }

        class AppServiceProvider
        {
            public AppServiceProvider(IServiceProvider services) { Services = services; }
            public IServiceProvider Services { get; }
        }
        #endregion
    }
}
