using Binance.Net;
using Binance.Net.Enums;
using Binance.Net.Objects.Spot;
using Binance.Net.Objects.Spot.SpotData;
using Binance.Net.Objects.Spot.WalletData;
using CoinTrader.UI;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using NetTrader.Indicator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CoinTrader.Source
{
    public class CBinanceDataController
    {
        private const string root = "https://api.binance.com";
        

        private BinanceClient BClient = null;
        private BinanceSocketClient SocketClient = null;
        public BindingList<CSymbolTicker> SymbolTickers { get; set; } = new BindingList<CSymbolTicker>();

        public Dictionary<string, List<string>> DctUnitsVsSymbolPairs { get; set; } = new Dictionary<string, List<string>>();

        private string API_KEY;

        private string API_SECRET_KEY;

       

        public CBinanceDataController(string sApiKey, string sApiSecretKey)
        {
            API_KEY = sApiKey;
            API_SECRET_KEY = sApiSecretKey;
        }

        public async Task Start()
        {
            BClient = new BinanceClient(new BinanceClientOptions()
            {
                ApiCredentials = new ApiCredentials(API_KEY, API_SECRET_KEY)
                

            });

            // Spot.Market | Spot market info endpoints
            //BClient.Spot.Market.GetBookPrice("BTCUSDT");
            // Spot.Order | Spot order info endpoints
            //BClient.Spot.Order.GetAllOrders("BTCUSDT");
            // Spot.System | Spot system endpoints
            BClient.Spot.System.GetExchangeInfo();
            // Spot.UserStream | Spot user stream endpoints. Should be used to subscribe to a user stream with the socket client
            var startResult = BClient.Spot.UserStream.StartUserStream();
            // Spot.Futures | Transfer to/from spot from/to the futures account + cross-collateral endpoints
            BClient.Spot.Futures.TransferFuturesAccount("ASSET", 1, FuturesTransferType.FromSpotToUsdtFutures);



            //var subTask1 = SocketClient.Spot.SubscribeToSymbolTickerUpdates("BTCUSDT", handler);
            //var subTask2 = SocketClient.Spot.SubscribeToSymbolTickerUpdates("RCNUSDT", handler);
            //var subTask3 = SocketClient.Spot.SubscribeToSymbolTickerUpdates("HOTUSDT", handler);
            ////await Task.WhenAll(new[] { subTask1, subTask2, subTask3 });

     

            // General | General/account endpoints
            await BClient.General.GetAccountInfoAsync();




            if (!startResult.Success)
                throw new Exception($"Failed to start user stream: {startResult.Error}");

            SocketClient = new BinanceSocketClient();

            BinanceSocketClient.SetDefaultOptions(new BinanceSocketClientOptions()
            {
                ApiCredentials = new ApiCredentials(API_KEY, API_SECRET_KEY),
                LogVerbosity = LogVerbosity.None,
                //LogWriters = new List<TextWriter> { Console.Out }
            });

            //SocketClient.Spot.SubscribeToUserDataUpdates(startResult.Data,
            //    orderUpdate => { // Handle order update
                    
            //    },
            //    ocoUpdate => { // Handle oco order update
            //    },
            //    positionUpdate => { // Handle account position update
            //    },
            //    balanceUpdate => { // Handle balance update
            //        Console.WriteLine(balanceUpdate.Event);
            //    });

            //var coins = BClient.WithdrawDeposit.GetDepositHistory();

         

            //var kasets = BClient.WithdrawDeposit.GetWithdrawalHistory();

            //var dailySpot = BClient.General.GetDailySpotAccountSnapshot(new DateTime(2021, 3, 4), new DateTime(2021, 4, 20));
            //foreach (BinanceSpotAccountSnapshot sp in dailySpot.Data)
            //{



            //    Console.WriteLine($"Total Sat: {sp.Data.TotalAssetOfBtc} on {sp.Timestamp}");
            //    foreach (var item in sp.Data.Balances)
            //    {

            //        if (item.Total > 0)
            //        {
            //            var priceD = BClient.Spot.Market.GetKlines($"{item.Asset}USDT", KlineInterval.OneDay, new DateTime(2021, 4, 1), new DateTime(2021, 4, 20));

            //            //var closPrice = priceD.Data.ToList().Find(h => h.CloseTime.ToString() == sp.Timestamp.ToString());
            //            //if (closPrice == null) continue;

            //            Console.WriteLine($"   {item.Asset} : {item.Total} -- {1}");
            //        }

            //    }
            //    Console.WriteLine("---");
            //}


        }

        public List<BinanceTrade> getTradeHistory(string asset)
        {
            List<BinanceTrade> tradeList = new List<BinanceTrade>();
            try
            {
                var tradesUSDT = BClient.Spot.Order.GetMyTrades($"{asset}USDT");
                tradeList.AddRange(tradesUSDT.Data.OrderBy(t => t.TradeTime));
            }
            catch (Exception exc)
            {
                Console.WriteLine("USDT" + exc.ToString());
            }

            try
            {
                var tradesBUSD = BClient.Spot.Order.GetMyTrades($"{asset}BUSD");
                tradeList.AddRange(tradesBUSD.Data.OrderBy(t => t.TradeTime));
            }
            catch (Exception exc)
            {
                Console.WriteLine("BUSD" + exc.ToString());
            }

            try
            {
                var tradesBTC = BClient.Spot.Order.GetMyTrades($"{asset}BTC");
                tradeList.AddRange(tradesBTC.Data.OrderBy(t => t.TradeTime));
            }
            catch (Exception exc)
            {
                Console.WriteLine("BTC" + exc.ToString());
            }

            try
            {
                var tradesBNB = BClient.Spot.Order.GetMyTrades($"{asset}BNB");
                tradeList.AddRange(tradesBNB.Data.OrderBy(t => t.TradeTime));
            }
            catch (Exception exc)
            {
                Console.WriteLine("BNB" + exc.ToString());
            }

            try
            {
                var tradesETH = BClient.Spot.Order.GetMyTrades($"{asset}ETH");
                tradeList.AddRange(tradesETH.Data.OrderBy(t => t.TradeTime));
            }
            catch (Exception exc)
            {
                Console.WriteLine("ETH" + exc.ToString());
            }

            try
            {
                var tradesXRP = BClient.Spot.Order.GetMyTrades($"{asset}XRP");
                tradeList.AddRange(tradesXRP.Data.OrderBy(t => t.TradeTime));
            }
            catch (Exception exc)
            {
                Console.WriteLine("XRP" + exc.ToString());
            }

            return tradeList;
        }

        public List<Ohlc> getCandles2021(string symbol, KlineInterval interval)
        {
            List<Ohlc> retList = new List<Ohlc>();

            var klines = BClient.Spot.Market.GetKlines(
             symbol,
             interval,
             startTime: new DateTime(2020,12,1),
             endTime: DateTime.Now
             );

            if (klines.Data.Count() == 0)
            {
                return null;
            }

             else if (klines.Data.First().OpenTime.Year == 2020)
                return null;


       
            foreach (var item in klines.Data)
            {
                Ohlc cand = new Ohlc()
                {
                    Date = item.OpenTime.ToLocalTime(),
                    Open = (double)item.Open,
                    High = (double)item.High,
                    Low = (double)item.Low,
                    Close = (double)item.Close,
                    Volume = (double)item.CommonVolume
                };

                retList.Add(cand);
            }

            return retList;
        }

        public bool saveCandles(string rootFolderPath, DateTime currDateTime)
        {
            try
            {
                CreatePairs("USDT", rootFolderPath, currDateTime);
                CreatePairs("BTC", rootFolderPath, currDateTime);

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                return false;
            }
            

            return true;
        }

        private void CreatePairs(string unit, string rootFolderPath, DateTime currDateTime)
        {
            if (!Directory.Exists(rootFolderPath)) Directory.CreateDirectory(rootFolderPath);

            string nFormat = unit.Equals("BTC") ? "N8" : "N4";

            foreach (string symbolP in readAllSymbols(unit))
            {
                List<Ohlc> candles = getCandles(
                                             symbolP,
                                             KlineInterval.FifteenMinutes,
                                             null,
                                             currDateTime,
                                             1
                                             );
                if (candles.Count == 0) continue;
                if (candles.Last().Date.Month != DateTime.Now.Month) continue;

                Ohlc cn = candles.First();

                string folderPath = $"{rootFolderPath}\\{symbolP}";
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);


                // DateTime_Open_High_Low_Close_Volume
                string fileName = $"{cn.Date.ToString("yyyyMMdd_HHmm")}_" +
                    $"{cn.Open.ToString(nFormat, new CultureInfo("en-US"))}_" +
                    $"{cn.High.ToString(nFormat, new CultureInfo("en-US"))}_" +
                    $"{cn.Low.ToString(nFormat, new CultureInfo("en-US"))}_" +
                    $"{cn.Close.ToString(nFormat, new CultureInfo("en-US"))}_" +
                    $"{cn.Volume.ToString(nFormat, new CultureInfo("en-US"))}";

                string folderPath15m = Path.Combine(folderPath, "15m");
                if (!Directory.Exists(folderPath15m)) Directory.CreateDirectory(folderPath15m);

                string file15mPath = Path.Combine(folderPath15m, fileName);

                File.Create(file15mPath);

                if (cn.Date.Minute == 45)
                {
                    string folderPath1h = Path.Combine(folderPath, "1h");

                    // Create 1h folder, merge files and save as single file
                    if (!Directory.Exists(folderPath1h))
                        Directory.CreateDirectory(folderPath1h);

                    string file1hPath = Path.Combine(folderPath1h, getMerged1hFile(nFormat, folderPath15m, cn.Date));
                    string file1hName = Path.GetFileNameWithoutExtension(file1hPath);
                    File.Create(file1hPath);


                    if (cn.Date.Hour == 2 || cn.Date.Hour == 6 || cn.Date.Hour == 10 ||
                        cn.Date.Hour == 14 || cn.Date.Hour == 18 || cn.Date.Hour == 22)
                    {

                        string folderPath4h = Path.Combine(folderPath, "4h");

                        // Create 4h folder, merge files and save as single file
                        if (!Directory.Exists(folderPath4h))
                            Directory.CreateDirectory(folderPath4h);

                        // cn.Date = _0645_ at 07:00
                        File.Create(Path.Combine(folderPath4h, getMerged4hFile(nFormat, folderPath1h, cn.Date)));

                        if (cn.Date.Hour == 2)
                        {
                            string folderPath1D = Path.Combine(folderPath, "1D");

                            // Create 1D folder, merge files and save as single file
                            if (!Directory.Exists(folderPath1D))
                                Directory.CreateDirectory(folderPath1D);

                            // cn.Date => _0245_ at 03:00
                            File.Create(Path.Combine(folderPath1D, getMerged1DFile(nFormat, folderPath4h, cn.Date)));
                        }
                    }


                }
            }
        }

        private string getMerged1hFile(string nFormat, string folderPath, DateTime date)
        {
            double high = double.MinValue, low = double.MaxValue;
            double totalVolume = 0.0;
            double open = 0, close = 0;


            List<string> files = Directory.GetFiles(folderPath, $"{date.ToString("yyyyMMdd_HH")}*").ToList();
            int cc = 0;
            foreach (var file15m in files)
            {
                List<string> splitted = file15m.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (splitted.Count != 7) continue;

                double pH = double.Parse(splitted[3], new CultureInfo("en-US"));
                double pL = double.Parse(splitted[4], new CultureInfo("en-US"));
                double volume = double.Parse(splitted[6], new CultureInfo("en-US"));

                if (cc == files.Count - 1)
                    close = double.Parse(splitted[5], new CultureInfo("en-US"));

                if (cc == 0)
                    open = double.Parse(splitted[2], new CultureInfo("en-US"));

                if (high < pH)
                    high = pH;
                if (low > pL)
                    low = pL;

                totalVolume += volume;
                cc++;
            }

            return $"{date.ToString("yyyyMMdd_HH")}00_" +
                $"{open.ToString(nFormat, new CultureInfo("en-US"))}_" +
                $"{high.ToString(nFormat, new CultureInfo("en-US"))}_" +
                $"{low.ToString(nFormat, new CultureInfo("en-US"))}_" +
                $"{close.ToString(nFormat, new CultureInfo("en-US"))}_" +
                $"{totalVolume.ToString(nFormat, new CultureInfo("en-US"))}";
        }

        private string getMerged4hFile(string nFormat, string folderPath, DateTime date)
        {
            double high = double.MinValue, low = double.MaxValue;
            double totalVolume = 0.0;
            double open = 0, close = 0;

            List<string> files = new List<string>();
            DateTime dtTemp = date.AddMinutes(-45);
            for (int i = 0; i < 4; i++)
            {
                files.AddRange(Directory.GetFiles(folderPath, $"{dtTemp.ToString("yyyyMMdd_HH")}*").ToList());
                dtTemp = dtTemp.AddHours(-1);
            }

            int cc = 0;
            foreach (var file1h in files.OrderBy(f => f))
            {
                List<string> splitted = file1h.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (splitted.Count != 7) continue;

                double pH = double.Parse(splitted[3], new CultureInfo("en-US"));
                double pL = double.Parse(splitted[4], new CultureInfo("en-US"));
                double volume = double.Parse(splitted[6], new CultureInfo("en-US"));

                if (cc == files.Count - 1)
                    close = double.Parse(splitted[5], new CultureInfo("en-US"));

                if (cc == 0)
                    open = double.Parse(splitted[2], new CultureInfo("en-US"));

                if (high < pH)
                    high = pH;
                if (low > pL)
                    low = pL;

                totalVolume += volume;
                cc++;
            }

            // _0645_ -> 03-04-05-06
            date = date.AddMinutes(-45);
            date = date.AddHours(-3);

            return $"{date.ToString("yyyyMMdd_HH")}00_" +
                $"{open.ToString(nFormat, new CultureInfo("en-US"))}_" +
                $"{high.ToString(nFormat, new CultureInfo("en-US"))}_" +
                $"{low.ToString(nFormat, new CultureInfo("en-US"))}_" +
                $"{close.ToString(nFormat, new CultureInfo("en-US"))}_" +
                $"{totalVolume.ToString(nFormat, new CultureInfo("en-US"))}";
        }

        private string getMerged1DFile(string nFormat, string folderPath4h, DateTime date)
        {
            double high = double.MinValue, low = double.MaxValue;
            double totalVolume = 0.0;
            double open = 0, close = 0;


            // date = _0245_
            // 4h: _2300_ | _1900_ | _1500_ | _1100_ | _0700_ | _0300_ 
            List<string> files = new List<string>();
            DateTime dtTemp = date.AddDays(-1);


            files.AddRange(Directory.GetFiles(folderPath4h, $"{dtTemp.ToString("yyyyMMdd_")}*").ToList());

            int cc = 0;
            foreach (var file4h in files.OrderBy(f => f))
            {
                List<string> splitted = file4h.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (splitted.Count != 7) continue;

                double pH = double.Parse(splitted[3], new CultureInfo("en-US"));
                double pL = double.Parse(splitted[4], new CultureInfo("en-US"));
                double volume = double.Parse(splitted[6], new CultureInfo("en-US"));

                if (cc == files.Count - 1)
                    close = double.Parse(splitted[5], new CultureInfo("en-US"));

                if (cc == 0)
                    open = double.Parse(splitted[2], new CultureInfo("en-US"));

                if (high < pH)
                    high = pH;
                if (low > pL)
                    low = pL;

                totalVolume += volume;
                cc++;
            }

            return $"{dtTemp.ToString("yyyyMMdd_")}0003_" +
                $"{open.ToString(nFormat, new CultureInfo("en-US"))}_" +
                $"{high.ToString(nFormat, new CultureInfo("en-US"))}_" +
                $"{low.ToString(nFormat, new CultureInfo("en-US"))}_" +
                $"{close.ToString(nFormat, new CultureInfo("en-US"))}_" +
                $"{totalVolume.ToString(nFormat, new CultureInfo("en-US"))}";
        }


        public double getAverageCost(string asset)
        {
            List<BinanceTrade> tradeList = getTradeHistory(asset);

            double sumCost = 0.0;
            double qua = 0.0;

            foreach (var item in tradeList.OrderBy(t => t.TradeTime))
            {
                Console.WriteLine($"{item.Symbol}  {item.Price}  {item.Quantity}  {item.IsBuyer}");

                if (item.IsBuyer)
                {
                    qua += (double)item.Quantity;
                    sumCost += (double) (item.Price * item.Quantity);
                }
                    
                else
                {
                    qua -= (double)item.Quantity;
                    sumCost -= (double)(item.Price * item.Quantity);
                }
                    


            }


            return sumCost / qua;
        }


        public List<BinanceOrder> getOrderBook(string symbolPair)
        {
            var orders = BClient.Spot.Order.GetAllOrders(symbolPair);
            return orders.Data.ToList();
        }


        public string getSymbolName(string asset, string qAsset)
        {
            return BClient.GetSymbolName(asset, qAsset);
        }

        public Dictionary<string, double> getSpotCoinAmounts()
        {
            Dictionary<string, double> retDct = new Dictionary<string, double>();
            var dailySpot = BClient.General.GetAccountInfo();
            foreach (BinanceBalance bal in dailySpot.Data.Balances.Where(b => (double)b.Total > 0.0).ToArray())
            {
                retDct.Add(bal.Asset, (double)bal.Total);
            }
            return retDct;
        }

        public double getSpotCoinAmount(string asset)
        {
            return getSpotCoinAmounts().First(d => d.Key.Equals(asset)).Value;
        }

        public Dictionary<string, double> getSpotCoinPrices()
        {
            Dictionary<string, double> retDct = new Dictionary<string, double>();
            var dailySpot = BClient.General.GetAccountInfo();
            foreach (BinanceBalance bal in dailySpot.Data.Balances.Where(b => (double)b.Total > 0.0).ToArray())
            {
                
                double price = getSymbolPrice(bal.Asset, "USDT");
                retDct.Add(bal.Asset, price);
            }
            return retDct;
        }

        public double getSpotSatAmount()
        {
            double totalSat = 0.0;
            var dailySpot = BClient.General.GetAccountInfo();

            Dictionary<string, double> dctCoinAmounts = getSpotCoinAmounts();

            foreach (string asset in dctCoinAmounts.Keys)
            {

                double sat = 0.0;
                double amount = dctCoinAmounts[asset];

                try
                {
                    if (asset.Equals("BTC"))
                        sat = amount;

                    sat = getSymbolPrice(asset, "BTC");

                    
                }
                catch 
                {
                    continue;
                }

                totalSat += sat * amount;
            }
            return totalSat / 10000.0;
        }

        public List<string> getUserCoins()
        {
            return BClient.General.GetUserCoins().Data
                .Select(c => c.Coin)
                .OrderBy(c => c)
                .ToList();
              
        }


        public List<string> readAllSymbolsUSDT()
        {
            return BClient.Spot.Market.GetPrices().Data
                .Where(d => d.Symbol.EndsWith("USDT") && !d.Symbol.EndsWith("DOWNUSDT") && !d.Symbol.EndsWith("UPUSDT"))
                .Select(d => d.Symbol)
                .ToList();
        }


        public List<string> readAllSymbolsBUSD()
        {
            return BClient.Spot.Market.GetPrices().Data
                .Where(d => d.Symbol.EndsWith("BUSD"))
                .Select(d => d.Symbol)
                .OrderBy(d => d)
                .ToList();
        }

        public List<string> readAllSymbolsBTC()
        {
            return BClient.Spot.Market.GetPrices().Data
                .Where(d => d.Symbol.EndsWith("BTC"))
                .Select(d => d.Symbol)
                .OrderBy(d => d)
                .ToList();
        }

        public List<string> readAllSymbols(string refSymbol, string RootFolderPath = "")
        {

            if (DctUnitsVsSymbolPairs.ContainsKey(refSymbol) == false)
            {
                if (false == Directory.Exists(RootFolderPath))
                {
                    DctUnitsVsSymbolPairs[refSymbol] = new List<string>();
                    DctUnitsVsSymbolPairs[refSymbol] = BClient.Spot.Market.GetPrices().Data
                    .Where(d => Regex.IsMatch(d.Symbol, $"{refSymbol}$") && !Regex.IsMatch(d.Symbol, $"UP|DOWN{refSymbol}$"))
                    .Select(d => d.Symbol)
                    .ToList();
                }
                else
                {
                    DctUnitsVsSymbolPairs[refSymbol] = new List<string>();
                    DctUnitsVsSymbolPairs[refSymbol] = Directory.GetDirectories(RootFolderPath, $"*{refSymbol}")
                        .Select(d => Path.GetFileName(d))
                        .ToList();
                }
            }

            return DctUnitsVsSymbolPairs[refSymbol];
        }

        public List<string> readAllSymbolsOnlyBTC()
        {
            return BClient.Spot.Market.GetPrices().Data
                .Where(d => d.Symbol.EndsWith("BTC"))
                .Select(d => d.Symbol)
                .ToList();
        }

        public List<string> readAllSymbols()
        {
            return BClient.Spot.Market.GetPrices().Data
                .Select(d => d.Symbol)
                .OrderBy(d => d)
                .ToList();
        }



        public void readSymbolTickers(string symbol)
        {
            
            //Spot | Spot market and user subscription methods
            SocketClient.Spot.SubscribeToSymbolTickerUpdates(
                new string[] { symbol },
                data =>
                {

                    SymbolTickers.Add(new CSymbolTicker()
                    {
                        symbol = data.Symbol,
                        askPrice = (double)data.AskPrice,
                        askQty = (double)data.AskQuantity,
                        bidPrice = (double)data.BidPrice,
                        bidQty = (double)data.BidQuantity,
                        count = data.TotalTrades,
                        currentPrice = (double)data.AskPrice,
                        firstId = (long)data.FirstTradeId,
                        lastId = data.LastTradeId,
                        highPrice = (double)data.HighPrice,
                        volume = (double)data.BaseVolume,
                        openTime = data.OpenTime.Millisecond,
                        closeTime = data.CloseTime.Millisecond,
                        quoteVolume = (double)data.QuoteVolume,
                        lastPrice = (double)data.LastPrice,
                        lastQty = (double)data.LastQuantity,
                        lowPrice = (double)data.LowPrice,
                        openPrice = (double)data.OpenPrice,
                        prevClosePrice = (double)data.PrevDayClosePrice,
                        priceChange = (double)data.PriceChange,
                        priceChangePercent = (double)data.PriceChangePercent,
                        weightedAvgPrice = (double)data.WeightedAveragePrice
                    });

                    if (SymbolTickers.Count == 1)
                    {
                        F_Main.getInstance().UpdateTickerDataUI();
                        SymbolTickers.Clear();
                    }
                });

           

        }

        public void readSymbolTickers(string symbol, ucPriceLabel owner)
        {

            //Spot | Spot market and user subscription methods
            SocketClient.Spot.SubscribeToSymbolTickerUpdates(
                new string[] { symbol },
                data =>
                {

                    owner.updateLabel(symbol, (double)data.AskPrice, (double)data.LowPrice, (double) data.HighPrice);
                });


            
        }

        public void readSymbolTickers(string symbol, F_SupportResistanceSignal owner)
        {

            //Spot | Spot market and user subscription methods
            SocketClient.Spot.SubscribeToSymbolTickerUpdates(
                new string[] { symbol },
                data =>
                {

                    owner.updateLabel(symbol, (double)data.LowPrice, (double)data.AskPrice, (double)data.HighPrice);
                });



        }

        public void readSymbolTickers(string symbol, ucPortfolioManager ucOwner)
        {
            //Spot | Spot market and user subscription methods
            SocketClient.Spot.SubscribeToSymbolTickerUpdates(
                new string[] { symbol },
                data =>
                {
                    ucOwner.updateLabel(symbol, (double)data.AskPrice);
                });
        }

        public void readSymbolTickers(string[] symbols)
        {

            //Spot | Spot market and user subscription methods
            SocketClient.Spot.SubscribeToSymbolTickerUpdates(
                symbols,
                data =>
                {

                    SymbolTickers.Add(new CSymbolTicker()
                    {
                        symbol = data.Symbol,
                        askPrice = (double)data.AskPrice,
                        askQty = (double)data.AskQuantity,
                        bidPrice = (double)data.BidPrice,
                        bidQty = (double)data.BidQuantity,
                        count = data.TotalTrades,
                        currentPrice = (double)data.AskPrice,
                        firstId = (long)data.FirstTradeId,
                        lastId = data.LastTradeId,
                        highPrice = (double)data.HighPrice,
                        volume = (double)data.BaseVolume,
                        openTime = data.OpenTime.Millisecond,
                        closeTime = data.CloseTime.Millisecond,
                        quoteVolume = (double)data.QuoteVolume,
                        lastPrice = (double)data.LastPrice,
                        lastQty = (double)data.LastQuantity,
                        lowPrice = (double)data.LowPrice,
                        openPrice = (double)data.OpenPrice,
                        prevClosePrice = (double)data.PrevDayClosePrice,
                        priceChange = (double)data.PriceChange,
                        priceChangePercent = (double)data.PriceChangePercent,
                        weightedAvgPrice = (double)data.WeightedAveragePrice
                    });

                    if (SymbolTickers.Count == symbols.Length)
                    {
                        F_Main.getInstance().UpdateTickerDataUI();
                        
    
                    }
                });



        }

        public List<Ohlc> getCandles(string symbol, KlineInterval interval, DateTime start, DateTime end)
        {
            


            List<Ohlc> retList = new List<Ohlc>();

            var klines = BClient.Spot.Market.GetKlines(
             symbol,
             interval,
             startTime: start,
             endTime: end
             );



            //foreach (var item in klines.Data.Select(k => new { k.OpenTime, k.Open, k.High, k.Low, k.Close, k.QuoteVolume }).ToList())
            foreach (var item in klines.Data)
            {
                Ohlc cand = new Ohlc()
                {
                    Date = item.OpenTime.ToLocalTime(),
                    Open = (double)item.Open,
                    High = (double)item.High,
                    Low = (double)item.Low,
                    Close = (double)item.Close,
                    Volume = (double)item.CommonVolume
                };

                retList.Add(cand);
            }

            return retList;

        }

        public List<Ohlc> getCandles(string symbol, KlineInterval interval, DateTime? start, DateTime ?end, int pNumOfCandles)
        {

            List<Ohlc> retList = new List<Ohlc>();

            var klines = BClient.Spot.Market.GetKlines(
             symbol,
             interval,
             startTime: start,
             endTime: end,
             limit: pNumOfCandles
             );

            if (klines.Data == null)
                return retList;

            //foreach (var item in klines.Data.Select(k => new { k.OpenTime, k.Open, k.High, k.Low, k.Close, k.QuoteVolume }).ToList())
            foreach (var item in klines.Data)
            {
                Ohlc cand = new Ohlc()
                {
                    Date = item.OpenTime.ToLocalTime(),
                    Open = (double)item.Open,
                    High = (double)item.High,
                    Low = (double)item.Low,
                    Close = (double)item.Close,
                    Volume = (double)item.CommonVolume
                };

                retList.Add(cand);
            }

            //return retList.GetRange(0, retList.Count - 1);
            return retList;
        }

        public List<Ohlc> getCandlesCached(string folderPath, string symbol, KlineInterval interval, DateTime end, int pNumOfInterval)
        {

            if (Directory.Exists(folderPath) == false)
            {
                return getCandles(
                         symbol,
                         interval,
                         null,
                         end,
                         pNumOfInterval
                         );
            }

            List<Ohlc> retList = new List<Ohlc>();
            string combinedFolderPath = Path.Combine(folderPath, symbol);
            if (!Directory.Exists(combinedFolderPath))
                return retList;

           
            List<string> filters = new List<string>();
            DateTime temp = end;
            //string dayFilter = temp.ToString("yyyyMMdd");

            List<string> filesCache = new List<string>();
            DateTime dt = new DateTime();

            switch (interval)
            {
                case KlineInterval.FifteenMinutes:

                    dt = roundDownDate(temp, interval);
                    for (int i = 0; i < pNumOfInterval + 1; i++)
                    {
                        dt = dt.AddMinutes(-15);
                        filesCache.AddRange(getFiles(Path.Combine(combinedFolderPath, "15m"), $"{dt.ToString("yyyyMMdd_HHmm")}"));
                    }
                    break;
                case KlineInterval.OneHour:
                    dt = roundDownDate(temp, interval);
                    for (int i = 0; i < pNumOfInterval + 1; i++)
                    {
                        dt = dt.AddHours(-1);
                        filesCache.AddRange(getFiles(Path.Combine(combinedFolderPath,"1h"), $"{dt.ToString("yyyyMMdd_HH")}00"));
                    }
                    break;
                case KlineInterval.FourHour:
                    dt = roundDownDate(temp, interval);
                    for (int i = 0; i < pNumOfInterval; i++)
                    {
                        filesCache.AddRange(getFiles(Path.Combine(combinedFolderPath, "4h"), $"{dt.ToString("yyyyMMdd_HH")}"));
                        dt = dt.AddHours(-4);
                    }
                    break;
                case KlineInterval.OneDay:
                    dt = roundDownDate(temp, interval);
                    for (int i = 0; i < pNumOfInterval; i++)
                    {
                        filesCache.AddRange(getFiles(Path.Combine(combinedFolderPath, "1D"), $"{dt.ToString("yyyyMMdd")}"));
                        dt = dt.AddDays(-1);
                    }
                    
                    break;
                default:
                    break;
            }


            filesCache = filesCache.Distinct().OrderBy(c => c).ToList();

            if (filesCache.Count == 0)
            {
                return getCandles(symbol, interval, null, end, pNumOfInterval);
            }
            else
            {
                foreach (var filePath in filesCache)
                {
                    Ohlc ohlcNew = convertFileToOhlc(filePath);
                    if (ohlcNew != null)
                    {
                        retList.Add(ohlcNew);
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
           
            return retList.OrderBy(o => o.Date).ToList();

        }


        public Ohlc convertFileToOhlc(string filePath)
        {
            string[] splitted = filePath.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);

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

        private List<string> getFiles(string folderPath, string filter)
        {
            if (!Directory.Exists(folderPath)) return new List<string>();

            return Directory.GetFiles(folderPath, $"{filter}*")
                                .Select(f => Path.GetFileNameWithoutExtension(f))
                                .ToList();
        }

        private DateTime roundDownDate(DateTime dt, KlineInterval interval)
        {
            switch (interval)
            {
                case KlineInterval.FifteenMinutes:
                    int minDown = (dt.Minute / 15) * 15;
                    return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, minDown, 0);
                case KlineInterval.OneHour:
                    return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0);
                case KlineInterval.FourHour:
                    int hourDown = dt.Hour;
                    int dayDown = dt.Day;
                    if (hourDown >= 3 && hourDown < 7)
                        hourDown = 3;
                    else if (hourDown >= 7 && hourDown < 11)
                        hourDown = 7;
                    else if (hourDown >= 11 && hourDown < 15)
                        hourDown = 11;
                    else if (hourDown >= 15 && hourDown < 19)
                        hourDown = 15;
                    else if (hourDown >= 19 && hourDown < 23)
                        hourDown = 19;
                    else if (hourDown >= 23 && hourDown < 24)
                        hourDown = 23;
                    else
                    {
                        hourDown = 23;
                        dayDown = dt.AddDays(-1).Day;
                    }

                    return new DateTime(dt.Year, dt.Month, dayDown, hourDown, 0, 0);
                case KlineInterval.OneDay:
                    DateTime dayBefore = new DateTime(dt.Year, dt.Month, dt.Day, 3, 0, 0).AddDays(-1);
                    return dayBefore;
                default:
                    return dt;
            }
        }


        public void getCandles15min(string symbol, ucPriceLabel priceLabelComp)
        {

            List<Ohlc> retList = new List<Ohlc>();

            var klines = BClient.Spot.Market.GetKlines(
             symbol,
             KlineInterval.FifteenMinutes,
             startTime: DateTime.Now.AddHours(-12),
             endTime: DateTime.Now
             );



            //foreach (var item in klines.Data.Select(k => new { k.OpenTime, k.Open, k.High, k.Low, k.Close, k.QuoteVolume }).ToList())
            foreach (var item in klines.Data)
            {
                Ohlc cand = new Ohlc()
                {
                    Date = item.OpenTime.ToLocalTime(),
                    Open = (double)item.Open,
                    High = (double)item.High,
                    Low = (double)item.Low,
                    Close = (double)item.Close,
                    Volume = (double)item.CommonVolume
                };

                retList.Add(cand);
            }

            priceLabelComp.setOhlcList(retList);

        }

        public double getSymbolPrice(string asset, string unit)
        {
            double usdtPerBUSD = (double)BClient.Spot.Market.GetPrice("BUSDUSDT").Data.Price;

            if (asset.Equals("BUSD") && unit.Equals("USDT"))
                return usdtPerBUSD;

            if (asset.Equals("USDT"))
                return 1.0;

            double price = 0.0;

            try
            {
                price = (double)BClient.Spot.Market.GetPrice($"{asset}{unit}").Data.Price;
            }
            catch 
            {
                return 0.0;
            }

           

            return price;
        }

        public double getSymbolPrice(string symbolPair)
        {
            return (double)BClient.Spot.Market.GetPrice(symbolPair).Data.Price;
        }


        public double getSymbolPrice(string asset, string unit, DateTime timeAt)
        {
            double usdtPerBUSD = (double)BClient.Spot.Market.GetKlines(
                "BUSDUSDT",
                KlineInterval.OneMinute,
                timeAt.AddMinutes(-1),
                timeAt
                ).Data.ToList().Last().Close;
                

            if (asset.Equals("BUSD") && unit.Equals("USDT"))
                return usdtPerBUSD;

            if (asset.Equals("USDT"))
                return 1.0;

            double price = (double)BClient.Spot.Market.GetKlines(
                $"{asset}{unit}",
                KlineInterval.OneMinute,
                timeAt.AddMinutes(-1),
                timeAt
                ).Data.ToList().Last().Close;

            return price;
        }

        public double getSymbolBaseVolume(string symbol)
        {
            double value = 0;
            SocketClient.Spot.SubscribeToSymbolTickerUpdates(symbol, data =>
            {
                value = (double)data.BaseVolume;
            });

            return value;
        }


        //public double getSymbolQuoteVolume(string symbol)
        //{
        //    double value = 0;
        //    SocketClient.Spot.SubscribeToSymbolTickerUpdates(symbol, data =>
        //    {
        //        value = (double)data.QuoteVolume;
        //    });

        //    return value;
        //}


        public double getSymbolVolume(string symbolPair)
        {
            var list = BClient.Spot.Market.GetKlines(
                symbolPair,
                KlineInterval.OneDay,
                null,
                DateTime.Now,
                7
                ).Data.ToList();

            double vol = 0;

            if (list.Count > 0)
            {
                vol = (double)list.Last().CommonVolume;

            }

            return vol;
        }

        public double getSymbolPriceChange(string symbol)
        {
            double value = 0;
            SocketClient.Spot.SubscribeToSymbolTickerUpdates(symbol, data =>
            {
                value = (double)data.PriceChange;
            });

            return value;
        }


        public void readLastSymbolTickers(string symbol, ucSignalRow ucOwner)
        {
            //Spot | Spot market and user subscription methods
            SocketClient.Spot.SubscribeToSymbolTickerUpdates(
                new string[] { symbol },
                data =>
                {
                    if ((double)data.PriceChangePercent > 10.0)
                        ucOwner.updateLabel(symbol, (double)data.AskPrice, ESignalReason.WHALE_ALERT);
                });
        }

        public double getSymbolPriceAverageIn24h(string symbol)
        {
            double value = 0;
            SocketClient.Spot.SubscribeToSymbolTickerUpdates(symbol, data =>
            {
                value = (double)data.WeightedAveragePrice;
            });

            return value;
        }

        public double getSymbolTotalTradesIn24h(string symbol)
        {
            double value = 0;
            SocketClient.Spot.SubscribeToSymbolTickerUpdates(symbol, data =>
            {
                value = (double)data.TotalTrades;
            });

            return value;
        }


        public void Close()
        {
            if (SocketClient != null)
            {
                SocketClient.UnsubscribeAll();
                SocketClient = null;
            }
                
        }



        public bool orderMarketBuy(string symbol, double dQuantity)
        {
            decimal quantity = new decimal(dQuantity);

            var result = BClient.Spot.Order.PlaceOrder(
                symbol,
                OrderSide.Buy,
                OrderType.Market,
                quantity
            );

            return result.Success;
        }

        public bool orderBuy(string symbol, double dQuantity, double dLimit)
        {
            decimal quantity = new decimal(dQuantity);
            decimal limit = new decimal(dLimit);

            var result = BClient.Spot.Order.PlaceOrder(
                symbol,
                OrderSide.Buy,
                OrderType.Limit,
                quantity,
                null,   // only valid for Market orders
                null,
                limit, 
                TimeInForce.GoodTillCancel,
                null
                );

            return result.Success;
        }

        public bool orderSell(string symbol, double dQuantity, double dLimit)
        {
            decimal quantity = new decimal(dQuantity);
            decimal limit = new decimal(dLimit);

            var result = BClient.Spot.Order.PlaceOrder(
                symbol,
                OrderSide.Sell,
                OrderType.Limit,
                quantity,
                null,   // only valid for Market orders
                null,
                limit,   // stop
                TimeInForce.GoodTillCancel,
                null   // limit
                );

            return result.Success;
        }

        //public bool orderBuy(string symbol, double dQuantity, double dStop, double dLimit)
        //{
        //    decimal quantity = new decimal(dQuantity);
        //    decimal stop = new decimal(dStop);
        //    decimal limit = new decimal(dLimit);

        //    var result = BClient.Spot.Order.PlaceOrder(
        //        "ETHBUSD",
        //        OrderSide.Buy,
        //        OrderType.StopLossLimit,
        //        quantity,
        //        null,   // only valid for Market orders
        //        null,
        //        stop,   // stop
        //        TimeInForce.FillOrKill,
        //        limit   // limit
        //        );

        //    return result.Success;
        //}

    }
}
