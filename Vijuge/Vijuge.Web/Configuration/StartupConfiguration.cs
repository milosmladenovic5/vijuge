using Microsoft.EntityFrameworkCore;
using Vijuge.Data;
using Serilog;

namespace Vijuge.Web.Configuration
{
    public static class StartupConfiguration
    {
        public static IServiceCollection AddDatabaseses(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<VijugeDbContext>(/* set options */);

            return services;
        }
        

        public static IServiceCollection AddServices(this IServiceCollection services, ConfigurationManager confManager)
        {
            return services;
        }

        public static ConfigurationManager AddConfiguration(this ConfigurationManager config)
        {
            config.AddJsonFile("Config/VijgueConfig.json", optional: true, reloadOnChange: true);
            return config;
        }
    }
}
