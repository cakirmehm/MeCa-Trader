using CoinTrader.Fibonacci;
using NetTrader.Indicator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTrader.Source
{
    public class CChartAnalyzer
    {
        public List<Ohlc> Candles { get; set; } = new List<Ohlc>();
        private CFibboLevels FibonacciLevels;

        private double Support2;
        private double Resistance2;

        public CChartAnalyzer(List<Ohlc> ohlcList)
        {
            Candles = new List<Ohlc>();
            Candles.AddRange(ohlcList);
            FibonacciLevels = CFibonacciRetracement.GetFibboLevels(Candles.Min(c => c.Open), Candles.Max(c => c.Close));
        }

        public CChartAnalyzer(double minVal, double maxVal)
        {
            FibonacciLevels = CFibonacciRetracement.GetFibboLevels(minVal, maxVal);
        }

        public double calculateSupport(double price)
        {
            if (FibonacciLevels != null)
            {
                return FibonacciLevels.GetSupportValue(price, ref Support2);
            }

            return -1.0;
        }

        public double calculateResistance(double price)
        {
            if (FibonacciLevels != null)
            {
                return FibonacciLevels.GetResistanceValue(price, ref Resistance2);
            }

            return -1.0;
        }

        public List<string> getDates()
        {
            return Candles.Select(c => c.Date.ToString("yyyy.MM.dd HH:mm")).ToList();
        }

        public List<double> calculateEMA9()
        {
            EMA ema9 = new EMA(9, true, ColumnType.Close);
            ema9.Load(Candles);
            List<double> ema9Serie = new List<double>();
            foreach (var item in ema9.Calculate().Values)
            {
                if (item.HasValue == false)
                    ema9Serie.Add(0);
                else
                    ema9Serie.Add(item.Value);
            }
            return ema9Serie;
        }

        public List<double> calculateEMA30()
        {
            EMA ema30 = new EMA(30, true, ColumnType.Close);
            ema30.Load(Candles);
            List<double> ema30Serie = new List<double>();
            foreach (var item in ema30.Calculate().Values)
            {
                if (item.HasValue == false)
                    ema30Serie.Add(0);
                else
                    ema30Serie.Add(item.Value);
            }

            return ema30Serie;
        }

        public double getResistance2()
        {
            return Resistance2;
        }

        public double getSupport2()
        {
            return Support2;
        }

        public List<double> getVolumes(bool addPrices = false)
        {
            double minLevel = Candles.Min(c => c.Close);
            double maxLevel = Candles.Max(c => c.Close);

            double maxLevelVol = Candles.Max(c => c.Volume);
            double minLevelVol = Candles.Min(c => c.Volume);

            double scale = (maxLevel - minLevel) / (maxLevelVol - minLevelVol);

            if (addPrices)
                return Candles.Select(c => minLevel + c.Volume * scale).ToList();
            return Candles.Select(c => c.Volume).ToList();
        }

        public List<double> getVolumesDecreasing()
        {
            List<double> retArr = new List<double>();

            double minLevel = Candles.Min(c => c.Close);
            double maxLevel = Candles.Max(c => c.Close);

            double maxLevelVol = Candles.Max(c => c.Volume);
            double minLevelVol = Candles.Min(c => c.Volume);

            double scale = (maxLevel - minLevel) / (maxLevelVol - minLevelVol);

            foreach (var item in Candles.ToList())
            {
                if (item.Open > item.Close)
                {
                    retArr.Add(minLevel + item.Volume * scale);
                }
                else
                {
                    retArr.Add(0);
                }
            }

            return retArr;

        }

        public List<double> getVolumesIncreasing()
        {
            List<double> retArr = new List<double>();

            double minLevel = Candles.Min(c => c.Close);
            double maxLevel = Candles.Max(c => c.Close);

            double maxLevelVol = Candles.Max(c => c.Volume);
            double minLevelVol = Candles.Min(c => c.Volume);

            double scale = (maxLevel - minLevel) / (maxLevelVol - minLevelVol);

            foreach (var item in Candles.ToList())
            {
                if (item.Open <= item.Close)
                {
                    retArr.Add(minLevel + item.Volume * scale);
                }
                else
                {
                    retArr.Add(0);
                }
            }

            return retArr;

        }

        public bool anyHugeVolumeIncrease()
        {
            List<double> increaseList = new List<double>();
            
            for (int i = 1; i < Candles.Count; i++)
            {
                double volPrev = Candles[i - 1].Volume;
                double pricePrev = Candles[i - 1].Close;

                double volCurr = Candles[i].Volume;
                double priceCurr = Candles[i].Close;

                if (volCurr > volPrev)
                {
                    increaseList.Add(volCurr - volPrev);
                }

            }

            double avgDiff = increaseList.Average();
            double maxDiff = increaseList.Max();

            if (maxDiff > 7 * avgDiff)
            {
                return true;
            }

            return false;
        }


        public bool anyMACDSellSignal()
        {
            return false;

        }

        public bool anyMACDBuySignal()
        {
           
            MACD macd = new MACD(12,26,9);
            macd.Load(Candles);
            MACDSerie macdSerie = macd.Calculate();
            

            for (int i = macdSerie.MACDHistogram.Count - 3; i < macdSerie.MACDHistogram.Count; i++)
            {
                if (macdSerie.MACDHistogram[i - 1].HasValue &&
                    macdSerie.MACDHistogram[i].HasValue &&
                    macdSerie.MACDLine[i - 1].HasValue &&
                    macdSerie.MACDLine[i].HasValue &&
                    macdSerie.Signal[i - 1].HasValue &&
                    macdSerie.Signal[i].HasValue)
                {
                    double histValPrev = macdSerie.MACDHistogram[i - 1].Value;
                    double histValCurr = macdSerie.MACDHistogram[i].Value;

                    double macdLineValPrev = macdSerie.MACDLine[i - 1].Value;
                    double macdLineValCurr = macdSerie.MACDLine[i].Value;

                    double signalLineValPrev = macdSerie.Signal[i - 1].Value;
                    double signalLineValCurr = macdSerie.Signal[i].Value;

                    if (histValCurr < 0.0)
                    {
                        int sign = Math.Sign(macdLineValPrev - signalLineValPrev) *
                             Math.Sign(signalLineValPrev - signalLineValCurr);

                        if (sign < 0)
                            return true;
                    }
                   
                }

            }


            return false;
        }


        public bool anyCurrentVolumeIncrease()
        {

            return Candles[0].Volume < Candles[1].Volume &&
                    Candles[0].Open < Candles[0].Close &&
                    Candles[1].Open < Candles[1].Close &&
                Candles[1].Volume < Candles[2].Volume &&
                    Candles[1].Open < Candles[1].Close &&
                    Candles[2].Open < Candles[2].Close;
        }


        public bool anyLatestVolumeSpike()
        {
            Ohlc last = Candles[Candles.Count - 1];
            Ohlc lastBefore = Candles[Candles.Count - 2];
           

            return (
                last.Volume > 2.0 * lastBefore.Volume  && 
                last.Close > last.Open && 
                lastBefore.Close > lastBefore.Open);
        }

        public bool anyTwoGreenVolumesAtCurrent()
        {
            Ohlc last = Candles[Candles.Count - 1];
            Ohlc lastBefore = Candles[Candles.Count - 2];


            return (last.Close > last.Open && lastBefore.Close > lastBefore.Open);
        }

        public bool anyHugeCandleAfterRed()
        {
            Ohlc last = Candles.Last();
            Ohlc last1 = Candles[Candles.Count - 2];


            return (last1.Close < last1.Open && last.Close > last.Open * 1.1);
        }

        public bool anyLatestPriceSpike()
        {
            Ohlc last = Candles.Last();
          

            return (last.Close > 1.10 * last.Open);
        }



        public bool anyRSIBelow30()
        {
            List<double> rsiValueList = new List<double>();

            RSI rsi = new RSI(Math.Min(Candles.Count, 7));

            rsi.Load(Candles);
            RSISerie serie = rsi.Calculate();

            return serie.RSI.Last().Value < 30.0;

        }

        public bool anyRSIOver70()
        {
            List<double> rsiValueList = new List<double>();

            RSI rsi = new RSI(Math.Min(Candles.Count, 7));

            rsi.Load(Candles);
            RSISerie serie = rsi.Calculate();

            return serie.RSI.Last().Value > 70.0;
        }


        public bool anyGoldenCross()
        {
            List<bool> goldenList = new List<bool>();

            EMA movAvg30 = new EMA(30, false, ColumnType.Close);
            EMA movAvg9 = new EMA(9, false, ColumnType.Close);

            movAvg30.Load(Candles);
            movAvg9.Load(Candles);

            SingleDoubleSerie movAvg30Serie = movAvg30.Calculate();
            SingleDoubleSerie movAvg9Serie = movAvg9.Calculate();

            for (int i = 0; i < Candles.Count; i++)
            {
                if (movAvg30Serie.Values[i].HasValue && movAvg9Serie.Values[i].HasValue)
                {
                    goldenList.Add(movAvg30Serie.Values[i].Value > movAvg9Serie.Values[i].Value);
                }
                else
                {
                    goldenList.Add(true);
                }

                if (goldenList[i] == false)
                {
                    Console.WriteLine($"Golden cross at {i} for price {Candles[i].Close} at {Candles[i].Date}");
                    return true;
                }
            }

            return false;
        }


        public List<double> calculateFibo23()
        {

           

            List<double> fib23Level = new List<double>();
            for (int i = 0; i < Candles.Count; i++)
            {
                fib23Level.Add(FibonacciLevels.RetracementLevel_23_6);
            }

            return fib23Level;

        }

        public List<double> getOpenPrices(bool addVolume = false)
        {
            double first = Candles.Max(c => c.Volume) / Candles.Max(c => c.Open);

            if (addVolume)
                return Candles.Select(c => c.Open * first).ToList();
            return Candles.Select(c => c.Open).ToList();
        }

        public List<double> getClosePrices(bool addVolume = false)
        {
            double first = Candles.Max(c => c.Volume) / Candles.Max(c => c.Close);

            if (addVolume)
                return Candles.Select(c => c.Close * first).ToList();
            return Candles.Select(c => c.Close).ToList();
        }

        public List<double> calculateFibo38()
        {
            List<double> fib38Level = new List<double>();
            for (int i = 0; i < Candles.Count; i++)
            {
                fib38Level.Add(FibonacciLevels.RetracementLevel_38_2);
            }

            return fib38Level;

        }
    }
}
