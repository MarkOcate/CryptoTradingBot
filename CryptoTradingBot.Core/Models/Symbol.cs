namespace CryptoTradingBot.Core.Models
{
    /// <summary>
    /// Represents the details of a symbol/trading pair.
    /// </summary>
    public class Symbol
    {
        public string SymbolName { get; set; }
        public string Status { get; set; }
        public string BaseAsset { get; set; }
        public int BaseAssetPrecision { get; set; }
        public string QuoteAsset { get; set; }
        public int QuotePrecision { get; set; }
        public int QuoteAssetPrecision { get; set; }
        public int BaseCommissionPrecision { get; set; }
        public int QuoteCommissionPrecision { get; set; }
        public List<string> OrderTypes { get; set; }
        public bool IcebergAllowed { get; set; }
        public bool OcoAllowed { get; set; }
        public bool QuoteOrderQtyMarketAllowed { get; set; }
        public bool IsSpotTradingAllowed { get; set; }
        public bool IsMarginTradingAllowed { get; set; }
        public List<SymbolFilter> Filters { get; set; }
        public List<string> Permissions { get; set; }
    }
}
