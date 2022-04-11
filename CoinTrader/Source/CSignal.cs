using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTrader.Source
{
    public class CSignal
    {
        public string Symbol { get; set; }
        public EAction Action { get; set; }
        public EIndicator Indicator { get; set; }
        public string Description { get; set; }
    }

    public enum EAction
    {
        HOLD,
        BUY,
        SELL,
        STRONG_BUY,
        STRONG_SELL
    }

    public enum EIndicator
    {
        NONE,
        MA,
        EMA,
        RSI,
        MACD,
        BOLL
    }
}
