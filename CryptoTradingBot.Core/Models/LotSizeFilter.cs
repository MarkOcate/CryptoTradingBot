using System;
using System.Collections.Generic;

namespace CryptoTradingBot.Core.Models
{

    /// <summary>
    /// Represents a LOT_SIZE filter for a trading pair.
    /// </summary>
    public class LotSizeFilter : SymbolFilter
    {
        public decimal MinQty { get; set; }
        public decimal MaxQty { get; set; }
        public decimal StepSize { get; set; }
    }
}
