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
    public partial class F_Login : DockContent
    {
        private static F_Login instance;
        public static F_Login getInstance()
        {
            if (instance == null)
                instance = new F_Login();
            return instance;
        }

        private F_Login()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

 
        private void ucConnectComp_EnabledChanged(object sender, EventArgs e)
        {
            if (ucConnectComp.Enabled == false)
            {
                F_Main.getInstance().startConnection(ucConnectComp.getDataController());
                
            }
        }

        public async void Login()
        {
            await ucConnectComp.Login();
        }
    }
}
