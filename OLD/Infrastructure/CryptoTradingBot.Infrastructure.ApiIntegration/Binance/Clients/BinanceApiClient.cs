using CryptoTradingBot.Infrastructure.ApiIntegration.Binance;
using CryptoTradingBot.Infrastructure.ApiIntegration.Binance.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegration.Binance.Clients
{
    public class BinanceApiClient : IBinanceApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly BinanceApiConfig _config;

        public BinanceApiClient(HttpClient httpClient, BinanceApiConfig config)
        {
            _httpClient = httpClient;
            _config = config;

            // Set the BaseAddress and other configurations dynamically
            _httpClient.BaseAddress = new Uri(_config.BaseUrl);

            // Add API key header
            if (!string.IsNullOrWhiteSpace(_config.ApiKey))
                _httpClient.DefaultRequestHeaders.Add("X-MBX-APIKEY", _config.ApiKey);
        }

        // Method to test API connection
        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/v3/ping");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Connection to Binance API is successful.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Failed to connect. Status code: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while testing the connection: {ex.Message}");
                return false;
            }
        }




        public async Task<string> GetAccountInformationAsync()
        {
            var response = await _httpClient.GetAsync("/api/v3/account");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PlaceOrderAsync(string symbol, decimal quantity, decimal price)
        {
            var order = new
            {
                symbol,
                side = "BUY",
                type = "LIMIT",
                timeInForce = "GTC",
                quantity,
                price
            };

            var response = await _httpClient.PostAsJsonAsync("/api/v3/order", order);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
