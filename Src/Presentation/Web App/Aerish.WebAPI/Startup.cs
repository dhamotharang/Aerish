using Aerish.DbMigration.SqlServer;
using Aerish.Interfaces;
using Aerish.WebAPI.Common;
using Aerish.Application;
using Aerish.Imports;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasqR;
using System.Reflection;
using System.Net.Http;
using Aerish.Domain.Models;
using Aerish.WebAPI.Middlewares;
using Microsoft.AspNetCore.Http;

namespace Aerish.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<IAppSession>(provider =>
            {
                var ctxAccessor = provider.GetService<IHttpContextAccessor>();

                return new APISession(ctxAccessor);
            });

            services.AddSingleton<IAppEnvironment, APIEnvironment>();
            services.AddScoped<IDateTime, APIDateTime>();

            //services.AddInfrastructureUsePostgreSQL(Configuration);
            //services.AddInfrastructureUseSQLite(Configuration);
            services.AddInfrastructureUseSqlServer(Configuration);
            services.AddApplication();
            services.AddImports();
            //services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddTasqR(Assembly.GetExecutingAssembly());

            services.AddMemoryCache();


            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aerish.WebAPI", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aerish.WebAPI v1");
                    c.DefaultModelsExpandDepth(-1);
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<MockDelayResponseMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}