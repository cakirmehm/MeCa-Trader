using CoinTrader.Source;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CoinTrader.UI
{
    public partial class F_OrderManagement : DockContent
    {
        ucOrderBook ucOrderBookComp = new ucOrderBook();

        private static F_OrderManagement instance;
        public static F_OrderManagement getInstance()
        {
            if (instance == null)
                instance = new F_OrderManagement();
            return instance;
        }

        public F_OrderManagement()
        {
            InitializeComponent();

            ucOrderBookComp.Dock = DockStyle.Fill;
            tbPgOrderBook.Controls.Add(ucOrderBookComp);

            instance = this;
        }

        public void setDataController(CBinanceDataController dataController)
        {
            ucOrderBookComp.setDataController(dataController);
        }

        public void updateUI(string symbol)
        {

            ucOrderBookComp.updateUI(symbol);
        }

    }
}
