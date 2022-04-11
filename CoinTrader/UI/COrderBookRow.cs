using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTrader.UI
{
    public class COrderBookRow
    {
        [Browsable(false)]
        public string SymbolPair { get; set; }

        public double BidAmount { get; set; }
        public double BidPrice { get; set; }
        public double AskPrice { get; set; }
        public double AskAmount { get; set; }
    }
}
