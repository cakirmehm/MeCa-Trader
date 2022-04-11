using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTrader.UI
{
    public class CTradeItem
    {
        public string TradeId { get; }
        public string Symbol { get; set; }
        public ETradeDirection TradeType { get; set; }
        public double PriceInUSDT { get; set; }
        public double Amount { get; set; }
        public double TargetPrice { get; set; }
        public ETradeDirection TargetTradeType { get; set; }
        public double Stop { get; set; }
        public double Limit { get; set; }

        public CTradeItem()
        {
            TradeId = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }
    }
}
