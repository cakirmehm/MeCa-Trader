using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace CoinTrader.UI
{
    public partial class ucPortfolioRow : UserControl
    {
        private string ICO_FOLDER = @"C:\Users\mehmet\Documents\Visual Studio 2017\Projects\CoinTrader\CoinTrader\ico";
        private string UP_ICON = "Stock-Index-Up-icon.png";
        private string DOWN_ICON = "Stock-Index-Down-icon.png";
        private bool blnExpanded = false;

        public double Amount { get; set; }
        public double AverageCost { get; set; }
        public double TotalPriceInUSD { get; set; }
        public double CurrentPriceInUSD { get; set; }
        public double Profit { get; set; }
        public double ProfitPercent { get; set; }

        public ucPortfolioRow(string symbol, string symbolName)
        {
            InitializeComponent();

            this.Dock = DockStyle.Top;

            string iconFilePath = $@"{ICO_FOLDER}\{symbol}.PNG";
            if (File.Exists(iconFilePath))
                pictureBoxSymbolIcon.Image = Image.FromFile(iconFilePath);
            else
                pictureBoxSymbolIcon.Image = null;

            lblSymbol.Text = symbol;
            lblSymbolName.Text = symbolName;

           
        }

        

        public void setCurrentPrice(double price)
        {
            CurrentPriceInUSD = price;
            lblCurrentPriceInUSD.Text = price.ToString("C4", CultureInfo.GetCultureInfo("en-US"));
        }

        public void setAmount(double value)
        {
            Amount = value;
            lblAmount.Text = value.ToString("N8");
        }

        public void setTotalCurrentPrice(double price)
        {
            TotalPriceInUSD = price;
            lblTotalCurrentPrice.Text = price.ToString("C4", CultureInfo.GetCultureInfo("en-US"));
        }

        public void setAverageCost(double avgCost)
        {
            AverageCost = avgCost;
            lblAverageCostInUSD.Text = AverageCost.ToString("C4", CultureInfo.GetCultureInfo("en-US"));
           
        }

        public void setProfitValues()
        {
            Profit = CurrentPriceInUSD - AverageCost;
            ProfitPercent = Profit * 100.0 / AverageCost;

            lblProfit.Text =  $"+ {Profit.ToString("C4", CultureInfo.GetCultureInfo("en-US"))}";
            lblProfitPercent.Text = $"+ {ProfitPercent.ToString("N2", CultureInfo.GetCultureInfo("en-US"))}";

            if (Profit > 0.0) lblProfit.ForeColor = Color.Green;
            else lblProfit.ForeColor = Color.Red;
        }

        //public void setUp()
        //{
        //    pictureBoxUpDown.Image = Image.FromFile($@"{ICO_FOLDER}\{UP_ICON}");
        //}

        //public void setDown()
        //{
        //    pictureBoxUpDown.Image = Image.FromFile($@"{ICO_FOLDER}\{DOWN_ICON}");
        //}

        private void ucPortfolioRow_MouseEnter(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.ForeColor = Color.ForestGreen;
            this.BackColor = Color.LightBlue;
            this.Cursor = Cursors.Hand;
            this.ResumeLayout();
        }

        private void ucPortfolioRow_MouseLeave(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.ForeColor = Color.Black;
            this.BackColor = Color.White;
            this.Cursor = Cursors.Arrow;
            this.ResumeLayout();
        }

        public void updateLabel(string value)
        {
           

            

        }

        private void ucPortfolioRow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (blnExpanded == false)
            {
                this.Height = this.Height * 2;
                blnExpanded = true;
            }
            else
            {
                this.Height = this.Height / 2;
                blnExpanded = false;
            }
        }
    }
}
