using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RoboTinic.Context;
using RoboTinic.Interface;
using RoboTinic.InterfaceRepositorio;
using RoboTinic.Repositorio;
using RoboTinic.Service;
using Serilog;
using Serilog.Events;
using System;

namespace RoboTinic
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"TESTE MIGRATIONS SQLITE");
            //using (var context = new RoboContext()){}

            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, args);
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<App>().Run();


            Console.ReadLine();
        }
        private static void ConfigureServices(IServiceCollection serviceCollection, string[] args)
        {
            var configuration = new ConfigurationBuilder()
                  .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                  .AddJsonFile($"appsettings.json", false, true).Build();


            serviceCollection.AddLogging(logginBuilder =>
            {
                logginBuilder.AddConfiguration(configuration.GetSection("Logging"));
                logginBuilder.AddConsole();
                logginBuilder.AddSerilog();
                logginBuilder.AddDebug();
            });

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo.RollingFile(configuration["Serilog:LogFile"])
                .CreateLogger();

            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddSingleton<IConfiguration>(configuration);

            serviceCollection.AddTransient<App>();
            serviceCollection.AddTransient<IMaterial, MaterialService>();
            serviceCollection.AddTransient<IMaterialRepositorio, MateralRepositorio>();

        }
    }
}
