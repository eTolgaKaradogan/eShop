using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Persistence
{
    static class Configuration
    {
        public static string GetConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../CatalogService/CatalogService.api"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("ConnectionString");
            }
        }

        public static IConfigurationSection GetCatalogSettings
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../CatalogService/CatalogService.api"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetSection("CatalogSettings");
            }
        }
    }
}
