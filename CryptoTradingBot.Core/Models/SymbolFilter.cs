namespace CryptoTradingBot.Core.Models
{
    /// <summary>
    /// Represents a filter for a trading pair.
    /// </summary>
    public abstract class SymbolFilter
    {
        public string FilterType { get; set; }
    }
}
