using Binance.Net.Enums;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces;
using CryptoTradingBot.Infrastructure.Binance.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CryptoTradingBot.Infrastructure.Binance.Clients
{
    public abstract class BinanceApiClientBase : IBinanceApiClient
    {
        protected readonly HttpClient _httpClient;
        protected readonly BinanceApiConfig _config;

        public BinanceApiClientBase(HttpClient httpClient, BinanceApiConfig config)
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
