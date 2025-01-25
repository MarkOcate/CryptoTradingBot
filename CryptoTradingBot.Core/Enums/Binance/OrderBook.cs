namespace CryptoTradingBot.Core.Enums.Binance
{
    public class OrderBook
    {
        public long LastUpdateId { get; set; }
        
        /// <summary>
        /// List of bids
        /// </summary>
        public IEnumerable<decimal> Bids { get; set; }

        /// <summary>
        /// List of asks
        /// </summary>
        public IEnumerable<decimal> Asks { get; set; }

    }
}
