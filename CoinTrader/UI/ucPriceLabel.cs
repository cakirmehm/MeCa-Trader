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
using LiveCharts.Wpf;
using LiveCharts;
using System.Globalization;
using NetTrader.Indicator;

namespace CoinTrader.UI
{
    public partial class ucPriceLabel : UserControl
    {
        private CChartAnalyzer ChartAnalyzer;

        public double CurrPrice { get; set; }
        public double PrevPrice { get; set; }
        public double MinVal { get; set; }
        public double MaxVal { get; set; }
        public double Support1 { get; set; }
        public double Support2 { get; set; }
        public double Resistance1 { get; set; }
        public double Resistance2 { get; set; }

        public ETrend Trend { get; set; } = ETrend.HORIZONTAL;

        public bool AutoTrade { get; set; } = false;
        public bool TelegramSignal { get; set; } = true;

        private List<double> ValuesOfChart = new List<double>();
        private List<Ohlc> OhlcList = new List<Ohlc>();

        private Dictionary<string, Label> dctLabels = new Dictionary<string, Label>();

        public ucPriceLabel()
        {
            InitializeComponent();

            dctLabels.Add("MACD", lblIndicatorMACD);
            dctLabels.Add("RSI", lblIndicatorRSI);
            dctLabels.Add("MA", lblIndicatorMA);
            dctLabels.Add("FIB", lblIndicatorFIB);
        }

        public void setPrice(string symbol, double value, double minVal, double maxVal)
        {
            CurrPrice = value;
            MinVal = minVal;
            MaxVal = maxVal;
           
            lblCurrentPriceInUSD.Text = value.ToString("C8", CultureInfo.GetCultureInfo("en-US"));

            // Circular buffering
            ValuesOfChart.Add(value);
            if (ValuesOfChart.Count == 100) ValuesOfChart.RemoveAt(0);

            // Update Trend

            Trend = (CurrPrice / PrevPrice) > 1.002
                 ? ETrend.UP
                 : (CurrPrice / PrevPrice) < 0.998
                        ? ETrend.DOWN
                        : ETrend.HORIZONTAL;
                    

            lblMinVal.Text = minVal.ToString("C8", CultureInfo.GetCultureInfo("en-US"));
            lblMaxVal.Text = maxVal.ToString("C8", CultureInfo.GetCultureInfo("en-US"));
            lblSymbol.Text = symbol;

            checkAnyFibonacciRetraceSignal(value);
            checkAnyRSISignal(value);

            PrevPrice = value;
        }

        private void checkAnyRSISignal(double value)
        {
            ChartAnalyzer = new CChartAnalyzer(MinVal, MaxVal);   
        }

        private void checkAnyFibonacciRetraceSignal(double value)
        {
            if (value > Resistance1 || value < Support1)
            {
                Support1 = ChartAnalyzer.calculateSupport(value);
                Resistance1 = ChartAnalyzer.calculateResistance(value);

                Support2 = ChartAnalyzer.getSupport2();
                Resistance2 = ChartAnalyzer.getResistance2();

                updateUISupportResistance();
            }
            else if (value < Support1 * 1.002 && value > Support1 && Trend == ETrend.DOWN)
            {
                setBuyLabel("FIB");

                if (AutoTrade)
                {
                    F_AutoTrade.getInstance().buyAuto(lblSymbol.Text, CurrPrice, TargetPrice: Resistance1, TargetTradeType: ETradeDirection.SELL);
                }

                //if (TelegramSignal)
                //{
                //    CTelegramDataController.getInstance().TelegramSendMessage($"FIB-AL:{lblSymbol.Text}\n" +
                //        $"Fiyat  : {CurrPrice.ToString("C4", CultureInfo.GetCultureInfo("en-US"))})\n" +
                //        $"Hedef-1: {Resistance1.ToString("C4", CultureInfo.GetCultureInfo("en-US"))}\n" +
                //        $"Hedef-2: {Resistance2.ToString("C4", CultureInfo.GetCultureInfo("en-US"))}");
                //}

            }
            else if (value > Resistance1 * 0.998 && value < Resistance1 && Trend == ETrend.UP)
            {
                setSellLabel("FIB");

                if (AutoTrade)
                {
                    F_AutoTrade.getInstance().sellAuto(lblSymbol.Text, CurrPrice);
                }

                //if (TelegramSignal)
                //{
                //    CTelegramDataController.getInstance().TelegramSendMessage($"FIB-SAT:{lblSymbol.Text}\n" +
                //        $"Fiyat: {CurrPrice.ToString("C4", CultureInfo.GetCultureInfo("en-US"))}");
                //}
            }
            else
            {
                setHoldLabel("FIB");
            }
        }

        public void setBuyLabel(string type)
        {
            dctLabels[type].Text = $"{type}: AL";
            dctLabels[type].ForeColor = Color.Black;
            dctLabels[type].BackColor = Color.LightGreen;

            lblSupport1.BackColor = Color.LightGreen;
            lblResistance1.BackColor = Color.Empty;
        }

        public void setSellLabel(string type)
        {
            dctLabels[type].Text = $"{type}: SAT";
            dctLabels[type].ForeColor = Color.Black;
            dctLabels[type].BackColor = Color.LightCoral;

            lblSupport1.BackColor = Color.Empty;
            lblResistance1.BackColor = Color.LightCoral;
        }

