using Microsoft.Extensions.DependencyInjection;
using System;
using MongoDbLib.Services;
using Microsoft.Extensions.Configuration;
using MongoDbLib;
using MongoDbConsoleApp.Logic;
using MongoDbLib.Interfaces;

namespace MongoDbConsoleApp
{
    internal static class Startup
    {

        internal static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            var configuration = CreateConfiguration();
            services.AddConfigurationSettings(configuration);

            services.AddSingleton<GameService>();
            services.AddSingleton<MongoDbTest>();

            return services;
        }

        private static IConfigurationRoot CreateConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables();
            return builder.Build();
        }

        private static void AddConfigurationSettings(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var mongoDatabaseSettings = new MongoDatabaseSettings();
            configuration.Bind("MongoDatabaseSettings", mongoDatabaseSettings);
            services.AddSingleton<IMongoDatabaseSettings>(mongoDatabaseSettings);
        }
    }
}
