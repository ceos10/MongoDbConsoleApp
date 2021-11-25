using Microsoft.Extensions.DependencyInjection;
using MongoDbConsoleApp.Logic;
using System;
using System.Threading.Tasks;


namespace MongoDbConsoleApp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var services = Startup.ConfigureServices();
            var _serviceProvider = services.BuildServiceProvider();
            var mongoDbTest = _serviceProvider.GetService<MongoDbTest>();
            await mongoDbTest.TestConnection();
            Console.ReadLine();
        }
    }
}
