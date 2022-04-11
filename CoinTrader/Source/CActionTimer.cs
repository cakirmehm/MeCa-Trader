using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinTrader.Source
{
    public class CActionTimer : Timer
    {


        // 15 dakikalıkta
        // XX:16 - XX:31 - XX:46 - XY:01
        // MACD

        
        // 1 saatlikte 
        // 03:01 - 04:01 - .... - 02:01
        // MACD

        // 4 saatlikte
        // 03:01 - 07:01 - 11:01 - 15:01 - 19:01 - 23:01
        // MACD

        // Günlükte
        // Her gün 03:01
        // RSI 

        // Haftalıkta
        // Her Pazartesi 03:01
        // RSI
        
        // Aylıkta
        // Her ayın ilk günü 03:01

        public CActionTimer(EActionTimerType type)
        {
            switch (type)
            {
                case EActionTimerType.MINUTES_15:
                    this.Interval = 1000 * 60 * 1;
                    break;
                case EActionTimerType.HOURS_1:
                    this.Interval = 1000 * 60 * 60;
                    break;
                case EActionTimerType.HOURS_4:
                    this.Interval = 1000 * 60 * 60 * 4;
                    break;
                case EActionTimerType.DAYS_1:
                    this.Interval = 1000 * 60 * 60 * 24;
                    break;
                case EActionTimerType.DAYS_7:
                    this.Interval = 1000 * 60 * 60 * 24 * 7;
                    break;
                case EActionTimerType.MONTHS_1:
                    break;
                default:
                    break;
            }

            this.Tick += CActionTimer_Tick;
            this.Start();
        }

        private void CActionTimer_Tick(object sender, EventArgs e)
        {
            //CTelegramDataController.getInstance().TelegramSendMessage("15 dakikada 1 böyle mesaj gelecek işte...");
        }

       


    }

    public enum EActionTimerType
    {
        MINUTES_15,
        HOURS_1,
        HOURS_4,
        DAYS_1,
        DAYS_7,
        MONTHS_1
    }
}
