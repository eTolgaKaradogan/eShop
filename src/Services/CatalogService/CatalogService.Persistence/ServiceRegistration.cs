using CatalogService.Persistence.Context;
using CatalogService.Persistence.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System;
using Polly;
using System.Runtime.CompilerServices;
using Microsoft.IdentityModel.Tokens;

namespace CatalogService.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration, WebApplication hostBuilder)
        {
            services.ConfigureDbContext(configuration);
            var s = services.Configure<CatalogSettings>(Configuration.GetCatalogSettings);


            var serviceProvider = services.BuildServiceProvider();
            var context = serviceProvider.GetService<CatalogContext>();

            hostBuilder.MigrateDbContext<CatalogContext>(context, (context, services) =>
            {
                
                var env = services.GetService<IWebHostEnvironment>();
                var logger = services.GetService<ILogger<CatalogContextSeed>>();

                new CatalogContextSeed()
                                   .SeedAsync(context, env, logger)
                                   .Wait();
            });
        }
    }
}
