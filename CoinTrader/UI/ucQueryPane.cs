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
using BtcAnalyisTool.Source;
using System.IO;
using Binance.Net.Enums;

namespace CoinTrader.UI
{
    public partial class ucQueryPane : UserControl
    {
        private CBinanceDataController DataController;
        private Dictionary<string, List<Ohlc>> dctSymbolsVsCandles = new Dictionary<string, List<Ohlc>>();
        private CChartAnalyzer ChartAnalyzer;
        private CSymbolRenderer SymbolRenderer;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SelectedRefSymbol { get; set; }
        Binance.Net.Enums.KlineInterval SelectedInterval = Binance.Net.Enums.KlineInterval.OneHour;

  


        public string URL { get; set; }

        public ucQueryPane()
        {
            InitializeComponent();

            InitUI();
        }

 

        private void InitUI()
        {
            dateTimePickerEnd.Value  = DateTime.Now;
            dateTimePickerStart.Value  = DateTime.Now.AddDays(-1);


            SelectedRefSymbol = "USDT";
        }

        public List<Ohlc> getOhlcList(string symbol)
        {
            return dctSymbolsVsCandles[symbol];
        }

        public List<Ohlc> getOhlcList()
        {
            return dctSymbolsVsCandles[dgvQueryResult.SelectedRows[0].Cells[0].Value.ToString()];
        }

        private void getVolumeSuddenIncreaseList()
        {
            

            foreach (string symbolP in DataController.readAllSymbols(SelectedRefSymbol))
            {
                List<Ohlc> candles = DataController.getCandles(
                                             symbol: symbolP,
                                             interval: SelectedInterval,
                                             start: StartDate,
                                             end: EndDate
                                             );



                if (candles.Count >= 3)
                {
                    ChartAnalyzer = new CChartAnalyzer(candles);
                    if (ChartAnalyzer.anyLatestVolumeSpike())
                    {
                        dctSymbolsVsCandles.Add(symbolP, candles);
                    }
                }

            }



        }

        private void getCurrentVolumeIncreaseList()
        {

            foreach (string symbolP in DataController.readAllSymbols(SelectedRefSymbol, CUtils.RootFolderPath))
            {
                List<Ohlc> candles = DataController.getCandlesCached(
                                             CUtils.RootFolderPath,
                                             symbol: symbolP,
                                             interval: SelectedInterval,
                                             //start: StartDate,
                                             end: EndDate,
                                             pNumOfInterval: 3
                                             );


                if (candles.Count > 0)
                {
                    ChartAnalyzer = new CChartAnalyzer(candles);
                    if (ChartAnalyzer.anyCurrentVolumeIncrease())
                    {
                        dctSymbolsVsCandles.Add(symbolP, candles);
                    }
                }

            }



        }

        private void getRSIBelow30()
        {

            foreach (string symbolP in DataController.readAllSymbols(SelectedRefSymbol, CUtils.RootFolderPath))
            {
                List<Ohlc> candles = DataController.getCandlesCached(
                                             CUtils.RootFolderPath,
                                             symbol: symbolP,
                                             interval: SelectedInterval,
                                             //start: StartDate,
                                             end: EndDate,
                                             pNumOfInterval: 14
                                             );

       


                if (candles.Count > 0)
                {
                    ChartAnalyzer = new CChartAnalyzer(candles);
                    if (ChartAnalyzer.anyRSIBelow30())
                    {
                        dctSymbolsVsCandles.Add(symbolP, candles);
                    }
                }

            }


         


            //double currPrice = getSymbolPrice(symbol);
            //double currVol = getSymbolVolume(symbol);

            //retList.Add(new Ohlc()
            //{
            //    Open = currPrice,
            //    Close = currPrice,
            //    High = currPrice,
            //    Low = currPrice,
            //    Volume = currVol,
            //    Date = end
            //});



        }

        private void cmbSuspiciousSymbols_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private async void cmbQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBoxLoading.Visible = true;
            cmbQuery.Enabled = false;
            dgvQueryResult.Visible = false;
            dctSymbolsVsCandles.Clear();

            StartDate = dateTimePickerStart.Value;
            EndDate = dateTimePickerEnd.Value;

            

