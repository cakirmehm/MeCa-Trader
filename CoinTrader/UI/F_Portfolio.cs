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
    public partial class F_Portfolio : DockContent
    {
        private static F_Portfolio instance;
        public static F_Portfolio getInstance()
        {
            if (instance == null)
                instance = new F_Portfolio();
            return instance;
        }

        private F_Portfolio()
        {
            InitializeComponent();

            instance = this;
        }

        public void setDataController(CBinanceDataController dataController)
        {
            ucPortfolioManagerComp.setDataController(dataController);
           
        }

        public void updateUI()
        {
            ucPortfolioManagerComp.updateUI();
        }
    }
}
