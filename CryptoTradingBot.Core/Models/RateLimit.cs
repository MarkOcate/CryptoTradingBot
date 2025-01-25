namespace CryptoTradingBot.Core.Models
{
    /// <summary>
    /// Represents the rate limit details of the exchange.
    /// </summary>
    public class RateLimit
    {
        public string RateLimitType { get; set; }
        public string Interval { get; set; }
        public int IntervalNum { get; set; }
        public int Limit { get; set; }
    }
}
