using System.Reflection;

namespace CryptoTradingBot.Core.Models
{
    public class Trade
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal qty { get; set; }
        public decimal quoteQty { get; set; }
        public DateTime time { get; set; }
        public bool isBuyerMaker { get; set; }
        public bool isBestMatch { get; set; }
    }
}