            if (cmbQuery.SelectedIndex == 0)
            {
                await Task.Run(() => getVolumeSuddenIncreaseList());
            }
            if (cmbQuery.SelectedIndex == 1)
            {
                await Task.Run(() => getCurrentVolumeIncreaseList());
            }
            else if (cmbQuery.SelectedIndex == 2)
            {
                await Task.Run(() => getRSIBelow30());
            }
            else if (cmbQuery.SelectedIndex == 4)
            {
                await Task.Run(() => getHugeCandleUp());
            }
            else if (cmbQuery.SelectedIndex == 8)
            {
                await Task.Run(() => getRisingBeforeBTCCrash());
            }
            else if (cmbQuery.SelectedIndex == 10)
            {
                await Task.Run(() => getFakeDepressionSymbols());
            }
            else if (cmbQuery.SelectedIndex == 11)
            {
                await Task.Run(() => getUnderDaily200MA());
            }
            else if (cmbQuery.SelectedIndex == 12)
            {
                await Task.Run(() => getCheapest50());
            }
            else if (cmbQuery.SelectedIndex == 13)
            {
                await Task.Run(() => getRedCandleSeries(3));
            }
            else if (cmbQuery.SelectedIndex == 14)
            {
                await Task.Run(() => getRedCandleSeries(4));
            }
            else if (cmbQuery.SelectedIndex == 15)
            {
                await Task.Run(() => getRedCandleSeries(5));
            }
            

            dgvQueryResult.Visible = true;
            cmbQuery.Enabled = true;
            pictureBoxLoading.Visible = false;

            dgvQueryResult.DataSource = dctSymbolsVsCandles
                .Select(k => new { k.Key, k.Value.Last().Close, k.Value.Last().Volume })
                .ToList();
            dgvQueryResult.Update();

            updateStatusBar();

        }

