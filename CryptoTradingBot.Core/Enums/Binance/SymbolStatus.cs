namespace CryptoTradingBot.Core.Enums.Binance
{
    /// <summary>
    /// Symbol Status
    /// Represents the current trading status of a symbol
    /// </summary>
    public enum SymbolStatus
    {
        PRE_TRADING,
        TRADING,
        POST_TRADING,
        END_OF_DAY,
        HALT,
        AUCTION_MATCH,
        BREAK
    }
}
