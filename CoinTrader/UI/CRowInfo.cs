using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTrader.UI
{
    public class CRowInfo
    {
        public string Symbol { get; set; }
        public double Price { get; set; }

        [Browsable(false)]
        public double Volume_1h { get; set; }
        public double Volume_24h { get; set; }
        public double Volume_7d { get; set; }
        public double Volume_30d { get; set; }

        [Browsable(false)]
        public double Percent_Change_1h { get; set; }
        public double Percent_Change_24h { get; set; }
        public double Percent_Change_7d { get; set; }
        public double Percent_Change_30d { get; set; }

        [Browsable(false)]
        public double Open_Price { get; set; }

        [Browsable(false)]
        public double High_Price { get; set; }

        [Browsable(false)]
        public double Low_Price { get; set; }

        [Browsable(false)]
        public double Close_Price { get; set; }

    }
}