        public void setHoldLabel(string type)
        {
            dctLabels[type].Text = $"{type}";
            dctLabels[type].ForeColor = Color.Gray;
            dctLabels[type].BackColor = Color.Empty;

            lblSupport1.BackColor = Color.Empty;
            lblResistance1.BackColor = Color.Empty;
        }

        private void lblCurrentPriceInUSD_TextChanged(object sender, EventArgs e)
        {
            if (CurrPrice > PrevPrice)
            {
                lblCurrentPriceInUSD.ForeColor = Color.Green;
                //greenCounter++;
            }
            else
            {
                lblCurrentPriceInUSD.ForeColor = Color.Red;
                //redCounter++;
            }

            updateChart();
        }

        private void lblMaxVal_TextChanged(object sender, EventArgs e)
        {
            ChartAnalyzer = new CChartAnalyzer(MinVal, MaxVal);
            Support1 = ChartAnalyzer.calculateSupport(CurrPrice);
            Resistance2 = ChartAnalyzer.calculateResistance(CurrPrice);
            Support2 = ChartAnalyzer.getSupport2();
            Resistance2 = ChartAnalyzer.getResistance2();

            updateUISupportResistance();
        }



        private void lblMinVal_TextChanged(object sender, EventArgs e)
        {
            ChartAnalyzer = new CChartAnalyzer(MinVal, MaxVal);
            Support1 = ChartAnalyzer.calculateSupport(CurrPrice);
            Resistance1 = ChartAnalyzer.calculateResistance(CurrPrice);
            Support2 = ChartAnalyzer.getSupport2();
            Resistance2 = ChartAnalyzer.getResistance2();

            updateUISupportResistance();
            
        }

        private void updateChart()
        {
            cartesianChart.DisableAnimations = true;

            cartesianChart.AxisX = new AxesCollection()
            {
               new Axis()
               {
                   Name = "DateTime",
                   ShowLabels = false,
                   VerticalAlignment = System.Windows.VerticalAlignment.Stretch
               }
            };

            cartesianChart.AxisY = new AxesCollection()
            {
               new Axis()
               {
                   Name = "Price",
                   ShowLabels = false,
                   VerticalAlignment = System.Windows.VerticalAlignment.Stretch
               }
            };

           
            cartesianChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Name = "Price",
                    Title = "Price",
                    Values = new ChartValues<double>(ValuesOfChart),
                    //Foreground = System.Windows.Media.Brushes.Blue,
                    StrokeThickness = 1,
                    PointGeometry = null,

                }

                
            };

            //SMA sma = new SMA(7, ColumnType.Close);
            //sma.Load(OhlcList);
            //SingleDoubleSerie smaArray = sma.Calculate();
            //List<double> smaArrayList = new List<double>();
            //foreach (var item in smaArray.Values)
            //{
            //    if (item.HasValue) smaArrayList.Add(item.Value);
            //}

            //if (smaArrayList.Count > 7)
            //{
            //    cartesianChart.Series.Add(new LineSeries
            //    {
            //        Name = "MA50",
            //        Title = "MA-50",
            //        Values = new ChartValues<double>(smaArrayList),
            //        //Foreground = System.Windows.Media.Brushes.Blue,
            //        StrokeThickness = 1,
            //        PointGeometry = null,
            //        Fill = System.Windows.Media.Brushes.Orange,
            //        Opacity = 0.1
            //    });
            //}
            


        }

        private void updateUISupportResistance()
        {
            lblSupport1.Text = Support1.ToString("C8", CultureInfo.GetCultureInfo("en-US"));
            lblResistance1.Text = Resistance1.ToString("C8", CultureInfo.GetCultureInfo("en-US"));

            lblSupport2.Text = Support2.ToString("C8", CultureInfo.GetCultureInfo("en-US"));
            lblResistance2.Text = Resistance2.ToString("C8", CultureInfo.GetCultureInfo("en-US"));
        }

        public void setOhlcList(List<Ohlc> retList)
        {
            OhlcList.Clear();
            OhlcList.AddRange(retList);

            ChartAnalyzer = new CChartAnalyzer(OhlcList);
            if (ChartAnalyzer.anyRSIBelow30())
            {
                setBuyLabel("RSI");
            }
            else if (ChartAnalyzer.anyRSIOver70())
            {
                setSellLabel("RSI");
            }
            else
            {
                setHoldLabel("RSI");
            }

            if (ChartAnalyzer.anyGoldenCross())
            {
                setBuyLabel("MA");
            }
            else
            {
                setHoldLabel("MA");
            }
             
            
            if (ChartAnalyzer.anyMACDBuySignal())
            {
                setBuyLabel("MACD");
            }
            else if (ChartAnalyzer.anyMACDSellSignal())
            {
                setSellLabel("MACD");
            }
            else
            {
                setHoldLabel("MACD");
            }
        }

        public void updateLabel(string symbol, double value, double minVal, double maxVal)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => updateLabel(symbol, value, minVal, maxVal)));
                return;
            }

            setLabelValue(symbol, value, minVal, maxVal);
        }

        private void setLabelValue(string symbol, double value, double minVal, double maxVal)
        {
            setPrice(symbol, value, minVal, maxVal);

        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                foreach (Control cnt in this.Parent.Controls)
                {
                    if (cnt.Name == this.Name)
                    {
                        this.Parent.Controls.Remove(this);
                    }
                }
            }
        }
    }

    public enum ETrend
    {
        HORIZONTAL = 0,
        UP = 1,
        DOWN = 2
    }
}
