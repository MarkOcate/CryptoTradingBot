namespace CryptoTradingBot.Core.Enums.Binance
{
    /// <summary>
    /// Order Status
    /// Indicates the current status of an order.
    /// </summary>
    public enum OrderStatus
    {
        New,
        PendingNew,
        PartiallyFilled,
        Filled,
        Canceled,
        PendingCancel,
        Rejected,
        Expired,
        ExpiredInMatch
    }

}
