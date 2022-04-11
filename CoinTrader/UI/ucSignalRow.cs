using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace CoinTrader.UI
{
    public partial class ucSignalRow : UserControl
    {
        public ucSignalRow(ESignalReason signalReason)
        {
            InitializeComponent();

            setSignal(signalReason);

            this.Dock = DockStyle.Top;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }


        
        public void setSignal(ESignalReason signalReason)
        {
            lblSignalReason.Text = signalReason.ToString();
        }

        public void setCurrentPrice(double value)
        {
            lblCurrentPriceInUSD.Text = value.ToString("C8", CultureInfo.GetCultureInfo("en-US"));
        }

        public void updateLabel(string symbol, double value, ESignalReason signalReason)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => updateLabel(symbol, value, signalReason)));
                return;
            }


            setSignal(signalReason);
            setSymbol(symbol);
            setCurrentPrice(value);
        }

        private void setSymbol(string symbol)
        {
            lblSymbol.Text = symbol;
        }
    }
}
