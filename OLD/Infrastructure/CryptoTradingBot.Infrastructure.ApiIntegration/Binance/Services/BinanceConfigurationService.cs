using CryptoTradingBot.Infrastructure.ApiIntegration.Binance;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiIntegration.Binance.Services
{
    public class BinanceConfigurationService
    {
        private readonly IConfiguration _configuration;

        public BinanceConfigurationService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }

        public string GetBaseUrl() => _configuration["BinanceApi:BaseUrl"];
        public string GetApiKey() => _configuration["BinanceApi:ApiKey"];
        public string GetApiSecret() => _configuration["BinanceApi:ApiSecret"];
    }
}
