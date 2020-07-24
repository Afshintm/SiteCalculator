using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiteCalculator.Services;

namespace SiteCalculator
{
    public class Startup
    {
        private IConfiguration _configuration;
        public IConfiguration Configuration => _configuration;
        
        private IServiceProvider _provider;
        public IServiceProvider Provider => _provider;
        
        public Startup()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var args = Environment.GetCommandLineArgs();

            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
            
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(_configuration);
            services.AddSingleton<InputDataProvider>();
            services.AddTransient<SiteCalculatorService>();
            _provider = services.BuildServiceProvider();
        }
    }
}