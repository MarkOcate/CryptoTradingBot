using CryptoTradingBot.Core.Interfaces;
using CryptoTradingBot.Core.Models;
using System.Net.Http.Json;

using Newtonsoft.Json.Linq;

namespace CryptoTradingBot.Infrastructure.Binance.Clients
{
    public class BinanceSpotApiClient : ApiClientBase
    {

        public BinanceSpotApiClient(HttpClient httpClient, BinanceApiConfig config) : base(httpClient, config)
        {
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
