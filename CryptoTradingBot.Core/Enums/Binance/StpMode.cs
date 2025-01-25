namespace CryptoTradingBot.Core.Enums.Binance
{
    /// <summary>
    /// STP (Self-Trade Prevention) Modes
    /// Indicates the modes for self-trade prevention.
    /// </summary>
    public enum StpMode
    {
        None,
        ExpireMaker,
        ExpireTaker,
        ExpireBoth
    }
}
