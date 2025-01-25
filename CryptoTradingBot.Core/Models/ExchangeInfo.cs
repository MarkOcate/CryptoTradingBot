namespace CryptoTradingBot.Core.Models
{
    /// <summary>
    /// Represents the exchange information retrieved from Binance.
    /// </summary>
    public class ExchangeInfo
    {
        public string Timezone { get; set; }
        public long ServerTime { get; set; }
        public List<RateLimit> RateLimits { get; set; }
        public List<Symbol> Symbols { get; set; }
    }
}
