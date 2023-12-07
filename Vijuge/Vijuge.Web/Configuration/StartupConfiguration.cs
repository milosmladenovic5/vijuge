using Microsoft.EntityFrameworkCore;
using Vijuge.Data;
using Serilog;
using Vijuge.Data.Repositories.Implementation;
using Vijuge.Data.Repositories.Interface;
using Vijuge.Logic.Services.Implementation;
using Vijuge.Logic.Services.Interface;

namespace Vijuge.Web.Configuration
{
    public static class StartupConfiguration
    {
        public static IServiceCollection AddDatabaseses(this IServiceCollection services, IConfiguration config)
        {
            services.AddSqlServer<VijugeDbContext>(config.GetConnectionString("GameDatabase"), options => options.EnableRetryOnFailure());

            return services;
        }
        
        public static IServiceCollection AddServices(this IServiceCollection services, ConfigurationManager confManager)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGameService, GameService>();

            return services;
        }

        public static ConfigurationManager AddConfiguration(this ConfigurationManager config)
        {
            config.AddJsonFile("Config/VijgueConfig.json", optional: true, reloadOnChange: true);
            return config;
        }
    }
}
