using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTrader.UI
{
    public enum ESignalReason
    {
        [Description("YOK")]
        NONE = 0,

        [Description("Balina Alarmı!")]
        WHALE_ALERT,

        [Description("Bitcoin Çakılıyor!")]
        BITCOIN_CRASH_ALERT,

        [Description("Bitcoin Ani Yükseldi!")]
        BITCOIN_PUMP_ALERT,

        [Description("SAT: Dirence yaklaşıldı.")]
        RESISTANCE_WARNING,

        [Description("AL: Desteğe yaklaşıldı.")]
        SUPPORT_WARNING,

        [Description("SAT: Direnç değeri!")]
        RESISTANCE_ALERT,

        [Description("AL: Destek değeri!")]
        SUPPORT_ALERT,

        [Description("AL : MA-9, MA-30 Kesişmesi.")]
        MA_9_WARNING,
    }

    


}
