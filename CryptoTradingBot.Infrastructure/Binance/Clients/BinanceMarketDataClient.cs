using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoTradingBot.Infrastructure.Binance.Interfaces;
using Newtonsoft.Json.Linq;

namespace CryptoTradingBot.Infrastructure.Binance.Clients
{
    public class BinanceMarketDataClient : IBinanceMarketDataClient
    {
        private readonly HttpClient _httpClient;

        public BinanceMarketDataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.binance.com");
        }

        public async Task<IEnumerable<string>> GetExchangeInfoAsync()
        {
            var response = await _httpClient.GetAsync("/api/v3/exchangeInfo");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(content);

            var symbols = jsonObject["symbols"];
            var symbolList = new List<string>();

            foreach (var symbol in symbols)
            {
                symbolList.Add(symbol["symbol"].ToString());
            }

            return symbolList;
        }

        public async Task<decimal> GetSymbolPriceAsync(string symbol)
        {
            var response = await _httpClient.GetAsync($"/api/v3/ticker/price?symbol={symbol}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(content);

            return decimal.Parse(jsonObject["price"].ToString());
        }
    }
}
