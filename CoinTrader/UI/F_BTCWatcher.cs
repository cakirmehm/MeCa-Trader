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
    public partial class F_BTCWatcher : DockContent
    {
        private static F_BTCWatcher instance;
        public static F_BTCWatcher getInstance()
        {
            if (instance == null)
                instance = new F_BTCWatcher();
            return instance;
        }

        private F_BTCWatcher()
        {
            InitializeComponent();

            instance = this;
        }

        public void setDataController(CBinanceDataController dataController)
        {
            ucBTCWatcherComp.setDataController(dataController);
        }

        public void updateUI()
        {
            
            ucBTCWatcherComp.updateUI();
        }

        private void F_BTCWatcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucBTCWatcherComp.Close();
        }
    }
}
