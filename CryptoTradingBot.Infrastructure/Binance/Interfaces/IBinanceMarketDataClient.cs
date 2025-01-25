namespace CryptoTradingBot.Infrastructure.Binance.Interfaces
{
    public interface IBinanceMarketDataClient
    {
        Task<IEnumerable<string>> GetExchangeInfoAsync();
        Task<decimal> GetSymbolPriceAsync(string symbol);
    }
}