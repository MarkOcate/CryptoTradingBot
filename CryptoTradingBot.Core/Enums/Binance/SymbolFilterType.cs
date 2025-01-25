//using CryptoExchange.Net.CommonObjects;

namespace CryptoTradingBot.Core.Enums.Binance
{
    //// <summary>
    //// Filters
    //// Filters define trading rules on a symbol or an exchange.Filters come in two forms: symbol filters and exchange filters.
    //// </summary>
    public enum SymbolFilterType
    {
        PriceFilter,
        PercentPrice,
        PercentPriceBySide,
        LotSize,
        MinNotional,
        Notional,
        IcebergParts,
        MarketLotSize,
        MaxNumOrders,
        MaxNumAlgoOrders,
        MaxNumIcebergOrders,
        MaxPosition,
        TrailingDelta
    }
}
