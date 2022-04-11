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
    public partial class F_SupportResistanceSignal : DockContent
    {
        public CBinanceDataController DataController { get; set; }

        private static F_SupportResistanceSignal instance;
        public static F_SupportResistanceSignal getInstance()
        {
            if (instance == null)
                instance = new F_SupportResistanceSignal();
            return instance;
        }

        public F_SupportResistanceSignal()
        {
            InitializeComponent();

            instance = this;
        }

        public void updateUI()
        {
            foreach (var item in DataController.readAllSymbolsUSDT())
            {
                DataController.readSymbolTickers(item, this);
                break;
            }
        }

        public void setDataController(CBinanceDataController dataController)
        {
            DataController = dataController;
        }

        public void updateLabel(string symbol, double min, double price, double max)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => updateLabel(symbol, min, price, max)));
                return;
            }

            updateCellValue(symbol, min, price, max);

            
                
           
        }

        private void updateCellValue(string symbol, double min, double price, double max)
        {
            int iRowIndex = 0; // getRowIndex(symbol);

            if (iRowIndex >= 0)
            {
                dgvSymbolPairs["Min", iRowIndex].Value = min;
                dgvSymbolPairs["Max", iRowIndex].Value = max;
                dgvSymbolPairs["Price", iRowIndex].Value = price;
            }
        }

        private int getRowIndex(string symbol)
        {
            foreach (var item in dgvSymbolPairs.Rows)
            {
                if ((item as DataGridViewRow).Cells[0].Value.ToString().Equals(symbol))
                    return (item as DataGridViewRow).Index;
            }
            return -1;
        }

    }
}
