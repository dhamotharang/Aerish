using Aerish.Admin.Client.Services;
using Aerish.Admin.Shared;

using Blazored.LocalStorage;
using Blazored.SessionStorage;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using TasqR;

namespace Aerish.Admin.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(provider =>
            {
                return new AdminAppSession
                (
                    provider.GetService<ISessionStorageService>(),
                    provider.GetService<ILocalStorageService>(),
                    1
                );
            });

            builder.Services.AddScoped(sp => new HttpClient
            {
                //BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
                BaseAddress = new Uri("https://localhost:44322/")
            });

            builder.Services.AddScoped(provider => new DataService
                (
                    provider.GetService<HttpClient>(), 
                    provider.GetService<AdminAppSession>()
                ));
            

            builder.Services.AddTelerikBlazor();
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddTasqR(Assembly.GetExecutingAssembly());

            await builder.Build().RunAsync();
        }
    }
}
