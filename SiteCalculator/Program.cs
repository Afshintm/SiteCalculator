using System;
using Microsoft.Extensions.DependencyInjection;
using SiteCalculator.Services;

namespace SiteCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            var service = startup.Provider.GetRequiredService<InputDataProvider>();
            service.DoSomething();
            Console.ReadLine();
        }
    }
}