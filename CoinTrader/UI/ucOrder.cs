using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinTrader.UI
{
    public partial class ucOrder : UserControl
    {


        public ucOrder()
        {
            InitializeComponent();
        }

        private void btnOrderBuy_Click(object sender, EventArgs e)
        {

        }

        private void btnOrderSell_Click(object sender, EventArgs e)
        {

        }

        private void ntxQuantity_ValueChanged(object sender, EventArgs e)
        {
            double dQua = (double)ntxQuantity.Value;
            
        }
    }
}
