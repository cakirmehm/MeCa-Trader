using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTrader.UI
{
    public class CTradeHistoryItem
    {
        public DateTime TradeTime { get; set; }
        public ETradeDirection Direction { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double ComissionPrice { get; set; }
        public string ComissionAsset { get; set; }


        public double TotalCostInUSDT { get; set; }

        public CTradeHistoryItem()
        {

        }

    }

    public enum ETradeDirection
    {
        BUY = 0,
        SELL = 1,
        NONE = 2
    }
}
