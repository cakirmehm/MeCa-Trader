using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinTrader.Fibonacci;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using NetTrader.Indicator;

namespace CoinTrader.Source
{
    class CSymbolRenderer
    {
        private CChartAnalyzer ChartAnalyzer;
        private LiveCharts.WinForms.CartesianChart cartesianChartCandles;
     

        public CSymbolRenderer(List<Ohlc> ohclList, LiveCharts.WinForms.CartesianChart ucCandleChart)
        {
            cartesianChartCandles = ucCandleChart;
            
            ChartAnalyzer = new CChartAnalyzer(ohclList);
        }

        public void draw()
        {
            cartesianChartCandles.DisableAnimations = false;
            cartesianChartCandles.AxisX = new AxesCollection()
            {
               new Axis()
               {
                   Name = "Date",
                   ShowLabels = true,
                   VerticalAlignment = System.Windows.VerticalAlignment.Stretch,
                   Labels = ChartAnalyzer.getDates().ToArray()

               }
               
            };

            cartesianChartCandles.AxisY = new AxesCollection()
            {
               new Axis()
               {
                   Name = "Price",
                   ShowLabels = true,
                   VerticalAlignment = System.Windows.VerticalAlignment.Stretch
               },
               new Axis()
               {
                   Name = "Volume",
                   ShowLabels = false,
                   VerticalAlignment = System.Windows.VerticalAlignment.Stretch,
                   
               }
               
            };


            LineSeries PriceSeries = new LineSeries
            {
                Name = "Price",
                Title = "Price",
                Values = new ChartValues<double>(ChartAnalyzer.getClosePrices()),
                //Foreground = System.Windows.Media.Brushes.Blue,
                StrokeThickness = 3,
                //PointGeometry = null,

            };

            ColumnSeries VolumeSeries = new ColumnSeries
            {
                Name = "Volume",
                Title = "Volume",
                Values = new ChartValues<double>(ChartAnalyzer.getVolumes(true)),
                Opacity = 0.5,
                StrokeThickness = 1,
                //PointGeometry = null,
                Fill = System.Windows.Media.Brushes.Red
            };

            cartesianChartCandles.Series = new SeriesCollection
            {

                PriceSeries,
                VolumeSeries,

                //new LineSeries
                //{
                //    Name = "EMA9",
                //    Title = "EMA-9",
                //    Values = new ChartValues<double>(ChartAnalyzer.calculateEMA9()),
                //    Foreground = System.Windows.Media.Brushes.Aqua,
                //    StrokeThickness = 1,
                //    //PointGeometry = null,

                //},

                //new LineSeries
                //{
                //    Name = "EMA30",
                //    Title = "EMA-30",
                //    Values = new ChartValues<double>(ChartAnalyzer.calculateEMA30()),
                //    Foreground = System.Windows.Media.Brushes.Orange,
                //    StrokeThickness = 0.01,
                //    PointGeometry = null,
                //},


                //new LineSeries
                //{
                //    Name = "Fib23",
                //    Title = "Fibonacci 23",
                //    Values = new ChartValues<double>(ChartAnalyzer.calculateFibo23()),
                //    //LineSmoothness = 0,
                //    PointGeometry = null,
                //    Foreground = System.Windows.Media.Brushes.Gray,

                //},

                //new LineSeries
                //{
                //    Name = "Fib38",
                //    Title = "Fibonacci 38",
                //    Values = new ChartValues<double>(ChartAnalyzer.calculateFibo38()),
                //    PointGeometry = null,
                //    Foreground = System.Windows.Media.Brushes.Gray,
                //    OpacityMask = null
                //},

                // new LineSeries
                //{
                //    Name = "Fib61",
                //    Title = "Fibonacci 61",
                //    Values = new ChartValues<double>(fib61Level),
                //    PointGeometry = null,
                //    Foreground = System.Windows.Media.Brushes.Gray,
                //    OpacityMask = null
                //}




            };

            //cartesianChartCandles.BackColorTransparent = false;

            //cartesianChartCandles.AxisX.Add(new Axis
            //{
            //    Title = "Month",
            //    Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
            //});

            //cartesianChartCandles.AxisY.Add(new Axis
            //{
            //    Title = "BTCUSDT",
            //    LabelFormatter = value => value.ToString("C")
            //});



            //cartesianChart1.DataClick += CartesianChart1OnDataClick;


           


        }
    }
}
