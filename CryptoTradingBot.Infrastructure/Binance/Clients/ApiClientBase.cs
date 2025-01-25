using CryptoTradingBot.Core.Interfaces;
using CryptoTradingBot.Core.Models;

namespace CryptoTradingBot.Infrastructure.Binance.Clients
{
    public abstract class ApiClientBase : IBinanceApiClient
    {
        protected readonly HttpClient _httpClient;
        protected readonly BinanceApiConfig _config;

        public ApiClientBase(HttpClient httpClient, BinanceApiConfig config)
        {
            _httpClient = httpClient;
            _config = config;

            // Set the BaseAddress and other configurations dynamically
            _httpClient.BaseAddress = new Uri(_config.BaseUrl);

            // Add API key header
            if (!string.IsNullOrWhiteSpace(_config.ApiKey))
                _httpClient.DefaultRequestHeaders.Add("X-MBX-APIKEY", _config.ApiKey);
        }

        //public abstract Task<string> GetAccountInformationAsync();
        //public abstract Task<string> PlaceOrderAsync(string symbol, decimal quantity, decimal price);
    }
}
