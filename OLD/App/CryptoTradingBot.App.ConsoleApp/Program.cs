using Microsoft.Extensions.DependencyInjection;
using CryptoTradingBot.Infrastructure.DI;
using CryptoTradingBot.Core.Interfaces;
using ApiIntegration.Binance.Services;

namespace CryptoTradingBot.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Build the DI container
            var serviceProvider = new ServiceCollection()
                .RegisterServices()
                .BuildServiceProvider();

            // Resolve and use services
            var logger = serviceProvider.GetService<ILoggingService>();
            if (logger != null)
            {
                logger.LogInformation("Console app started.");
            }
            else
            {
                Console.WriteLine("Logger service not available.");
            }

            // Example: Resolving and using another service
            var configService = serviceProvider.GetService<BinanceConfigurationService>();
            if (configService != null)
            {
                Console.WriteLine("Binance API Base URL: " + configService.GetBaseUrl());
                Console.WriteLine("Binance API Key: " + configService.GetApiKey());
            }
            else
            {
                Console.WriteLine("Configuration service not available.");
            }

            // Your main application logic here
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
