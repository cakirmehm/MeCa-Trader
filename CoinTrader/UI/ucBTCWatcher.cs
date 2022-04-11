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

namespace CoinTrader.UI
{
    public partial class ucBTCWatcher : UserControl
    {
        
        private CBinanceDataController DataController;
        private string[] arrSymbolCodes;

        public ucBTCWatcher()
        {
            InitializeComponent();


        }

        private void ucBTCWatcher_Load(object sender, EventArgs e)
        {

        }

        public void updateUI()
        {
            DataController.readSymbolTickers("BTCBUSD", ucPriceLabelComp1);
            //DataController.getCandles15min("BTCBUSD", ucPriceLabelComp1);

            DataController.readSymbolTickers("ETHBUSD", ucPriceLabelComp2);

            DataController.readSymbolTickers("BNBBUSD", ucPriceLabelComp3);

            arrSymbolCodes = DataController.getUserCoins().ToArray();
            cmbAddNew.DataSource = arrSymbolCodes;
            cmbAddNew.Text = "<Add New>";
            cmbAddNew.Update();
        }

        public void Close()
        {
            if (DataController != null)
            {
                DataController.Close();
            }
        }

        public void setDataController(CBinanceDataController dataController)
        {
            DataController = dataController;
        }

        private void cmbAddNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAddNew.SelectedIndex >= 0)
            {
                this.flowLayoutPanel1.SuspendLayout();
                this.flowLayoutPanel1.Controls.Remove(cmbAddNew);

                string symbolCode = cmbAddNew.SelectedItem.ToString();

                ucPriceLabel ucPriceLabelCustom = new ucPriceLabel()
                {
                    Name = $"ucPriceLabel{symbolCode}"
                };

                this.flowLayoutPanel1.Controls.Add(ucPriceLabelCustom);
                this.flowLayoutPanel1.Controls.Add(cmbAddNew);
                cmbAddNew.DataSource = arrSymbolCodes;
                cmbAddNew.Update();

                this.flowLayoutPanel1.ResumeLayout();
                this.flowLayoutPanel1.Refresh();

                DataController.readSymbolTickers($"{symbolCode}BUSD", ucPriceLabelCustom);

               
            }
            

        }
    }
}
