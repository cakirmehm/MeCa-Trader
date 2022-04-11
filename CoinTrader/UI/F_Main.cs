using BtcAnalyisTool.Source;
using CoinTrader.Source;
using NetTrader.Indicator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CoinTrader.UI
{
    public partial class F_Main : Form
    {
        private CBinanceDataController DataController;
        private CChartAnalyzer ChartAnalyzer;
        private CTwitterDataController TwitterDataController;
        private CSymbolRenderer SymbolRenderer;
       

        private List<Ohlc> CandleList = new List<Ohlc>();

      

        private List<CSupResRowInfo> SRInfoList = new List<CSupResRowInfo>();

        private Dictionary<string, List<Ohlc>> dctSymbolsVsCandles = new Dictionary<string, List<Ohlc>>();

        private WeifenLuo.WinFormsUI.Docking.DockPanel dp = new WeifenLuo.WinFormsUI.Docking.DockPanel();

        private static F_Main instance;
        public static F_Main getInstance()
        {
            if (instance == null)
                instance = new F_Main();
            return instance;
        }

        private F_Main()
        {
            InitializeDockPanels();
            InitializeComponent();
           

            dgvSymbolTickers.DoubleBuffered(true);
            dgvSignals.DoubleBuffered(true);



            instance = this;
        }

        private void InitializeDockPanels()
        {
            this.IsMdiContainer = true;

            this.WindowState = FormWindowState.Maximized;

            dp.Dock = DockStyle.Fill;
            dp.BringToFront();

            this.Controls.Add(dp);


            //F_Signals fSignals = new F_Signals();
            //fSignals.ShowHint = DockState.DockLeft;
            //fSignals.Show(dp);




            F_Portfolio fPortfolio = F_Portfolio.getInstance();
            fPortfolio.ShowHint = DockState.DockLeftAutoHide;
            fPortfolio.Show(dp);

            F_BTCWatcher fBtcWatcher = F_BTCWatcher.getInstance();
            fBtcWatcher.ShowHint = DockState.DockBottom;
          
            fBtcWatcher.Show(dp);
            dp.DockBottomPortion = 0.13;


            F_GeneralView fGeneralView = F_GeneralView.getInstance();
            fGeneralView.ShowHint = DockState.Document;
            fGeneralView.Show(dp);

            F_SignalMatrix fSignalMatrix = F_SignalMatrix.getInstance();
            fSignalMatrix.ShowHint = DockState.Document;
            fSignalMatrix.Show(dp);

            F_QueryWindow frmQueryWindow = F_QueryWindow.getInstance();
            frmQueryWindow.ShowHint = DockState.Document;
            frmQueryWindow.Show(dp);
            //frmQueryWindow.DockHandler.FloatPane.DockTo(dp.DockWindows[DockState.Document]);

            //F_AutoTrade fAutoTrade = F_AutoTrade.getInstance();
            //fAutoTrade.ShowHint = DockState.Document;
            //fAutoTrade.Show(dp);
            //fAutoTrade.DockHandler.FloatPane.DockTo(dp.DockWindows[DockState.Document]);

            //F_OrderManagement fOrderManagement = F_OrderManagement.getInstance();
            //fOrderManagement.ShowHint = DockState.Document;
            //fOrderManagement.Show(dp);

            //F_SupportResistanceSignal f_SupportResistanceSignal = F_SupportResistanceSignal.getInstance();
            //f_SupportResistanceSignal.ShowHint = DockState.Document;
            //f_SupportResistanceSignal.Show(dp);

        }


        public void startConnection(CBinanceDataController aDataController)
        {
            F_Login.getInstance().Login();

            DataController = aDataController;

            F_GeneralView.getInstance().setDataController(DataController);
            F_GeneralView.getInstance().initialize();
            F_GeneralView.getInstance().updateUI();

            F_QueryWindow.getInstance().setDataController(DataController);
            F_QueryWindow.getInstance().Show();




            //F_SignalMatrix.getInstance().setDataController(DataController);
            //F_SignalMatrix.getInstance().initialize();
            //F_SignalMatrix.getInstance().Show();

            //F_Portfolio.getInstance().setDataController(DataController);
            //F_Portfolio.getInstance().updateUI();
            //F_Portfolio.getInstance().Show();

            //ucSignalsComp.setDataController(DataController);
            //ucSignalsComp.updateUI();

            F_BTCWatcher.getInstance().setDataController(DataController);
            F_BTCWatcher.getInstance().updateUI();

            //F_AutoTrade.getInstance().setDataController(DataController);
            //F_AutoTrade.getInstance().initialize();
            //F_AutoTrade.getInstance().updateUI();


            //F_OrderManagement.getInstance().setDataController(DataController);
            //F_OrderManagement.getInstance().updateUI("MATICUSDT");

            //F_SupportResistanceSignal.getInstance().setDataController(DataController);
            //F_SupportResistanceSignal.getInstance().updateUI();


            //MessageBox.Show("TelegramDataController is closed!");
            CTelegramDataController.getInstance().setDataController(DataController);
            //CTelegramDataController.getInstance().InitializeFileSystemWatchers();

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



        public void UpdateTickerDataUI()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(UpdateTickerDataUI));
                return;
            }


            foreach (var item in DataController.SymbolTickers)
            {
                ChartAnalyzer = new CChartAnalyzer(item.lowPrice, item.highPrice);

                item.support = ChartAnalyzer.calculateSupport(item.currentPrice);
                item.resistance = ChartAnalyzer.calculateResistance(item.currentPrice);
            }


            //dataGridView2.DataSource = SymbolTickerList.OrderBy(s => s.symbol).ToList();
            dgvSymbolTickers.DataSource = DataController.SymbolTickers.OrderBy(s => s.symbol).ToList();
            dgvSymbolTickers.Refresh();
            DataController.SymbolTickers.Clear();




            UpdateSignalDataUI();
           //UpdateResistanceSupportDataUI();
        }

        public void UpdateSignalDataUI()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(UpdateSignalDataUI));
                return;
            }


            dgvSignals.DataSource = checkSignals(DataController.SymbolTickers.ToList());
            dgvSignals.Refresh();

        }

        //public void UpdateResistanceSupportDataUI()
        //{
        //    if (InvokeRequired)
        //    {
        //        this.Invoke(new Action(UpdateResistanceSupportDataUI));
        //        return;
        //    }



        //    DateTime dt = DateTime.Now;
         
           



        //    foreach (var item in DataController.SymbolTickers)
        //    {
        //        CandleList = DataController.getCandles(
        //            item.symbol,
        //            Binance.Net.Enums.KlineInterval.FourHour,
        //            new DateTime(dt.Year, dt.Month, dt.Day - 1),
        //            dt
        //            );
        //        ChartAnalyzer = new CChartAnalyzer(CandleList);

        //        CSupResRowInfo srInfo = new CSupResRowInfo();

        //        srInfo.Symbol = item.symbol;
        //        srInfo.Price = DataController.getSymbolPrice(srInfo.Symbol);
        //        srInfo.Support = ChartAnalyzer.calculateSupport(srInfo.Price);
        //        srInfo.Resistance = ChartAnalyzer.calculateResistance(srInfo.Price);

        //        SRInfoList.Add(srInfo);
        //    }

          

        //    dgvSupportResistance.DataSource = SRInfoList.ToList();
        //    dgvSupportResistance.Refresh();

        //    SRInfoList.Clear();
        //}

        private List<CSignal> checkSignals(List<CSymbolTicker> symbolTickers)
        {
            // dummy function
            List<CSignal> retList = new List<CSignal>();

            foreach (var item in symbolTickers)
            {
                if (item.priceChangePercent > 5)
                {
                    retList.Add(new CSignal()
                    {
                        Action = EAction.STRONG_SELL,
                        Indicator = EIndicator.MA,
                        Symbol = item.symbol,
                        Description = "% Price Change > 5.0"
                    });
                }
                else if (item.priceChangePercent < -3.0)
                {
                    retList.Add(new CSignal()
                    {
                        Action = EAction.BUY,
                        Indicator = EIndicator.MACD,
                        Symbol = item.symbol,
                        Description = "% Price Change < -3.0"
                    });
                }
                else
                {
                    retList.Add(new CSignal()
                    {
                        Action = EAction.HOLD,
                        Indicator = EIndicator.NONE,
                        Symbol = item.symbol,
                        Description = ""
                    });
                }

                //if (item.currentPrice < item.weightedAvgPrice)
                //{
                //    retList.Add(new CSignal()
                //    {
                //        Action = EAction.BUY,
                //        Indicator = EIndicator.EMA,
                //        Symbol = item.symbol,
                //        Description = "Price < Avg"
                //    });
                //}
               

            }

            return retList.OrderBy(s => s.Symbol).ToList();
        }

        private void dgvSignals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((EAction)dgvSignals["Action", e.RowIndex].Value == EAction.BUY)
            {
                dgvSignals["Action", e.RowIndex].Style.BackColor = Color.LightGreen;
            }
            else if ((EAction)dgvSignals["Action", e.RowIndex].Value == EAction.STRONG_BUY)
            {
                dgvSignals["Action", e.RowIndex].Style.BackColor = Color.Green;
            }
            else if ((EAction)dgvSignals["Action", e.RowIndex].Value == EAction.SELL)
            {
                dgvSignals["Action", e.RowIndex].Style.BackColor = Color.IndianRed;
            }
            else if ((EAction)dgvSignals["Action", e.RowIndex].Value == EAction.STRONG_SELL)
            {
                dgvSignals["Action", e.RowIndex].Style.BackColor = Color.Brown;
            }
            else if ((EAction)dgvSignals["Action", e.RowIndex].Value == EAction.HOLD)
            {
                dgvSignals["Action", e.RowIndex].Style.BackColor = Color.Gray;
            }
        }

        

        private void dgvSymbolTickers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (PropertyInfo pi in typeof(CSymbolTicker).GetProperties())
            {
                if (pi.PropertyType == typeof(double))
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    if (pi.Name.ToLower().Contains("price"))
                    {
                       
                        e.CellStyle.Format = "c4";
                        e.CellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");

                    }
                    else if (pi.Name.ToLower().Contains("percent"))
                    {
                        e.CellStyle.Format = "0.00\\%";
                    }
                    else
                    {
                        e.CellStyle.Format = "N4";
                    }


                   
                }
            }



            //double currPrice = (double)dgvSymbolTickers["currentPrice", e.RowIndex].Value;
            //double prevPrice = (double)dgvSymbolTickers["prevClosePrice", e.RowIndex].Value;

            //if (currPrice > prevPrice)
            //{
            //    e.CellStyle.ForeColor = Color.Green;
            //}
            //else
            //{
            //    e.CellStyle.ForeColor = Color.Red;
            //}
            

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            //if (true == DataController.orderBuy("ETHBUSD", 0.005, 2302.0, 2301.0))
            //    MessageBox.Show("Emir gerceklestirildi.");
        }

        private void btnOrderBuy_Click(object sender, EventArgs e)
        {
            //if (true == DataController.orderBuy("ETHBUSD", 0.005, 2301.0, 2302.0))
            //    MessageBox.Show("Emir gerceklestirildi.");
        }

        private void btnOrderSell_Click(object sender, EventArgs e)
        {

        }

      

        

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            ucCandleChart ucChartComp = new ucCandleChart();

            ucChartComp.Dock = DockStyle.Fill;
            form.Controls.Add(ucChartComp);

   
            //ucChartComp.OhlcList = ucQueryPaneComp.getOhlcList();
            //ucChartComp.updateUI();

            form.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form form = new Form();
            ucAutoTrade ucChartComp = new ucAutoTrade();

            ucChartComp.Dock = DockStyle.Fill;
            form.Controls.Add(ucChartComp);

            form.ShowDialog();
        }

        private void F_Main_Load(object sender, EventArgs e)
        {
            //F_Login.getInstance().ShowDialog();
            F_Login.getInstance().Login();
        }

        private void F_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DataController != null)
            {
                DataController.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }

}
