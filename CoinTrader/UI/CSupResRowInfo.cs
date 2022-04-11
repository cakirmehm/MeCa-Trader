using CoinTrader.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTrader.UI
{
    public class CSupResRowInfo
    {
        public string Symbol { get; set; }
        public double Support { get; set; }
        public double Price { get; set; }
        public double Resistance { get; set; }
        public EAction Action { get; set; }

    }
}
