using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoinTrader.Source;
using WeifenLuo.WinFormsUI.Docking;

namespace CoinTrader.UI
{
    public partial class F_AutoTrade : DockContent
    {
        private static F_AutoTrade instance;
        public static F_AutoTrade getInstance()
        {
            if (instance == null)
                instance = new F_AutoTrade();
            return instance;
        }

        private F_AutoTrade()
        {
            InitializeComponent();

            instance = this;
        }

        public void setDataController(CBinanceDataController dataController)
        {
            ucAutoTradeComp.setDataController(dataController);
        }

        public void updateUI()
        {
            ucAutoTradeComp.updateUI();
        }

        public void buyAuto(string symbol, double CurrPrice, double TargetPrice, ETradeDirection TargetTradeType)
        {
            ucAutoTradeComp.buyAuto(symbol, CurrPrice, TargetPrice, TargetTradeType);
        }

        public void sellAuto(string symbol, double CurrPrice)
        {
            ucAutoTradeComp.sellAuto(symbol, CurrPrice);
        }

        public void initialize()
        {
            ucAutoTradeComp.initialize();
        }
    }
}
