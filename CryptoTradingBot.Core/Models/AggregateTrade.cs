namespace CryptoTradingBot.Core.Models
{
    public class AggregateTrade
    {
        // Aggregate tradeId
        public long a { get; set; }
        // Price
        public decimal p { get; set; }
        // Quantity
        public decimal q { get; set; }
        // First tradeId
        public long f { get; set; }
        // Last tradeId
        public long l { get; set; }
        // Timestamp
        public TimeSpan T { get; set; }
        // Was the buyer the maker?
        public bool m { get; set; }
        // // Was the trade the best price match?
        public bool M { get; set; }
    }
}
