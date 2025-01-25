namespace CryptoTradingBot.Core.Models
{
    public class Kline 
    {
        /// <summary>
        /// Opening time of the kline
        /// </summary>
        public DateTime OpenTime { get; set; }
        /// <summary>
        /// Price at the open time
        /// </summary>
        public decimal OpenPrice { get; set; }
        /// <summary>
        /// Highest price of the kline
        /// </summary>
        public decimal HighPrice { get; set; }
        /// <summary>
        /// Lowest price of the kline
        /// </summary>
        public decimal LowPrice { get; set; }
        /// <summary>
        /// Close price of the kline
        /// </summary>
        public decimal ClosePrice { get; set; }
        /// <summary>
        /// Volume of the kline
        /// </summary>
        public decimal Volume { get; set; }
        public DateTime CloseTime { get; set; }
        public decimal QuoteAssetVolume { get; set; }
        public int TradesCount { get; set; }
        public decimal TakerBuyBaseAssetVolume { get; set; }
        public decimal TakerBuyQuoteAssetVolume { get; set; }
        public int UnusedField { get; set; }
    }
}
