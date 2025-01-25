using CryptoTradingBot.Core.Enums.Binance;
using CryptoTradingBot.Core.Models;

namespace CryptoTradingBot.Core.Interfaces
{
    public interface IMarketDataClient
    {
        Task<bool> PingAsync();
        Task<DateTime> GetServerTimeAsync();
        Task<ExchangeInfo> GetExchangeInfoAsync(string? symbol, string[]? symbols, Permission? permission, bool? showPermissionSets = true, SymbolStatus? symbolStatus = null);
        Task<OrderBook> GetOrderBookAsync(string symbol, int? limit = 100);
        Task<IEnumerable<Trade>> GetRecentTradesAsync(string symbol, int? limit = 500);
        Task<IEnumerable<Trade>> GetHistoricalTradesAsync(string symbol, int? limit = 500, long? fromId = null);
        Task<IEnumerable<AggregateTrade>> GetAggregateTradesAsync(string symbol, int? limit = 500, long? fromId = null, long? startTime = null, long? endTime = null);
        Task<IEnumerable<Kline>> GetKlinesAsync(string symbol, string interval, int limit = 500, long? startTime = null, long? endTime = null);
    }
}