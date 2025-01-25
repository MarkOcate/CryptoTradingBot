namespace CryptoTradingBot.Core.Enums.Binance
{
    /// <summary>
    /// Symbol Status
    /// Represents the current trading status of a symbol
    /// </summary>
    public enum SymbolStatus
    {
        PreTrading,
        Trading,
        PostTrading,
        EndOfDay,
        Halt,
        AuctionMatch,
        Break
    }

}
