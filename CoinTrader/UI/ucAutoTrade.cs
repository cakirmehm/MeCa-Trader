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
    public partial class ucAutoTrade : UserControl
    {
  
        private List<CTradeItem> TradeItems = new List<CTradeItem>();
        private CBinanceDataController DataController;
        private string[] arrSymbolCodes;

        public ucAutoTrade()
        {
            InitializeComponent();
            dgvLog.DoubleBuffered(true);

            
        }

        public void updateUI()
        {
            arrSymbolCodes = DataController.getUserCoins().ToArray();
        }

        public void setDataController(CBinanceDataController dataController)
        {
            DataController = dataController;
        }

        public void initialize()
        {
            CBudgetManager.getInstance().initializeBudget("BNBBUSD", 15.0, DataController.getSymbolPrice("BNB", "BUSD"));
            rtxtLog.AppendText($"Toplam Bütçe: {CBudgetManager.getInstance().Budget.TotalUSDInWallet} $ \n");
        }

        public void buyAuto(string symbol, double currPrice, double targetPrice, ETradeDirection targetTradeType)
        {
            CTradeItem ti = new CTradeItem()
            {
                TradeType = ETradeDirection.BUY,
                Symbol = symbol,
                PriceInUSDT = currPrice,
                TargetPrice = targetPrice,
                TargetTradeType = targetTradeType,
                Amount = 100.0 / currPrice
            };
            TradeItems.Add(ti);

            CBudgetManager.getInstance().addToBudget(ti.Symbol, ti.Amount, ti.PriceInUSDT);
            appendToLog(ti);
           
        }

        private void appendToLog(CTradeItem ti)
        {
            string buySellCode = ti.TradeType == ETradeDirection.BUY ? "A" : "S";
            string buySellCode2 = ti.TradeType == ETradeDirection.BUY ? "Alım" : "Satış";
            string buySellCode3 = ti.TradeType == ETradeDirection.BUY ? "satış" : "alış";

            string strTemp = $"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")} {buySellCode}-{ti.TradeId} " +
                $">> {ti.PriceInUSDT} $ fiyatlı {ti.Amount} adet {ti.Symbol} {buySellCode2} yapıldı.";

            if (ti.TradeType == ETradeDirection.SELL)
            {
                CTradeItem tiPrevBuy = TradeItems.Find(t => t.TradeId == ti.TradeId);
                strTemp += $"Gerçekleşen kâr: {(ti.PriceInUSDT - tiPrevBuy.PriceInUSDT) * ti.Amount}$ \n";
                strTemp += $"Toplam Bütçe: {CBudgetManager.getInstance().Budget.TotalUSDInWallet} $ \n";
            }
            else if (ti.TradeType == ETradeDirection.BUY)
            {
                strTemp += $"Hedef satış fiyatı: {ti.TargetPrice}\n";
            }


            rtxtLog.AppendText(strTemp);
            rtxtLog.Select(rtxtLog.Text.Length - 1, 0);
            rtxtLog.ScrollToCaret();

            dgvLog.DataSource = TradeItems.ToList();
            dgvLog.Refresh();
        }

        public void sellAuto(string symbol, double currPrice)
        {
            CTradeItem ti = new CTradeItem()
            {
                TradeType = ETradeDirection.SELL,
                Symbol = symbol,
                PriceInUSDT = currPrice,
                Amount = 100.0 / currPrice
            };

            TradeItems.Add(ti);

            CBudgetManager.getInstance().removeFromBudget(symbol, 100.0 / currPrice, currPrice);
            appendToLog(ti);

        }
    }
}