        private void getCheapest50()
        {
            Dictionary<string, double> dctSymbolVsRatio = new Dictionary<string, double>();
            Dictionary<string, List<Ohlc>> dctSymbolVsCandles2 = new Dictionary<string, List<Ohlc>>();
            foreach (string symbolP in DataController.readAllSymbols(SelectedRefSymbol, CUtils.RootFolderPath))
            {
                List<Ohlc> candlesWeekly = DataController.getCandles(
                                             symbol: symbolP,
                                             interval: KlineInterval.OneWeek,
                                             start: new DateTime(2020,1,1),
                                             end: EndDate
                                             );


                if (candlesWeekly.Count < 2)
                    continue;


                candlesWeekly = candlesWeekly.OrderByDescending(c => c.High).ToList();

                candlesWeekly.RemoveAt(0);


                double max = candlesWeekly[0].High;
                double curr = DataController.getSymbolPrice(symbolP);


                dctSymbolVsRatio.Add(symbolP, max * 1.0 / curr);
                dctSymbolVsCandles2.Add(symbolP, candlesWeekly);


            }

            var ordered = dctSymbolVsRatio.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string,double> item in ordered)
            {
                dctSymbolVsCandles2[item.Key].Last().Volume = item.Value;
                dctSymbolsVsCandles.Add(item.Key, dctSymbolVsCandles2[item.Key]);
            }
        }

        private void getUnderDaily200MA()
        {
            foreach (string symbolP in DataController.readAllSymbols(SelectedRefSymbol))
            {
                List<Ohlc> candles = DataController.getCandles(
                                             symbol: symbolP,
                                             interval: Binance.Net.Enums.KlineInterval.OneDay,
                                             start: StartDate,
                                             end: EndDate
                                             );


                if (candles.Count > 0)
                {
                    ChartAnalyzer = new CChartAnalyzer(candles);
                    if (candles.Skip(Math.Max(0, candles.Count() - 200)).ToList().Average(o => o.Close) > candles.Last().Close)
                    {
                        dctSymbolsVsCandles.Add(symbolP, candles);
                    }
                }

            }
        }

        private void getRedCandleSeries(int serieNum)
        {
            foreach (string symbolP in DataController.readAllSymbols(SelectedRefSymbol))
            {
                List<Ohlc> candles = DataController.getCandles(
                                             symbol: symbolP,
                                             interval: SelectedInterval,
                                             start: StartDate,
                                             end: EndDate
                                             );

                if (candles.Count == 0) continue;
                if (candles.Last().IsGreen()) continue;

                if (candles.Count > 0)
                {
                    List<Ohlc> lastCandles = candles.GetRange(
                        Math.Max(candles.Count - serieNum - 1, 0),
                        Math.Min(serieNum, candles.Count));

                    if (lastCandles.All(c => c.IsRed()))
                        dctSymbolsVsCandles.Add(symbolP, candles);
                }

            }
        }


        private void getFakeDepressionSymbols()
        {
            foreach (string symbolP in DataController.readAllSymbolsBTC())
            {
                

                //List<Ohlc> candles = DataController.getCandles(
                //                             symbol: symbolP,
                //                             interval: Binance.Net.Enums.KlineInterval.OneWeek,
                //                             start: new DateTime(2021,1,1),
                //                             end: DateTime.Now
                //                             );

                List<Ohlc> candles = DataController.getCandles2021(
                                            symbol: symbolP,
                                            interval: Binance.Net.Enums.KlineInterval.OneWeek
                                            );

                if (candles == null) continue;

                if (candles.Count > 0)
                {
                    ChartAnalyzer = new CChartAnalyzer(candles);
                    //if (ChartAnalyzer.anyHugeCandleAfterRed())
                    {
                        dctSymbolsVsCandles.Add(symbolP, candles);
                    }
                }

            }
        }

        private void updateStatusBar()
        {
            if (dgvQueryResult.Rows.Count > 0)
                tslblInfo.Text = $"{dgvQueryResult.Rows.Count} symbol(s) found.";
            else
                tslblInfo.Text = $"No symbol(s) found.";
        }

        private void getRisingBeforeBTCCrash()
        {
            List<Ohlc> btcCandles = DataController.getCandles(
                                             symbol: "BTCUSDT",
                                             interval: Binance.Net.Enums.KlineInterval.FourHour,
                                             start: StartDate,
                                             end: EndDate
                                             );

            List<DateTime> btcCrashTimes = getBtcCrashTimes(btcCandles);

            if (btcCrashTimes.Count == 0) return;

            DateTime refDateTime = btcCrashTimes[btcCrashTimes.Count - 1];

            foreach (string symbolP in DataController.readAllSymbols(SelectedRefSymbol))
            {
                if (symbolP.Equals("BTCUSDT")) continue;

                List<Ohlc> candles = DataController.getCandles(
                                             symbol: symbolP,
                                             interval: Binance.Net.Enums.KlineInterval.OneHour,
                                             start: refDateTime.AddHours(-2),
                                             end: refDateTime
                                             );

                if (candles.Count >= 2)
                {
                    if (candles.All(c => c.IsGreen()))
                    {
                        //if (dctSymbolsVsCandles.ContainsKey(symbolP) == false)
                            dctSymbolsVsCandles.Add(symbolP, candles);
                    }
                }
            }
        }

        private List<DateTime> getBtcCrashTimes(List<Ohlc> btcCandles)
        {
            List<DateTime> ret = new List<DateTime>();

            for (int iCandleCounter = 0; iCandleCounter < btcCandles.Count - 1;)
            {
                Ohlc candle = btcCandles[iCandleCounter];
                DateTime dt = candle.Date;

                // Red candle
                if (candle.Close < candle.Open)
                {
                    double openVal = candle.Open;
                    double closeVal = candle.Close;



                    int innerCounter = 1;
                    while (btcCandles[iCandleCounter + innerCounter].Close < closeVal)
                    {
                        closeVal = btcCandles[iCandleCounter + innerCounter].Close;
                        innerCounter++;


                        if (iCandleCounter + innerCounter >= btcCandles.Count) break;
                    }

                    if (openVal - closeVal > 1000)
                    {
                        ret.Add(dt);
                    }

                    iCandleCounter += innerCounter;
                }
                else
                    iCandleCounter++;


            }

            return ret;
        }

        private void getHugeCandleUp()
        {
            foreach (string symbolP in DataController.readAllSymbols(SelectedRefSymbol))
            {
                List<Ohlc> candles = DataController.getCandles(
                                             symbol: symbolP,
                                             interval: SelectedInterval,
                                             start: StartDate,
                                             end: EndDate
                                             );


                if (candles.Count > 0)
                {
                    ChartAnalyzer = new CChartAnalyzer(candles);
                    if (ChartAnalyzer.anyHugeCandleAfterRed())
                    {
                        dctSymbolsVsCandles.Add(symbolP, candles);
                    }
                }

            }

        }

        public void setDataController(CBinanceDataController dataController)
        {
            DataController = dataController;
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            StartDate = dateTimePickerStart.Value;
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            EndDate = dateTimePickerEnd.Value;
        }

        private void cmbRefSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void resetToolStripUI(ToolStrip ts)
        {
            foreach (ToolStripItem item in ts.Items)
            {
                if (item is ToolStripButton)
                    (item as ToolStripButton).Checked = false;
            }
        }

        private void toolStripButton1d_Click(object sender, EventArgs e)
        {
            SelectedInterval = Binance.Net.Enums.KlineInterval.OneMinute;
            resetToolStripUI(toolStripIntervals);
            toolStripButton1d.Checked = true;
        }


        private void toolStripButton5d_Click(object sender, EventArgs e)
        {
            SelectedInterval = Binance.Net.Enums.KlineInterval.FiveMinutes;
            resetToolStripUI(toolStripIntervals);
            toolStripButton5d.Checked = true;
        }

        private void toolStripButton15d_Click(object sender, EventArgs e)
        {
            SelectedInterval = Binance.Net.Enums.KlineInterval.FifteenMinutes;
            resetToolStripUI(toolStripIntervals);
            toolStripButton15d.Checked = true;
        }

        private void toolStripButton1s_Click(object sender, EventArgs e)
        {
            SelectedInterval = Binance.Net.Enums.KlineInterval.OneHour;
            resetToolStripUI(toolStripIntervals);
            toolStripButton1s.Checked = true;
        }

        private void toolStripButton4s_Click(object sender, EventArgs e)
        {
            SelectedInterval = Binance.Net.Enums.KlineInterval.FourHour;
            resetToolStripUI(toolStripIntervals);
            toolStripButton4s.Checked = true;
        }

        private void toolStripButton1G_Click(object sender, EventArgs e)
        {
            SelectedInterval = Binance.Net.Enums.KlineInterval.OneDay;
            resetToolStripUI(toolStripIntervals);
            toolStripButton1G.Checked = true;
        }

        private void toolStripButton3G_Click(object sender, EventArgs e)
        {
            SelectedInterval = Binance.Net.Enums.KlineInterval.ThreeDay;
            resetToolStripUI(toolStripIntervals);
            toolStripButton3G.Checked = true;
        }

        private void toolStripButton1H_Click(object sender, EventArgs e)
        {
            SelectedInterval = Binance.Net.Enums.KlineInterval.OneWeek;
            resetToolStripUI(toolStripIntervals);
            toolStripButton1H.Checked = true;
        }

        private void toolStripButton1A_Click(object sender, EventArgs e)
        {
            SelectedInterval = Binance.Net.Enums.KlineInterval.OneMonth;
            resetToolStripUI(toolStripIntervals);
            toolStripButton1A.Checked = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbQuery_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {

        }

        private void dgvQueryResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Ohlc> candles = dctSymbolsVsCandles[dgvQueryResult.SelectedRows[0].Cells[0].Value.ToString()];

            if (candles.Count > 0)
            {
                CandleTableComp.CandleList = candles;
                CandleTableComp.updateUI();

                SymbolRenderer = new CSymbolRenderer(candles, ucCandleChart);
                SymbolRenderer.draw();
            }
        }

        private void dgvQueryResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (e.ColumnIndex >= 1)
            {
                e.CellStyle.Format = "n3";
            }
        }

        private void tsbtnUSDT_Click(object sender, EventArgs e)
        {
            SelectedRefSymbol = tsbtnUSDT.Text;
            resetToolStripUI(toolStripAssets);
            tsbtnUSDT.Checked = true;
        }

        private void tsbtnBUSD_Click(object sender, EventArgs e)
        {
            SelectedRefSymbol = tsbtnBUSD.Text;
            resetToolStripUI(toolStripAssets);
            tsbtnBUSD.Checked = true;
        }

        private void tsbtnBTC_Click(object sender, EventArgs e)
        {
            SelectedRefSymbol = tsbtnBTC.Text;
            resetToolStripUI(toolStripAssets);
            tsbtnBTC.Checked = true;
        }

        private void tsbtnBNB_Click(object sender, EventArgs e)
        {
            SelectedRefSymbol = tsbtnBNB.Text;
            resetToolStripUI(toolStripAssets);
            tsbtnBNB.Checked = true;
        }

        private void tsbtnETH_Click(object sender, EventArgs e)
        {
            SelectedRefSymbol = tsbtnETH.Text;
            resetToolStripUI(toolStripAssets);
            tsbtnETH.Checked = true;
        }
    }
}
