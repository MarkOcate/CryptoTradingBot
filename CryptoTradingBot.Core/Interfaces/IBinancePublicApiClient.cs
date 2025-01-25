using CryptoTradingBot.Core.Enums.Binance;
using CryptoTradingBot.Core.Models;

namespace CryptoTradingBot.Infrastructure.Binance.Interfaces
{
    public interface IBinancePublicApiClient
    {
        Task<bool> PingAsync();
        Task<DateTime> GetServerTimeAsync();
        Task<ExchangeInfo> GetExchangeInfoAsync();
        Task<OrderBook> GetOrderBookAsync(string symbol, int limit = 100);
        Task<IEnumerable<Trade>> GetRecentTradesAsync(string symbol, int limit = 500);
        Task<IEnumerable<Trade>> GetHistoricalTradesAsync(string symbol, int limit = 500, long? fromId = null);
        Task<IEnumerable<AggregateTrade>> GetAggregateTradesAsync(string symbol, int limit = 500, long? fromId = null, long? startTime = null, long? endTime = null);
        Task<IEnumerable<Kline>> GetKlinesAsync(string symbol, string interval, int limit = 500, long? startTime = null, long? endTime = null);
    }
}
