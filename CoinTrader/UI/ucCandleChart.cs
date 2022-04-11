using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetTrader.Indicator;
using System.Windows.Forms.DataVisualization.Charting;

namespace CoinTrader.UI
{
    public partial class ucCandleChart : UserControl
    {
        public List<Ohlc> OhlcList { get; set; } = new List<Ohlc>();

        public ucCandleChart()
        {
            InitializeComponent();

            
            
        }



        #region WinformDefaultCandleChartCodes
        public void updateUI()
        {

            chartCandles.Series.Clear();

            Series price = new Series("price"); // <<== make sure to name the series "price"
            chartCandles.Series.Add(price);

            // Set series chart type
            chartCandles.Series["price"].ChartType = SeriesChartType.Candlestick;

            // Set the style of the open-close marks
            chartCandles.Series["price"]["OpenCloseStyle"] = "Triangle";

            // Show both open and close marks
            chartCandles.Series["price"]["ShowOpenClose"] = "Both";

            // Set point width
            chartCandles.Series["price"]["PointWidth"] = "1.0";

            // Set colors bars
            chartCandles.Series["price"]["PriceUpColor"] = "Green"; // <<== use text indexer for series
            chartCandles.Series["price"]["PriceDownColor"] = "Red"; // <<== use text indexer for series

            chartCandles.Series["price"].Palette = ChartColorPalette.SemiTransparent;

            chartCandles.ChartAreas["ChartArea1"].AxisY.Minimum = OhlcList.Min(o => o.Low);
            chartCandles.ChartAreas["ChartArea1"].AxisY.Maximum = OhlcList.Max(o => o.High);

            chartCandles.Palette = ChartColorPalette.SemiTransparent;
            

            for (int i = 0; i < OhlcList.Count; i++)
            {
                // adding date and high
                chartCandles.Series["price"].Points.AddXY(OhlcList[i].Date, OhlcList[i].High);
                // adding low
                chartCandles.Series["price"].Points[i].YValues[1] = OhlcList[i].Low;
                //adding open
                chartCandles.Series["price"].Points[i].YValues[2] = OhlcList[i].Open;
                // adding close
                chartCandles.Series["price"].Points[i].YValues[3] = OhlcList[i].Close;
            }



        }
        #endregion
    }
}
