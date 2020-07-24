using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SiteCalculator.Services;

namespace SiteCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                var startup = new Startup();
                var dataProvider = startup.Provider.GetRequiredService<InputDataProvider>();
                var siteCalculatorService = startup.Provider.GetRequiredService<SiteCalculatorService>();
                
                if(args.All(string.IsNullOrEmpty))
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Site Metrics Calculator");
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("===================               Usage:               =============================");
                    Console.WriteLine("You can pass an array of json objects in a json file as input parameters:");
                    Console.WriteLine(" SiteCalculator <InputFile>");
                    Console.WriteLine("====================================================================================");
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine(Environment.NewLine);
                    
                    Console.WriteLine("Please enter the input Json including site details:");
                    var jsonInput = Console.ReadLine();
                    
                    var inputModel = dataProvider.GetData(jsonInput);
                    
                    var output = siteCalculatorService.CalculateMetrics(inputModel);

                    Console.WriteLine(JsonConvert.SerializeObject(output, Formatting.Indented));
                }
                else
                {
                    var inputFile = args[0];
                    var inputModels = dataProvider.GetInputDataFromFile(inputFile).Result;
                    var results = siteCalculatorService.CalculateMetrics(inputModels);
                    foreach (var item in results)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(item, Formatting.Indented));
                        Console.Write(",");
                    }
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ;
            }
        }
    }
}