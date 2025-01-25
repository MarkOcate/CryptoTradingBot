namespace CryptoTradingBot.Core.Enums.Binance
{
    /// <summary>
    /// Time in Force
    /// Represents the time in force policies for orders.
    /// </summary>
    public enum TimeInForce
    {
        Gtc, /// Good Till Cancelled
        Ioc, /// Immediate Or Cancel
        Fok  /// Fill Or Kill
    }

}
