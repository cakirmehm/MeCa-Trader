using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTrader.Source
{
    public class CSymbolTicker
    {
     
        public string symbol { get; set; }
        public double support { get; set; }
        public double currentPrice { get; set; }
        public double resistance { get; set; }

        public double priceChangePercent { get; set; }

        [Browsable(false)]
        public double priceChange { get; set; }

        [Browsable(false)]
        public double weightedAvgPrice { get; set; }

        public double prevClosePrice { get; set; }

        [Browsable(false)]
        public double lastPrice { get; set; }
        

        [Browsable(false)]
        public double lastQty { get; set; }

        [Browsable(false)]
        public double bidPrice { get; set; }

        [Browsable(false)]
        public double bidQty { get; set; }

        [Browsable(false)]
        public double askPrice { get; set; }

        [Browsable(false)]
        public double askQty { get; set; }

        [Browsable(false)]
        public double openPrice { get; set; }


        public double highPrice { get; set; }
        public double lowPrice { get; set; }
        public double volume { get; set; }
        public double quoteVolume { get; set; }

        [Browsable(false)]
        public long openTime { get; set; }

        [Browsable(false)]
        public long closeTime { get; set; }

        [Browsable(false)]
        public long firstId { get; set; }

        [Browsable(false)]
        public long lastId { get; set; }

        public long count { get; set; }


    }
}
