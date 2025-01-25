using CryptoTradingBot.Infrastructure.ApiIntegration.Binance.Interfaces;

namespace CryptoTradingBot.Application.Services
{
    public class MarketDataService
    {
        private readonly IBinanceMarketDataClient _marketDataClient;

        public MarketDataService(IBinanceMarketDataClient marketDataClient)
        {
            _marketDataClient = marketDataClient;
        }

        public async Task<IEnumerable<string>> GetAvailableSymbolsAsync()
        {
            return await _marketDataClient.GetExchangeInfoAsync();
        }

        public async Task<decimal> GetSymbolPriceAsync(string symbol)
        {
            return await _marketDataClient.GetSymbolPriceAsync(symbol);
        }
    }
}
