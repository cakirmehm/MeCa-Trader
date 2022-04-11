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
using System.Globalization;
using BtcAnalyisTool.Source;

namespace CoinTrader.UI
{
    public partial class ucPortfolioManager : UserControl
    {
        public List<CTradeHistoryItem> TradeHistoryList = new List<CTradeHistoryItem>();
        private CBinanceDataController DataController = null;
        private Dictionary<string, ucPortfolioRow> DctCoinVsControl = new Dictionary<string, ucPortfolioRow>();
  
        public ucPortfolioManager()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            dataGridViewTransactionHistory.DoubleBuffered(true);
        }

        public void setDataController(CBinanceDataController dataController)
        {
            DataController = dataController;

            
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


        public void updateUI()
        {
            lblBudgetInSatoshi.Text = DataController.getSpotSatAmount().ToString("N8");
            double totalBudgetInUSD = 0.0;
            double totalProfitInUSD = 0.0;

            DctCoinVsControl.Clear();
            

            Dictionary<string, double> dctSpotCoinAmounts = DataController.getSpotCoinAmounts();

            this.tabPageSpotWallet.SuspendLayout();
            foreach (var sp in dctSpotCoinAmounts)
            {
                string symbol = $"{sp.Key}USDT";
                string symbolName = symbol; //DataController.getSymbolName(sp.Key, "USDT");
                ucPortfolioRow s1 = new ucPortfolioRow(sp.Key, symbolName);
                DctCoinVsControl.Add(symbol, s1);
                this.tabPageSpotWallet.Controls.Add(s1);
            }
            this.tabPageSpotWallet.ResumeLayout();


            foreach (var sp in dctSpotCoinAmounts)
            {
                string symbol = $"{sp.Key}USDT";
                string symbolName = symbol; 
                double amount = sp.Value;
                double currPrice = DataController.getSymbolPrice(sp.Key, "USDT");
                double totalPrice = amount * currPrice;
                double averageCost = DataController.getAverageCost(sp.Key);

                ucPortfolioRow s1 = DctCoinVsControl[symbol];
                s1.setAmount(amount);
                s1.setCurrentPrice(currPrice);
                s1.setTotalCurrentPrice(totalPrice);
                s1.setProfitValues();
                s1.setAverageCost(averageCost);

                totalProfitInUSD += s1.Profit;

                DataController.readSymbolTickers($"{sp.Key}USDT", this);

                totalBudgetInUSD += totalPrice;
            }

            lblTotalBudgetInUSD.Text = totalBudgetInUSD.ToString("C2", CultureInfo.GetCultureInfo("en-US"));
            lblTotalProfit.Text = totalProfitInUSD.ToString("C2", CultureInfo.GetCultureInfo("en-US"));

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            resetUI();
            updateUI();
        }

        private void resetUI()
        {
            lblBudgetInSatoshi.Text = lblTotalBudgetInUSD.Text = "-";
            tabPageSpotWallet.Controls.Clear();
        }

        public void updateLabel(string symbol, double value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => updateLabel(symbol, value)));
                return;
            }

            setLabelValue(symbol, value);
        }

        private void setLabelValue(string symbol, double value)
        {
            double amount = DctCoinVsControl[symbol].Amount;
             
            DctCoinVsControl[symbol].setAmount(amount);
            DctCoinVsControl[symbol].setCurrentPrice(value);
            DctCoinVsControl[symbol].setTotalCurrentPrice(amount * value);
          
            lblTotalBudgetInUSD.Text = DctCoinVsControl.Values
                .Cast<ucPortfolioRow>()
                .Sum(u => (u as ucPortfolioRow).TotalPriceInUSD)
                .ToString("C2", CultureInfo.GetCultureInfo("en-US"));

        }

        private void tabControlPortfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlPortfolio.SelectedTab == tabPageHistory)
            {
                if (DataController != null)
                {
                    Dictionary<string, double> dctSpotCoinAmounts = DataController.getSpotCoinAmounts();

                    cmbSymbolSelection.DataSource = dctSpotCoinAmounts.Keys.ToList();
                    cmbSymbolSelection.Update();

                    
                }
                
            }
        }

        private void cmbSymbolSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            TradeHistoryList.Clear();
            if (cmbSymbolSelection.SelectedIndex >= 0)
            {
                string asset = cmbSymbolSelection.SelectedItem.ToString();
                foreach (var item in DataController.getTradeHistory(asset))
                {
                    CTradeHistoryItem thi = new CTradeHistoryItem()
                    {
                        TradeTime = item.TradeTime,
                        Symbol = item.Symbol,
                        Direction = item.IsBuyer ? ETradeDirection.BUY : ETradeDirection.SELL,
                        Price = (double)item.Price,
                        Quantity = (double)item.Quantity,
                        ComissionPrice = (double)item.Commission,
                        ComissionAsset = item.CommissionAsset,
                    };

                    string unit = item.Symbol.Replace(asset, "");

                    if (item.Symbol.EndsWith("USDT"))
                    {
                        thi.TotalCostInUSDT = thi.Quantity * thi.Price;
                    }
                    else
                    {
                        double assetToUnit = DataController.getSymbolPrice(asset, unit, item.TradeTime);
                        double unitToUSDT = DataController.getSymbolPrice(unit, "USDT", item.TradeTime);

                        thi.TotalCostInUSDT = thi.Quantity * assetToUnit * unitToUSDT;
                    }
                        

                    TradeHistoryList.Add(thi);
                }

                dataGridViewTransactionHistory.DataSource = TradeHistoryList
                    .OrderBy(t => t.TradeTime)
                    .ToList();
                dataGridViewTransactionHistory.Refresh();

                updateCostLabels();
            }
        }

        private void updateCostLabels()
        {
            //double totalCostInUSDT = TradeHistoryList
            //    .Where(t => t.Direction == ETradeDirection.BUY 
            //                && t.Symbol.Equals($"{cmbSymbolSelection.SelectedItem.ToString()}USDT"))
            //    .Sum(t => t.Price * t.Quantity);

            //double totalQuantity = TradeHistoryList
            //    .Where(t => t.Direction == ETradeDirection.BUY
            //                && t.Symbol.Equals($"{cmbSymbolSelection.SelectedItem.ToString()}USDT"))
            //    .Sum(t => t.Quantity);

            //lblAverageCost.Text = (totalCostInUSDT / totalQuantity)
            //    .ToString("C4", CultureInfo.GetCultureInfo("en-US"));

            double totalQuantity = DataController.getSpotCoinAmount(cmbSymbolSelection.SelectedItem.ToString());
            double avgCostInUSDT = getTotalCostInUSDT(cmbSymbolSelection.SelectedItem.ToString()) / totalQuantity;


            lblAverageCost.Text = avgCostInUSDT.ToString("C4", CultureInfo.GetCultureInfo("en-US"));
        }

        private double getTotalCostInUSDT(string asset)
        {
            double totalCost = 0;
   

            foreach (var item in TradeHistoryList.Where(t => t.Symbol.StartsWith(asset)).OrderBy(t => t.TradeTime))
            {
                if (item.Direction == ETradeDirection.BUY)
                {
                    totalCost += item.TotalCostInUSDT;
                }
                else if (item.Direction == ETradeDirection.SELL)
                {
                    totalCost -= item.TotalCostInUSDT;
                }
            }

            return totalCost;
        }

        private void dataGridViewTransactionHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            CTradeHistoryItem asd = new CTradeHistoryItem();

           
            switch (e.ColumnIndex)
            {
                case 0:
                    e.CellStyle.Format = "yyyy.MM.dd HH:mm:ss";
                    break;
                case 3:
                    //e.CellStyle.Format = "C8";
                    //e.CellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                    //e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //break;
                case 4:
                case 5:
                    e.CellStyle.Format = "N8";
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    break;
                default:
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;
            }
        }

        private void dataGridViewTransactionHistory_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblBuyLabel.Visible = lblSell.Visible = true;
            lblBuyLabel.Text = $"{TradeHistoryList.Count(t => t.Direction == ETradeDirection.BUY)} adet alım";
            lblSell.Text = $"{TradeHistoryList.Count(t => t.Direction == ETradeDirection.SELL)} adet satım";
        }

        private void dataGridViewTransactionHistory_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblBuyLabel.Visible = lblSell.Visible = false;
        }
    }
}
