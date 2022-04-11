using NetTrader.Indicator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BtcAnalyisTool.Source
{
    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }


        public static bool IsGreen(this Ohlc ohlc)
        {
            return ohlc.Close > ohlc.Open;
        }

        public static bool IsRed(this Ohlc ohlc)
        {
            return ohlc.Close < ohlc.Open;
        }

    }

}
