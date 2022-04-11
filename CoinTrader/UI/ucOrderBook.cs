using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BtcAnalyisTool.Source;
using CoinTrader.Source;

namespace CoinTrader.UI
{
    public partial class ucOrderBook : UserControl
    {
        public CBinanceDataController DataController;
        public List<COrderBookRow> OrderBookRowList { get; set; } = new List<COrderBookRow>();

        public ucOrderBook()
        {
            InitializeComponent();

            dgvOrderBook.DoubleBuffered(true);
        }


        public void setDataController(CBinanceDataController dataController)
        {
            DataController = dataController;
        }

        public void updateUI(string symbol)
        {
            dgvOrderBook.DataSource = DataController.getOrderBook(symbol);
            dgvOrderBook.Refresh();
        }
    }
}
