using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoinTrader.Source;
using NetTrader.Indicator;

namespace CoinTrader.UI
{
    public partial class ucSignals : UserControl
    {
        private CBinanceDataController DataController;
        private Dictionary<string, ucSignalRow> DctCoinVsControl = new Dictionary<string, ucSignalRow>();

        public ucSignals()
        {
            InitializeComponent();
        }

        public void addSignal(ESignalReason signalReason)
        {
            ucSignalRow uRow = new ucSignalRow(signalReason);

            gbxSignals.SuspendLayout();
            gbxSignals.Controls.Add(uRow);
            gbxSignals.ResumeLayout();
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

        public void setDataController(CBinanceDataController dataController)
        {
            DataController = dataController;
        }

        public void updateUI()
        {
            DctCoinVsControl.Clear();

            this.gbxSignals.Controls.Clear();

            foreach (string symbol in DataController.readAllSymbols("BUSD"))
            {
                ucSignalRow s1 = new ucSignalRow(ESignalReason.WHALE_ALERT);

                DataController.readLastSymbolTickers(symbol, s1);

                if (!this.gbxSignals.Controls.Contains(s1))
                    this.gbxSignals.Controls.Add(s1);
            }
        }


        //public void updateLabel(string symbol, double value, ESignalReason signalReason)
        //{
        //    if (InvokeRequired)
        //    {
        //        this.Invoke(new Action(() => updateLabel(symbol, value, signalReason)));
        //        return;
        //    }

        //    setLabelValue(symbol, value, signalReason);
        //}

        //private void setLabelValue(string symbol, double value, ESignalReason signalReason)
        //{
   
        //    DctCoinVsControl[symbol].setSignal(signalReason);
        //    DctCoinVsControl[symbol].setCurrentPrice(value);
           
        //}
    }
}
