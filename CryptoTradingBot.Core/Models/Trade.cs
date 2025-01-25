using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTradingBot.Infrastructure.Database.Models
{
    public class Trade
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string TradeType { get; set; } // e.g., Buy or Sell
        public DateTime TradeDate { get; set; }
    }
}
