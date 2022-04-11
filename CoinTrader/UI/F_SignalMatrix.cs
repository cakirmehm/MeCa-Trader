using Binance.Net.Enums;
using BtcAnalyisTool.Source;
using CoinTrader.Source;
using NetTrader.Indicator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CoinTrader.UI
{
    public partial class F_SignalMatrix : DockContent
    {
        private CBinanceDataController DataController;
        private Dictionary<string, FileSystemWatcher> SymbolVsFileWatcher = new Dictionary<string, FileSystemWatcher>();
        private Dictionary<string, bool> SymbolVsUpdated = new Dictionary<string, bool>();
        private List<CSignalRow> SignalRows = new List<CSignalRow>();

        private static F_SignalMatrix instance;
        public static F_SignalMatrix getInstance()
        {
            if (instance == null)
                instance = new F_SignalMatrix();
            return instance;
        }

        private F_SignalMatrix()
        {
            InitializeComponent();

            dgvMatrix.DoubleBuffered(true);

            instance = this;
        }


        public void setDataController(CBinanceDataController dataController)
        {
            DataController = dataController;
        }

        public void initialize()
        {
            SignalRows.Clear();
            foreach (var sym in DataController.readAllSymbols("USDT"))
            {
                CSignalRow sRow = new CSignalRow()
                {
                    SymbolPair = sym,
                    LastPrice = 0.0,
                    LastVolume = 0.0,
                    Signal15m = EBuySell.NEUTRAL,
                    Signal1h = EBuySell.NEUTRAL,
                    Signal4h = EBuySell.NEUTRAL,
                    Signal1D = EBuySell.NEUTRAL
                };

                string symbolFolderPath = Path.Combine(CUtils.RootFolderPath, sym);

                if (!Directory.Exists(symbolFolderPath)) continue;

                FileSystemWatcher fsw = new FileSystemWatcher(symbolFolderPath);
                fsw.IncludeSubdirectories = true;
                fsw.NotifyFilter = NotifyFilters.Attributes |
                                    NotifyFilters.CreationTime |
                                    NotifyFilters.DirectoryName |
                                    NotifyFilters.FileName |
                                    NotifyFilters.LastAccess |
                                    NotifyFilters.LastWrite |
                                    NotifyFilters.Security |
                                    NotifyFilters.Size;
                fsw.Created += (sender, e) => {

                    CSignalRow sr = SignalRows.Find(s => s.SymbolPair.Equals(Directory.GetParent(e.FullPath).Name));
                    Ohlc lastCandle = fileToCandle(Path.GetFileNameWithoutExtension(e.FullPath));
                    if (sr != null && lastCandle != null)
                    {

                        sr.LastPrice = lastCandle.Close;
                        sr.LastVolume = lastCandle.Volume;
                        sr.Signal15m = checkForRSI(symbolFolderPath, sr.SymbolPair, KlineInterval.FifteenMinutes);
                        sr.Signal1h = checkForRSI(Path.Combine(symbolFolderPath, "1h"), sr.SymbolPair, KlineInterval.OneHour);
                        sRow.Signal4h = checkForRSI(Path.Combine(symbolFolderPath, "4h"), sr.SymbolPair,KlineInterval.FourHour);
                        sRow.Signal1D = checkForRSI(Path.Combine(symbolFolderPath, "1D"), sr.SymbolPair, KlineInterval.OneDay);

                        SymbolVsUpdated[sr.SymbolPair] = true;

                        //if (SymbolVsUpdated.All(k => k.Value == true))
                        {
                            UpdateDgv();

                            //SymbolVsUpdated.Clear();
                            //foreach (var row in SignalRows)
                            //{
                            //    SymbolVsUpdated.Add(row.SymbolPair, false);
                            //}
                        }
                    }
                    
                };
                SymbolVsUpdated.Add(sym, false);
                SymbolVsFileWatcher.Add(sym, fsw);
                SignalRows.Add(sRow);
                fsw.EnableRaisingEvents = true;
            }

            UpdateDgv(); 
        }

        private Ohlc fileToCandle(string fullPath)
        {
            string[] splitted = fullPath.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);

            if (splitted.Length == 7)
            {
                Ohlc ohlcNew = new Ohlc()
                {
                    Date = DateTime.ParseExact($"{splitted[0]}_{splitted[1]}", "yyyyMMdd_HHmm", new CultureInfo("en-US")),
                    Open = double.Parse(splitted[2], new CultureInfo("en-US")),
                    High = double.Parse(splitted[3], new CultureInfo("en-US")),
                    Low = double.Parse(splitted[4], new CultureInfo("en-US")),
                    Close = double.Parse(splitted[5], new CultureInfo("en-US")),
                    Volume = double.Parse(splitted[6], new CultureInfo("en-US")),
                };

                return ohlcNew;
            }

            return null;
        }

        void UpdateDgv()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(updateUI));
            }
            else
            {
                // Do Something
                updateUI();
            }
        }

        void updateUI()
        {
            // update gui here

            dgvMatrix.DataSource = SignalRows
               .OrderBy(s => s.SymbolPair)
               .ThenBy(s => s.Signal15m)
               .ThenBy(s => s.Signal1h)
               .ThenBy(s => s.Signal4h)
               .ThenBy(s => s.Signal1D)
               .ToList();
            dgvMatrix.Update();

        }


        private EBuySell checkForRSI(string symbolFolderPath, string symbolPair, KlineInterval interval)
        {
            List<Ohlc> candles = DataController.getCandlesCached(
                                             folderPath: symbolFolderPath,
                                             symbol: symbolPair,
                                             interval: interval,
                                             end: DateTime.Now,
                                             pNumOfInterval: 14
                                             );
       

            if (candles.Count == 14)
            {
                List<double> rsiValueList = new List<double>();

                RSI rsi = new RSI(14);

                rsi.Load(candles);
                RSISerie serie = rsi.Calculate();

                if (serie.RSI.Last().Value < 30.0)
                {
                    if (serie.RSI.Last().Value < 15)
                        return EBuySell.STRONG_BUY;
                    return EBuySell.BUY;
                }
                else if (serie.RSI.Last().Value > 70.0)
                {
                    if (serie.RSI.Last().Value > 90)
                        return EBuySell.STRONG_SELL;
                    return EBuySell.SELL;
                }
                else
                {
                    return EBuySell.NEUTRAL;
                }

            }

            return EBuySell.NEUTRAL;
        }

        private void dgvMatrix_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CSignalRow sr = dgvMatrix.Rows[e.RowIndex].DataBoundItem as CSignalRow;

                if (e.ColumnIndex == 1)
                {
                    e.CellStyle.Format = "C4";
                    e.CellStyle.FormatProvider = new CultureInfo("en-US");
                }

                if (e.ColumnIndex == 2)
                {
                    e.CellStyle.Format = "N2";
                    e.CellStyle.FormatProvider = new CultureInfo("en-US");
                }

                if (e.ColumnIndex == 3)
                {
                   

                    if (sr.Signal15m == EBuySell.BUY) e.CellStyle.BackColor = Color.LightGreen;
                    else if (sr.Signal15m == EBuySell.SELL) e.CellStyle.BackColor = Color.LightCoral;
                    else if (sr.Signal15m == EBuySell.STRONG_BUY) e.CellStyle.BackColor = Color.DarkGreen;
                    else if (sr.Signal15m == EBuySell.STRONG_SELL) e.CellStyle.BackColor = Color.Coral;
                    else if (sr.Signal15m == EBuySell.NEUTRAL) e.CellStyle.BackColor = Color.White;
                }
              

                if (e.ColumnIndex == 4)
                {
                    if (sr.Signal1h == EBuySell.BUY) e.CellStyle.BackColor = Color.LightGreen;
                    else if (sr.Signal1h == EBuySell.SELL) e.CellStyle.BackColor = Color.LightCoral;
                    else if (sr.Signal1h == EBuySell.STRONG_BUY) e.CellStyle.BackColor = Color.DarkGreen;
                    else if (sr.Signal1h == EBuySell.STRONG_SELL) e.CellStyle.BackColor = Color.Coral;
                    else if (sr.Signal1h == EBuySell.NEUTRAL) e.CellStyle.BackColor = Color.White;
                }
               

                if (e.ColumnIndex == 5)
                {
                    if (sr.Signal4h == EBuySell.BUY) e.CellStyle.BackColor = Color.LightGreen;
                    else if (sr.Signal4h == EBuySell.SELL) e.CellStyle.BackColor = Color.LightCoral;
                    else if (sr.Signal4h == EBuySell.STRONG_BUY) e.CellStyle.BackColor = Color.DarkGreen;
                    else if (sr.Signal4h == EBuySell.STRONG_SELL) e.CellStyle.BackColor = Color.Coral;
                    else if (sr.Signal4h == EBuySell.NEUTRAL) e.CellStyle.BackColor = Color.White;
                }
                
                if (e.ColumnIndex == 6)
                {
                    if (sr.Signal1D == EBuySell.BUY) e.CellStyle.BackColor = Color.LightGreen;
                    else if (sr.Signal1D == EBuySell.SELL) e.CellStyle.BackColor = Color.LightCoral;
                    else if (sr.Signal1D == EBuySell.STRONG_BUY) e.CellStyle.BackColor = Color.DarkGreen;
                    else if (sr.Signal1D == EBuySell.STRONG_SELL) e.CellStyle.BackColor = Color.Coral;
                    else if (sr.Signal1D == EBuySell.NEUTRAL) e.CellStyle.BackColor = Color.White;
                }
               
            }
            

        }
    }

    public class CSignalRow
    {
        public string SymbolPair { get; set; }
        public double LastPrice { get; set; }
        public double LastVolume { get; set; }

        public EBuySell Signal15m { get; set; }
        public EBuySell Signal1h { get; set; }
        public EBuySell Signal4h { get; set; }
        public EBuySell Signal1D { get; set; }
    }

    public enum EBuySell
    {
        NEUTRAL = 0,
        BUY,
        SELL,
        STRONG_BUY,
        STRONG_SELL
    }
}
