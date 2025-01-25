using CryptoTradingBot.Core.Enums.Binance;
using CryptoTradingBot.Core.Models;
using CryptoTradingBot.Core.Interfaces;
using Newtonsoft.Json;
using OrderBook = CryptoTradingBot.Core.Enums.Binance.OrderBook;
using SymbolStatus = CryptoTradingBot.Core.Enums.Binance.SymbolStatus;
using Trade = CryptoTradingBot.Core.Models.Trade;
using Kline = CryptoTradingBot.Core.Models.Kline;

namespace CryptoTradingBot.Infrastructure.Binance.Clients
{
    /// <summary>
    /// Market Data
    /// Handles public endpoints that fetch market-related data.
    /// </summary>
    public class MarketDataClient : ApiClientBase, IMarketDataClient
    {
        public MarketDataClient(HttpClient httpClient, BinanceApiConfig config) : base(httpClient, config) { }

        /// <summary>
        /// Test connectivity
        /// </summary>
        /// <returns>Response: {}</returns>
        public async Task<bool> PingAsync()
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

        /// <summary>
        /// Check server time
        /// </summary>
        /// <returns>Response: { "serverTime": 1499827319559 }</returns>
        public async Task<DateTime> GetServerTimeAsync()
        {
            var response = await _httpClient.GetAsync("/api/v3/time");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DateTime>(content);
        }

        /// <summary>
        /// Current exchange trading rules and symbol information
        /// </summary>
        /// <returns>ExchangeInfo</returns>
        public async Task<ExchangeInfo> GetExchangeInfoAsync(string? symbol, string[]? symbols, Permission? permission, bool? showPermissionSets = true, SymbolStatus? symbolStatus = null)
        {
            var response = await _httpClient.GetAsync("/api/v3/exchangeInfo");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ExchangeInfo>(content);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="limit">Default 100; max 5000. /r/nIf limit > 5000. then the response will truncate to 5000.</param>
        /// <returns></returns>
        public async Task<OrderBook> GetOrderBookAsync(string symbol, int? limit = 100)
        {
            var response = await _httpClient.GetAsync($"/api/v3/depth?symbol={symbol}&limit={limit}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OrderBook>(content);
        }

        /// <summary>
        /// Get recent trades.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Trade>> GetRecentTradesAsync(string symbol, int? limit = 500)
        {
            var response = await _httpClient.GetAsync($"/api/v3/trades?symbol={symbol}&limit={limit}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Trade>>(content);
        }

        /// <summary>
        /// Get older trades
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="fromId">TradeId to fetch from. Default gets most recent trades.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Trade>> GetHistoricalTradesAsync(string symbol, int? limit = 500, long? fromId = null)
        {
            var url = $"/api/v3/historicalTrades?symbol={symbol}&limit={limit}";
            if (fromId.HasValue)
                url += $"&fromId={fromId.Value}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Trade>>(content);
        }

        /// <summary>
        /// Compressed/Aggregate trades list
        /// Get compressed, aggregate trades. Trades that fill at the time, from the same taker order, with the same price will have the quantity aggregated.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="limit">ID to get aggregate trades from INCLUSIVE.</param>
        /// <param name="fromId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AggregateTrade>> GetAggregateTradesAsync(string symbol, int? limit = 500, long? fromId = null, long? startTime = null, long? endTime = null)
        {
            var url = $"/api/v3/aggTrades?symbol={symbol}&limit={limit}";

            if (fromId.HasValue)
                url += $"&fromId={fromId.Value}";
            if (startTime.HasValue)
                url += $"&startTime={startTime.Value}";
            if (endTime.HasValue)
                url += $"&endTime={endTime.Value}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<AggregateTrade>>(content);
        }

        public async Task<IEnumerable<Kline>> GetKlinesAsync(string symbol, string interval, int limit = 500, long? startTime = null, long? endTime = null)
        {
            var url = $"/api/v3/klines?symbol={symbol}&interval={interval}&limit={limit}";
            if (startTime.HasValue)
                url += $"&startTime={startTime.Value}";
            if (endTime.HasValue)
                url += $"&endTime={endTime.Value}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Kline>>(content);
        }
    }
}
