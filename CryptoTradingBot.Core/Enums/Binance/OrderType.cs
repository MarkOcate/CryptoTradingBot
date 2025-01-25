namespace CryptoTradingBot.Core.Enums.Binance
{
    /// <summary>
    /// Order Types
    /// Lists the various order types supported.
    /// </summary>
    public enum OrderType
    {
        Limit,
        Market,
        StopLoss,
        StopLossLimit,
        TakeProfit,
        TakeProfitLimit,
        LimitMaker
    }

}
