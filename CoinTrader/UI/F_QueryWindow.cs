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
    public partial class F_QueryWindow : DockContent
    {
        private static F_QueryWindow instance;
        public static F_QueryWindow getInstance()
        {
            if (instance == null)
                instance = new F_QueryWindow();
            return instance;
        }

        private F_QueryWindow()
        {
            InitializeComponent();

            instance = this;
        }


        public void setDataController(CBinanceDataController dataController)
        {
            ucQueryPaneComp.setDataController(dataController);
        }
    }
}
