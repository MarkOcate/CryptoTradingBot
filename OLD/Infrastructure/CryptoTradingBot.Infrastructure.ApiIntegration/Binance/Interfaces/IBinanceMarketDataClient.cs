namespace CryptoTradingBot.Infrastructure.ApiIntegration.Binance.Interfaces
{
    public interface IBinanceMarketDataClient
    {
        Task<IEnumerable<string>> GetExchangeInfoAsync();
        Task<decimal> GetSymbolPriceAsync(string symbol);
    }
}