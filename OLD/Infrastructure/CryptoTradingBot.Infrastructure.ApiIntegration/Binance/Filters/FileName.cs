using Binance.Net.Enums;

namespace CryptoTradingBot.Infrastructure.ApiIntegration.Binance.Filters
{
    /// <summary>
    /// Base class for all symbol filters.
    /// </summary>
    public abstract class SymbolFilter
    {
        public SymbolFilterType FilterType { get; set; }
    }

    /// <summary>
    /// Represents the PRICE_FILTER.
    /// </summary>
    public class PriceFilter : SymbolFilter
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal TickSize { get; set; }
    }

    /// <summary>
    /// Represents the PERCENT_PRICE filter.
    /// </summary>
    public class PercentPriceFilter : SymbolFilter
    {
        public decimal MultiplierUp { get; set; }
        public decimal MultiplierDown { get; set; }
        public int AvgPriceMins { get; set; }
    }

    /// <summary>
    /// Represents the LOT_SIZE filter.
    /// </summary>
    public class LotSizeFilter : SymbolFilter
    {
        public decimal MinQty { get; set; }
        public decimal MaxQty { get; set; }
        public decimal StepSize { get; set; }
    }

    // Define other filter classes similarly...
}
