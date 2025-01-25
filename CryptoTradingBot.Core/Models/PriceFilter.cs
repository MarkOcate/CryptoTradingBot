namespace CryptoTradingBot.Core.Models
{
    /// <summary>
    /// Represents a PRICE_FILTER for a trading pair.
    /// </summary>
    public class PriceFilter : SymbolFilter
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal TickSize { get; set; }
    }
}
