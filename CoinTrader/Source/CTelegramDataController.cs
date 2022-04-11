using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Binance.Net.Enums;
using CoinTrader.Fibonacci;
using CoinTrader.UI;
using NetTrader.Indicator;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace CoinTrader.Source
{
    public class CTelegramDataController
    {

        public class CCustomerTelegramBot
        {
            public ITelegramBotClient Client { get; set; }
            public string AccessToken { get; set; }
            public string Password { get; set; }
        };

        private static CBinanceDataController DataController;
        private static CTelegramCommandParser CommandParser = new CTelegramCommandParser();
        private static CFibboLevels FibonacciLevels;
        private static CChartAnalyzer ChartAnalyzer;

        private Dictionary<string, FileSystemWatcher> SymbolVsFileWatcher = new Dictionary<string, FileSystemWatcher>();


        private static CTelegramDataController instance;
        public static CTelegramDataController getInstance()
        {
            if (instance == null)
                instance = new CTelegramDataController();
            return instance;
        }

        public static ITelegramBotClient botClient;
        private static string AccessToken = "1720887863:AAFQn9w67nSVa9v-5agJyvxodDMSOIkZTv0";

        public static ITelegramBotClient botClient2;
        private static string AccessToken2 = "2124818369:AAHD-Vik4wrhvi2XHCsT7PkCOYTGWfrpdvw";

        private static Dictionary<ITelegramBotClient, Chat> dctBotVsChat = new Dictionary<ITelegramBotClient, Chat>();

        private static List<CTelegramRowInfo> lstRows = new List<CTelegramRowInfo>();

        private static bool CheckPass = true;
        private static bool PasswordOK = true;

        private static Timer timer15m = new Timer();
        private static bool timer15mAlarmOn = false;
        private static bool timer1hAlarmOn = false;
        private static bool timer4hAlarmOn = false;
        private static bool timer1DAlarmOn = false;

        private static string[] words = new string[]
        {
            "Sus sikerim belanı.",
            "Fazla konuşma!",
            "Mal mal şeyler yazma amk.",
            "Aferin hecelemeyi öğrenmişsin.",
            "Yazma yazma...",
            "Suç bende ki seni dinliyorum.",
            "Helal lan sana..",
            "Daha da birşey demiyorum.",
            "Taam tmm",
            "Tamam dedim ya!",
            "Ne alakası var onunla?",
            "Sen ciddi misin?",
            "Sen mal mısın?",
            "Boş boş konuşma..",
            "Bot olan ben miyim sen misin amk..",
            "Ne?",
            "Yuh, bu cümleyi sen mi kurdun?"
        };

        private static string[] SingleCommands = new string[]
        {
            "PF",
            "ALARMON 15m",
            "ALARMOFF 15m",
            "ALARMON 1h",
            "ALARMOFF 1h",
            "ALARMON 4h",
            "ALARMOFF 4h",
            "ALARMON 1D",
            "ALARMOFF 1D",
        };

        private static string SavedFolderPath = "D:\\Temp";


 

        private CTelegramDataController()
        {
            botClient = new TelegramBotClient(AccessToken);
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );


            //botClient2 = new TelegramBotClient(AccessToken2);
            //var me2 = botClient2.GetMeAsync().Result;
            //Console.WriteLine(
            //  $"Hello, World! I am user {me2.Id} and my name is {me2.FirstName}."
            //);


            //TelegramSendMessage("CoinTrader başlatıldı.");

            timer15m.Interval = 1 * 30 * 1000; //15 * 60 * 1000;
            timer15m.Tick += Timer30sec_Tick;

            //MessageBox.Show("Timer is closed!");
            timer15m.Start();

            // Sorgulara cevap
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            //botClient2.OnMessage += Bot_OnMessage;
            //botClient2.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

            //botClient.StopReceiving();

          

            instance = this;
        }

        public void InitializeFileSystemWatchers()
        {
            SymbolVsFileWatcher.Clear();
            foreach (string refSym in DataController.readAllSymbols("USDT"))
            {
                string folderPath = Path.Combine(SavedFolderPath, $"{refSym}\\15m");
                if (Directory.Exists(folderPath))
                {
                    FileSystemWatcher fsw = new FileSystemWatcher(folderPath);
                    fsw.NotifyFilter = NotifyFilters.LastWrite;
                    fsw.EnableRaisingEvents = true;
                    fsw.Changed += Fsw_Changed;
                    fsw.Created += Fsw_Changed;
                    SymbolVsFileWatcher.Add(refSym, fsw);
                }
            }
        }

        private void Fsw_Changed(object sender, FileSystemEventArgs e)
        {
            string folderPath = Directory.GetParent(e.FullPath).FullName;
            string folderName = Directory.GetParent(folderPath).Name;
            string[] allFilesInDir = Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f)).ToArray();
            int len = allFilesInDir.Length;

            if (len > 1)
            {
                Ohlc ohlcLast1 = DataController.convertFileToOhlc(allFilesInDir[len - 1]);
                Ohlc ohlcLast2 = DataController.convertFileToOhlc(allFilesInDir[len - 2]);
     


                if (ohlcLast2.Close > ohlcLast1.Close)
                {
                    Console.WriteLine($"BUY: {folderName} -- {ohlcLast1.ToString()}");
                }
            }
            
        }

        public static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                ITelegramBotClient client = sender as ITelegramBotClient;

                Console.WriteLine($"Received a text ({e.Message.Text}) in chat {e.Message.Chat.Id}.");
                Console.WriteLine(e.Message.Text.ToCharArray().Select(c => ((int)c).ToString()).Aggregate((c1,c2) => $"{c1},{c2}"));

                if (CheckPass == true && PasswordOK == false)
                    PasswordOK = e.Message.Text.Equals("");

                if (PasswordOK == false)
                {
                    CheckPass = true;
                    await client.SendTextMessageAsync(
                         chatId: e.Message.Chat,
                         text: "Incorrect password. Enter a valid password to use MeCa-Bot"
                         );
                    return;
                }
                else
                {
                    if (CheckPass == true)
                    {
                        await client.SendTextMessageAsync(
                           chatId: e.Message.Chat,
                           text: "Welcome to MeCa-Bot. Type \"help\" to see usage."
                           );
                        CheckPass = false;
                        return;
                    }
                }
                
                try
                {
                    if (e.Message.Text.ToLower().Trim().Equals("help"))
                    {
                        
                        await client.SendTextMessageAsync(
                          chatId: e.Message.Chat,
                          text: $"[USDT|BTC] [15m|1h|4h|1D|1W] [...]{Environment.NewLine}" +
                                $"▪ P#5 : Last 5 price candles {Environment.NewLine}" +
                                $"▪ V#24 : Last 24 volume candles {Environment.NewLine}" +
                                $"▪ MA200- : Under 200 candle moving average  {Environment.NewLine}" +
                                $"▪ MA7+ : Over 7 candle moving average  {Environment.NewLine}" +
                                $"▪ MA50>MA200 : MA50 is over MA200 {Environment.NewLine}" +
                                $"▪ MA7<MA25 : MA7 is under MA25 {Environment.NewLine}" +
                                $"▪ RSI- : RSI value of at least 14 candle is below 30 {Environment.NewLine}" +
                                $"▪ MACD+ : MACD Intersection at positive {Environment.NewLine}" +
                                $"▪ RRGR : Candle series as Red-Red-Green-Red {Environment.NewLine}" +
                                $"▪ FIBR: Display the candles at fibonacci resistance. {Environment.NewLine}" +
                                $"▪ FIBS: Display the candles at fibonacci support. {Environment.NewLine}"
                        );

                        
                    }
                    else if (SingleCommands.Any(s => s.ToLower().Equals(e.Message.Text.ToLower())))
                    {
                        if (e.Message.Text.ToLower().Equals("pf"))
                        {
                            await client.SendTextMessageAsync(
                                   chatId: e.Message.Chat,
                                   text: "Portfolio query is sent to the server..."
                               );

                            // Show portfolio with the 
                            preparePortfolioList();

                             await client.SendTextMessageAsync(
                                   chatId: e.Message.Chat,
                                   text: lstRows.Count == 0 ? "No portfolio exists." : lstRows
                                       .OrderByDescending(s => s.RefValue)
                                       .ThenBy(s => s.Content)
                                       .Select(s => s.Content)
                                       .Aggregate((s1, s2) => $"{s1}{Environment.NewLine}{s2}")
                                       .ToString()
                               );
                        }
                        else if (e.Message.Text.ToLower().Equals("alarmon 15m"))
                        {
                            timer15mAlarmOn = true;
                            await client.SendTextMessageAsync(
                               chatId: e.Message.Chat,
                               text: "Alarm-15m is activated."
                           );

                        }
                        else if (e.Message.Text.ToLower().Equals("alarmoff 15m"))
                        {
                            timer15mAlarmOn = false;
                            await client.SendTextMessageAsync(
                               chatId: e.Message.Chat,
                               text: "Alarm-15m is deactivated."
                           );
                        }
                        else if (e.Message.Text.ToLower().Equals("alarmon 1h"))
                        {
                            timer1hAlarmOn = true;
                            await client.SendTextMessageAsync(
                               chatId: e.Message.Chat,
                               text: "Alarm-1h is activated."
                           );
                        }
                        else if (e.Message.Text.ToLower().Equals("alarmoff 1h"))
                        {
                            timer1hAlarmOn = false;
                            await client.SendTextMessageAsync(
                               chatId: e.Message.Chat,
                               text: "Alarm-1h is deactivated."
                           );
                        }
                        else if (e.Message.Text.ToLower().Equals("alarmon 4h"))
                        {
                            timer4hAlarmOn = true;
                            await client.SendTextMessageAsync(
                               chatId: e.Message.Chat,
                               text: "Alarm-4h is activated."
                           );
                        }
                        else if (e.Message.Text.ToLower().Equals("alarmoff 4h"))
                        {
                            timer4hAlarmOn = false;
                            await client.SendTextMessageAsync(
                               chatId: e.Message.Chat,
                               text: "Alarm-4h is deactivated."
                           );
                        }
                        else if (e.Message.Text.ToLower().Equals("alarmon 1D"))
                        {
                            timer1DAlarmOn = true;
                            await client.SendTextMessageAsync(
                               chatId: e.Message.Chat,
                               text: "Alarm-1D is activated."
                           );
                        }
                        else if (e.Message.Text.ToLower().Equals("alarmoff 1D"))
                        {
                            timer1DAlarmOn = false;
                            await botClient.SendTextMessageAsync(
                               chatId: e.Message.Chat,
                               text: "Alarm-1D is deactivated."
                           );
                        }

                    }
                    else
                    {
                        CommandParser = CommandParser.ParseCommand(e.Message.Text);

                        await client.SendTextMessageAsync(
                            chatId: e.Message.Chat,
                            text: "Query is sent to the server..."
                        );


                        lstRows.Clear();
                        switch (CommandParser.IndicatorType)
                        {
                            case EIndicatorType.NONE:
                                break;
                            case EIndicatorType.CURRENT_STAT:
                                responseCurrentStatusOfSymbolPair();
                                break;
                            case EIndicatorType.MOVING_AVERAGE:
                                responseCommandMA();
                                break;
                            case EIndicatorType.MOVING_AVERAGE_INTERSECTION:
                                responseCommandMAIntersection();
                                break;
                            case EIndicatorType.RSI:
                                responseCommandRSI();
                                break;
                            case EIndicatorType.MACD:
                                responseCommandMACD();
                                break;
                            case EIndicatorType.CANDLE_COLOR:
                                responseCandleColor();
                                break;
                            case EIndicatorType.PRICE_CHANGE:
                                responseCommandPriceChange();
                                break;
                            case EIndicatorType.VOLUME_CHANGE:
                                responseCommandVolumeChange();
                                break;
                            case EIndicatorType.FIBONACCI:
                                responseCommandFibonacci();
                                break;
                            case EIndicatorType.CANDLE_PATTERN:
                                break;
                            case EIndicatorType.PRICE_LIST:
                                responsePriceList();
                                break;
                            case EIndicatorType.VOLUME_LIST:
                                responseVolumeList();
                                break;
                            case EIndicatorType.ALARM:
                                break;
                            case EIndicatorType.ORDER:
                                //responseOrders();
                                break;
                            default:
                                break;
                        }

                        if (lstRows.Count > 50)
                        {
                            lstRows.RemoveRange(50, lstRows.Count - 50);
                        }


                        await client.SendTextMessageAsync(
                            chatId: e.Message.Chat,
                            text: lstRows.Count == 0 ? "No results found." : lstRows
                                .OrderBy(s => s.RefValue)
                                .ThenBy(s => s.Content)
                                .Select(s => s.Content)
                                .Aggregate((s1, s2) => $"{s1}{Environment.NewLine}{s2}")
                                .ToString()
                        );
                    }

                    

                    

                }
                catch (Exception exc)
                {
                    await client.SendTextMessageAsync(
                         chatId: e.Message.Chat,
                         text: "Invalid query. Please use \"help\" to create a valid query."
                       );
                }
               
            }
        }

        private static void responseOrders()
        {
            // +ETHBUSD 0.5 4321 4320 
            // -ETHBUSD ALL 4521 4525 
            // -ETHBUSD 0.2 4510 4511 
            // -ETHBUSD 1.0 4165 4150 
            string refSymbol = CommandParser.SymbolPair;
            string cFormat = CommandParser.SymbolPair.EndsWith("BTC") ? "N8" : "C4";
            if (CommandParser.OrderParams.Count  == 3)
            {
                

                string buyOrSell = CommandParser.OrderBuyOrSell.Equals('+') ? "BUY" : "SELL";
                refSymbol = CommandParser.OrderParams[0];
                double amount = Double.Parse(CommandParser.OrderParams[1].Replace(',', '.'), CultureInfo.InvariantCulture);
                double limit = Double.Parse(CommandParser.OrderParams[2].Replace(',', '.'), CultureInfo.InvariantCulture);


                if (buyOrSell.Equals("BUY"))
                {
                    if (DataController.orderBuy(refSymbol, amount, limit))
                    {
                        lstRows.Add(new CTelegramRowInfo()
                        {
                            Content = $"{amount} x {refSymbol} {buyOrSell} order is given at {limit.ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))}",
                            RefValue = amount
                        });
                    }
                }
                else if (buyOrSell.Equals("SELL"))
                {
                    if (DataController.orderSell(refSymbol, amount, limit))
                    {
                        lstRows.Add(new CTelegramRowInfo()
                        {
                            Content = $"{amount} x {refSymbol} {buyOrSell} order is given at {limit}",
                            RefValue = amount
                        });
                    }
                }


            }
           


        }

        private static void responseCurrentStatusOfSymbolPair()
        {
            string refSymbol = CommandParser.SymbolPair;
            string cFormat = CommandParser.SymbolPair.EndsWith("BTC") ? "N8" : "C4";

            List<Ohlc> candles = DataController.getCandlesCached(
                                             SavedFolderPath,
                                             refSymbol,
                                             KlineInterval.OneDay,
                                             DateTime.Now,
                                             7
                                             );

            if (candles.Count >= 2)
            {
                double max = candles.Max(c => c.High);
                double min = candles.Min(c => c.Low);

                double Support1 = -1.0;
                double Support2 = -1.0;
                double Resistance1 = -1.0;
                double Resistance2 = -1.0;

                double price = DataController.getSymbolPrice(refSymbol);
                double priceChange = (candles[candles.Count - 1].Close - candles[candles.Count - 2].Close) * 100.0 / candles[candles.Count - 1].Close;
                double volume = DataController.getSymbolVolume(refSymbol);
                double volumeChange = (candles[candles.Count - 1].Volume - candles[candles.Count - 2].Volume) * 100.0 / candles[candles.Count - 1].Volume;

                FibonacciLevels = CFibonacciRetracement.GetFibboLevels(min, max);
                Support1 = FibonacciLevels.GetSupportValue(price, ref Support2);
                Resistance1 = FibonacciLevels.GetResistanceValue(price, ref Resistance2);

                double fiboPercent = 0.0;
                string fiboLineString = getLinePercentString(Support1, price, Resistance1, ref fiboPercent);

                char priceChangeChar = priceChange > 0
                    ? (char)EAsciMap.TriangleUp
                    : (char)EAsciMap.TriangleDown;

                char volumeChangeChar = volumeChange > 0
                    ? (char)EAsciMap.TriangleUp
                    : (char)EAsciMap.TriangleDown;

                char fiboChar = fiboPercent > 50
                   ? (char)EAsciMap.TriangleUp
                   : (char)EAsciMap.TriangleDown;


                lstRows.Add(new CTelegramRowInfo()
                {
                    Content = $"Status Check of \"{CommandParser.SymbolPair}\" \n" +
                    $"▪ Price: {price.ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))} ({priceChange.ToString("0.00\\%")} {priceChangeChar})\n" +
                    $"▪ Volume: {volume.ToString("N2")} ({volumeChange.ToString("0.00\\%")} {volumeChangeChar})\n" +
                    $"▪ {Support1.ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))}......{Resistance1.ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))}\n" +
                    $"▪ {fiboLineString} ({fiboPercent.ToString("0.00\\%")}{fiboChar})",
                    RefValue = price
                });
            }
          
        }

        private static string getLinePercentString(double min, double current, double max, ref double percent)
        {
            char[] retLineArr = new char[] {
                (char)EAsciMap.SquareEmpty,
                (char)EAsciMap.SquareEmpty,
                (char)EAsciMap.SquareEmpty,
                (char)EAsciMap.SquareEmpty,
                (char)EAsciMap.SquareEmpty,
                (char)EAsciMap.SquareEmpty,
                (char)EAsciMap.SquareEmpty,
                (char)EAsciMap.SquareEmpty,
                (char)EAsciMap.SquareEmpty,
                (char)EAsciMap.SquareEmpty
            };

            if (current > min && current < max)
            {
                double diff1 = current - min;
                double diff2 = max - min;
                percent = diff1 * 10.0 / diff2;
            }
            else if (current <= min)
            {
                percent = 0;
            }
            else if (current >= max)
            {
                percent = 10.0;
            }

            for (int i = 0; i < Math.Max(0, Math.Min(10, (int)percent)); i++)
            {
                retLineArr[i] = (char)EAsciMap.SquareSolid;
            }
            percent = 10 * percent;
            return new string(retLineArr);
        }

        private static void preparePortfolioList()
        {
            Dictionary<string, double> symbolPairVsAmount = DataController.getSpotCoinAmounts();
            Dictionary<string, double> symbolPairVsPrice = DataController.getSpotCoinPrices();

           
            foreach (var key in symbolPairVsAmount.Keys)
            {
                double price = symbolPairVsPrice[key];
                double amount = symbolPairVsAmount[key];

                lstRows.Add(new CTelegramRowInfo()
                {
                    Content = $"{key} | {price.ToString("C4")} x {amount.ToString("N2")}",
                    RefValue = price * amount
                });
            }
        }

        private static void Timer30sec_Tick(object sender, EventArgs e)
        {
           
            DateTime currDateTime = DateTime.Now;

            bool bln1h = currDateTime.Minute == 0;

            //if (currDateTime.Minute % 15 == 0)
            //{
            //    if (DataController.saveCandles(SavedFolderPath, currDateTime))
            //    {

            //        // 15d
            //        if (timer15mAlarmOn)
            //        {
            //            checkAlarmForQuery("*USDT 15m V%1000+");
            //            checkAlarmForQuery("*BTC 15m V%1000+");
            //        }
                   
            //    }
            //}
            //else if (currDateTime.Minute == 1)
            //{
            //    // 1S
            //    if (timer1hAlarmOn)
            //    {
                   
            //        checkAlarmForQuery("*USDT 1h RRRRR", "No red x 5 series in 1S.");
            //        checkAlarmForQuery("*USDT 1h GGGGG", "No green x 5 series in 1S.");
            //    }
               

            //    // 1G
            //    if (timer1DAlarmOn)
            //    {
            //        if (currDateTime.Hour == 3)
            //        {
            //            checkAlarmForQuery("*USDT 1D MA50>MA200", "No symbols found for Golden Cross in USDT pairs.");
            //            checkAlarmForQuery("*BTC 1D MA50>MA200", "No symbols found for Golden Cross in BTC pairs.");
            //            //checkAlarmForQuery("*USDT 1G MA200-", "No symbols found under MA200");

            //        }
            //    }
              

            //    // 4S
            //    if (timer4hAlarmOn)
            //    {
            //        if ((currDateTime.Hour == 3 || currDateTime.Hour == 7 || currDateTime.Hour == 11 ||
            //             currDateTime.Hour == 15 || currDateTime.Hour == 19 || currDateTime.Hour == 23))
            //        {

            //            checkAlarmForQuery("*USDT 4h MACD-", "No symbols found for MACD 4s intersection.");
            //            checkAlarmForQuery("*USDT 4h MA7>MA25", "No symbols found for MA7 > MA25.");
            //        }
            //    }
                
            //}

        }


        private static void checkAlarmForQuery(string query, string notFoundNote = null, Chat chat = null)
        {

            lstRows.Clear();
            CommandParser = CommandParser.ParseCommand(query);


            if (CommandParser.IndicatorType == EIndicatorType.PRICE_CHANGE)
                responseCommandPriceChange();
            else if (CommandParser.IndicatorType == EIndicatorType.VOLUME_CHANGE)
                responseCommandVolumeChange();
            else if (CommandParser.IndicatorType == EIndicatorType.MOVING_AVERAGE)
                responseCommandMA();
            else if (CommandParser.IndicatorType == EIndicatorType.MOVING_AVERAGE_INTERSECTION)
                responseCommandMAIntersection();
            else if (CommandParser.IndicatorType == EIndicatorType.RSI)
                responseCommandRSI();
            else if (CommandParser.IndicatorType == EIndicatorType.CANDLE_COLOR)
                responseCandleColor();
            else if (CommandParser.IndicatorType == EIndicatorType.FIBONACCI)
                responseCommandFibonacci();


            if (lstRows.Count > 50)
            {
                lstRows.RemoveRange(50, lstRows.Count - 50);
            }

            if (lstRows.Count > 0)
            {
                lstRows.Insert(0, new CTelegramRowInfo()
                {
                    Content = $"Results of \"{query}\"{Environment.NewLine}---",
                    RefValue = double.MinValue
                });
            }

            if (lstRows.Count > 0 && notFoundNote == null)
            {
                
                botClient.SendTextMessageAsync(
                        chatId: chat.Id,
                        text: lstRows
                              .OrderBy(s => s.RefValue)
                              .ThenBy(s => s.Content)
                              .Select(s => s.Content)
                              .Aggregate((s1, s2) => $"{s1}{Environment.NewLine}{s2}")
                              .ToString()
                      );
            }
            else if (notFoundNote != null)
            {
                botClient.SendTextMessageAsync(
                        chatId: chat.Id,
                        text: lstRows.Count == 0
                                    ? notFoundNote
                                    : lstRows
                                          .OrderBy(s => s.RefValue)
                                          .ThenBy(s => s.Content)
                                          .Select(s => s.Content)
                                          .Aggregate((s1, s2) => $"{s1}{Environment.NewLine}{s2}")
                                          .ToString()
                      );
            }
        }

        private static void responseCommandFibonacci()
        {
            string refSymbol = CommandParser.SymbolPair.Replace("*", "");
            bool isResistance = CommandParser.C3.EndsWith("FIBR");
            bool isSupport = CommandParser.C3.EndsWith("FIBS");
            string cFormat = CommandParser.SymbolPair.EndsWith("BTC") ? "N8" : "C4";

            foreach (string symbolP in DataController.readAllSymbols(refSymbol, SavedFolderPath))
            {
                List<Ohlc> candles = DataController.getCandlesCached(
                                            SavedFolderPath,
                                             symbolP,
                                             CommandParser.Interval,
                                             //null,
                                             DateTime.Now,
                                             CommandParser.CandlesCount
                                             );

                if (candles.Count == 0) continue;
                if (candles.Last().Date.Month != DateTime.Now.Month) continue;

                double max = candles.Max(c => c.High);
                double min = candles.Min(c => c.Low);
                double Support1 = -1.0;
                double Support2 = -1.0;
                double Resistance1 = -1.0;
                double Resistance2 = -1.0;
                double LastPrice = DataController.getSymbolPrice(symbolP);
                FibonacciLevels = CFibonacciRetracement.GetFibboLevels(min, max);


                if (isSupport)
                {
                    if (FibonacciLevels != null)
                    {
                        Support1 = FibonacciLevels.GetSupportValue(LastPrice, ref Support2);

                        if (Support1 < LastPrice && Support1 * 1.01 >= LastPrice)
                        {
                            lstRows.Add(new CTelegramRowInfo()
                            {
                                Content =
                                $"{symbolP}: {LastPrice.ToString(cFormat, new CultureInfo("en-US"))}{Environment.NewLine}" +
                                $" ▪ Support: {Support1.ToString(cFormat, new CultureInfo("en-US"))}",
                                RefValue = Math.Abs(Support1 - LastPrice)
                            });
                        }
                    }
                }
                else if (isResistance)
                {
                    if (FibonacciLevels != null)
                    {
                        Resistance1 = FibonacciLevels.GetResistanceValue(LastPrice, ref Resistance2);

                        if (Resistance1 > LastPrice && LastPrice * 1.01 <= Resistance1)
                        {
                            lstRows.Add(new CTelegramRowInfo()
                            {

                                Content =
                                $"{symbolP}: {LastPrice.ToString(cFormat, new CultureInfo("en-US"))}{Environment.NewLine}" +
                                $" ▪ Resistance: {Resistance1.ToString(cFormat, new CultureInfo("en-US"))}",
                                RefValue = Math.Abs(Support1 - LastPrice)
                            });
                        }
                    }
                }

               
            }


        }

        private static void responseCandleColor()
        {
            string refSymbol = CommandParser.SymbolPair.Replace("*", "");
            char[] colors = CommandParser.C3.ToCharArray();

            foreach (string symbolP in DataController.readAllSymbols(refSymbol))
            {
                List<Ohlc> candles = DataController.getCandlesCached(
                                            SavedFolderPath,
                                             symbolP,
                                             CommandParser.Interval,
                                             DateTime.Now,
                                             CommandParser.CandlesCount
                                             );
                if (candles.Count == 0) continue;
                if (candles.Last().Date.Month != DateTime.Now.Month) continue;

               

                if (candles.Count == CommandParser.CandlesCount)
                {
                    List<bool> blnMatchList = new List<bool>();
                    
                    for (int i = 0; i < candles.Count; i++)
                    {
                        char c = (candles[i].Close - candles[i].Open) >= 0.0 ? 'G' : 'R';
                        
                        blnMatchList.Add(colors[i] == c);
                    }

                   

                    if (blnMatchList.All(b => b == true))
                    {
                        lstRows.Add(new CTelegramRowInfo()
                        {

                            //Content = $"{symbolP}: {candles.Select(c => c.Close.ToString()).Aggregate((s1,s2) => $"{s1}-{s2}")}",
                            Content = $"{symbolP}({CommandParser.C3}) : {candles.Last().Close}",
                            RefValue = candles.First().Open - candles.Last().Close
                        });
                    }
                    
                }
                
            }

        }

        private static void responseCommandPriceChange()
        {
            string refSymbol = CommandParser.SymbolPair.Replace("*", "");
            bool isUp = CommandParser.C3.Contains("+");
            int percent = int.Parse(CommandParser.C3.Split('%').Last().TrimEnd(new char[] { '+','-'}));
            if (CommandParser.C3.EndsWith("-"))
                percent *= -1;

            string cFormat = CommandParser.SymbolPair.EndsWith("BTC") ? "N8" : "C4";
            string nFormat = CommandParser.SymbolPair.EndsWith("BTC") ? "N8" : "N4";

            foreach (string symbolP in DataController.readAllSymbols(refSymbol))
            {
                List<Ohlc> candles = DataController.getCandlesCached(
                                             SavedFolderPath,
                                             symbolP,
                                             CommandParser.Interval,
                                             DateTime.Now,
                                             CommandParser.CandlesCount
                                             );
                  

                if (candles.Count == 0) continue;
                if (candles.Last().Date.Month != DateTime.Now.Month) continue;

                double ratio = 0.0;
                if (candles.First().Close > 0)
                    ratio = (candles.Last().Close - candles.First().Close) * 100.0 / candles.First().Close;


                if (isUp)
                {
                    if (ratio >= percent && candles.Last().Close > candles.Last().Open)
                    {
                        lstRows.Add(new CTelegramRowInfo()
                        {
                            Content = $" ▪ {symbolP} | {candles.Last().Close.ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))} ({(ratio).ToString("0.00\\%")})",
                            RefValue = ratio
                        });
                    }
                }
                else
                {
                    if (ratio <= percent && candles.Last().Close < candles.Last().Open)
                    {
                        lstRows.Add(new CTelegramRowInfo()
                        {

                            Content = $" ▪ {symbolP} | {candles.Last().Close.ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))} ({(ratio).ToString("0.00\\%")})",
                            RefValue = ratio
                        });
                    }
                }
                

                
            }


        }

        private static void responseCommandVolumeChange()
        {
            string refSymbol = CommandParser.SymbolPair.Replace("*", "");
            bool isUp = CommandParser.C3.Contains("+");
            int percent = int.Parse(CommandParser.C3.Split('%').Last().TrimEnd(new char[] { '+', '-' }));
            if (CommandParser.C3.EndsWith("-"))
                percent *= -1;
            string cFormat = CommandParser.SymbolPair.EndsWith("BTC") ? "N0" : "C4";
            long multip = CommandParser.SymbolPair.EndsWith("BTC") ? 100000000 : 1;

       
            foreach (string symbolP in DataController.readAllSymbols(refSymbol, SavedFolderPath))
            {
                List<Ohlc> candles = DataController.getCandlesCached(
                                             SavedFolderPath,
                                             symbolP,
                                             CommandParser.Interval,
                                             DateTime.Now,
                                             CommandParser.CandlesCount
                                             );
                   

                if (candles.Count == 0) continue;
                if (candles.Last().Date.Month != DateTime.Now.Month) continue;

                double ratio = 0.0;
                if (candles.First().Volume > 0)
                {
                    ratio = (candles.Last().Volume - candles.First().Volume) * 100.0 / candles.First().Volume;
                }

                if (isUp)
                {
                    if (ratio >= percent && candles.Last().Close > candles.Last().Open)
                    {
                        lstRows.Add(new CTelegramRowInfo()
                        {

                            Content = $" ▪ {symbolP} | {(candles.Last().Close * multip).ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))} ({(ratio).ToString("0.00\\%")})",
                            RefValue = ratio
                        });
                    }
                }
                else
                {
                    if (ratio < percent && candles.Last().Close < candles.Last().Open)
                    {
                        lstRows.Add(new CTelegramRowInfo()
                        {

                            Content = $" ▪ {symbolP} | {(candles.Last().Close * multip).ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))}  ({(ratio).ToString("0.00\\%")})",
                            RefValue = ratio
                        });
                    }
                }
            }


        }

        private static void responseCommandMAIntersection()
        {
            string refSymbol = CommandParser.SymbolPair.Replace("*", "");
            bool maFirstIntersectUp = CommandParser.C3.Contains(">");

            string cFormat = CommandParser.SymbolPair.EndsWith("BTC") ? "N8" : "C4";
            string nFormat = CommandParser.SymbolPair.EndsWith("BTC") ? "N8" : "N4";

            // Candle Count:
            // 25 => MA7vsMA25
            // 99 => MA25vsMA99
            // 200 => MA50vsMA200
            foreach (string symbolP in DataController.readAllSymbols(refSymbol, SavedFolderPath))
            {
                List<Ohlc> candles = DataController.getCandlesCached(
                                             SavedFolderPath,
                                             symbolP,
                                             CommandParser.Interval,
                                             DateTime.Now,
                                             CommandParser.CandlesCount
                                             );

                if (candles.Count == 0) continue;
                if (candles.Last().Date.Month != DateTime.Now.Month) continue;

                if (candles.Count == CommandParser.CandlesCount)
                {
                    if (CommandParser.CandlesCount == 25 + 1)
                    {
                     
                        SMA movAvg7 = new SMA(7, ColumnType.Close);
                        SMA movAvg25 = new SMA(25, ColumnType.Close);

                        movAvg7.Load(candles);
                        movAvg25.Load(candles);

                        SingleDoubleSerie movAvg7Serie = movAvg7.Calculate();
                        SingleDoubleSerie movAvg25Serie = movAvg25.Calculate();

                        double firstValofMA7 = (double)movAvg7Serie.Values[24];
                        double firstValofMA25 = (double)movAvg25Serie.Values.Where(v => v.HasValue).First();

                        double lastValofMA7 = (double)movAvg7Serie.Values.Where(v => v.HasValue).Last();
                        double lastValofMA25 = (double)movAvg25Serie.Values.Where(v => v.HasValue).Last();

                        if (maFirstIntersectUp)
                        {
               

                            if (firstValofMA7 < firstValofMA25 && lastValofMA7 >= lastValofMA25)
                            {
                                lstRows.Add(new CTelegramRowInfo()
                                {
                                    Content = $" ▪ {symbolP} | {candles.Last().Close.ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))} ({(lastValofMA7 - lastValofMA25).ToString(nFormat)})",
                                    RefValue = lastValofMA7 - lastValofMA25
                                });
                            }
                        }
                        else
                        {
                            if (firstValofMA7 > firstValofMA25 && lastValofMA7 <= lastValofMA25)
                            {
                                lstRows.Add(new CTelegramRowInfo()
                                {
                                    Content = $" ▪ {symbolP} | {candles.Last().Close.ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))} ({(lastValofMA25 - lastValofMA7).ToString(nFormat)})",
                                    RefValue = lastValofMA25 - lastValofMA7
                                });
                            }
                        }
                    }
                    else if (CommandParser.CandlesCount == 200 + 1)
                    {

                        SMA movAvg50 = new SMA(50, ColumnType.Close);
                        SMA movAvg200 = new SMA(200, ColumnType.Close);

                        movAvg50.Load(candles);
                        movAvg200.Load(candles);

                        SingleDoubleSerie movAvg50Serie = movAvg50.Calculate();
                        SingleDoubleSerie movAvg200Serie = movAvg200.Calculate();

                        double firstValofMA50 = (double)movAvg50Serie.Values[199];
                        double firstValofMA200 = (double)movAvg200Serie.Values.Where(v => v.HasValue).First();

                        double lastValofMA50 = (double)movAvg50Serie.Values.Where(v => v.HasValue).Last();
                        double lastValofMA200 = (double)movAvg200Serie.Values.Where(v => v.HasValue).Last();

                        if (maFirstIntersectUp)
                        {


                            if (firstValofMA50 < firstValofMA200 && lastValofMA50 >= lastValofMA200)
                            {
                                lstRows.Add(new CTelegramRowInfo()
                                {
                                    //Content = String.Format("{0,-10} | {1,-10} | {2,6}", symbolP.PadRight(10,' '), candles.Last().Close.ToString(cFormat, CultureInfo.GetCultureInfo("en-US")), (lastValofMA50 - lastValofMA200).ToString(nFormat)),
                                    Content = $" ▪ {symbolP} | {candles.Last().Close.ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))} ({(lastValofMA50 - lastValofMA200).ToString(nFormat)})",
                                    RefValue = lastValofMA50 - lastValofMA200
                                });
                            }
                        }
                        else
                        {
                            if (firstValofMA50 > firstValofMA200 && lastValofMA50 <= lastValofMA200)
                            {
                                lstRows.Add(new CTelegramRowInfo()
                                {
                                    Content = $" ▪ {symbolP} | {candles.Last().Close.ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))} ({(lastValofMA200 - lastValofMA50).ToString(nFormat)})",
                                    RefValue = lastValofMA200 - lastValofMA50
                                });
                            }
                        }
                    }
                }

            }
        }

        private static void responseCommandMA()
        {
            string refSymbol = CommandParser.SymbolPair.Replace("*", "");
            bool maBelow = CommandParser.C3.EndsWith("-");
            
            string cFormat = CommandParser.SymbolPair.EndsWith("BTC") ? "N8" : "C4";
            string nFormat = CommandParser.SymbolPair.EndsWith("BTC") ? "N8" : "N4";

            foreach (string symbolP in DataController.readAllSymbols(refSymbol))
            {
                List<Ohlc> candles = DataController.getCandlesCached(
                                             SavedFolderPath,
                                             symbolP,
                                             CommandParser.Interval,
                                             DateTime.Now,
                                             CommandParser.CandlesCount
                                             );

                if (candles.Count == 0) continue;
                if (candles.Last().Date.Month != DateTime.Now.Month) continue;

                if (candles.Count == CommandParser.CandlesCount)
                {
                    double maVal = candles.Average(o => o.Close);

                    if (maBelow)
                    {
                        if (candles.Last().Close < maVal)
                        {
                            lstRows.Add(new CTelegramRowInfo()
                            {
                                Content = $" ▪ {symbolP} | {candles.Last().Close.ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))}, MA: {maVal.ToString(nFormat)}",
                                RefValue = maVal - candles.Last().Close
                            });
                        }
                    }
                    
                    else
                    {
                        if (candles.Last().Close >= maVal)
                        {
                            lstRows.Add(new CTelegramRowInfo()
                            {
                                Content = $" ▪ {symbolP} | {candles.Last().Close.ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))}, MA: {maVal.ToString(nFormat)}",
                                RefValue = candles.Last().Close - maVal
                            });
                        }
                    }
                }

            }
        }

        private static void responseVolumeList()
        {

            List<Ohlc> candles = DataController.getCandlesCached(
                                SavedFolderPath,
                                CommandParser.SymbolPair,
                                CommandParser.Interval,
                                //null,
                                DateTime.Now,
                                CommandParser.CandlesCount + 1);

            double prevVol = 0, currVol = 0, linePercent = 0;

            if (candles.Count > 0)
            {
                lstRows.Add(new CTelegramRowInfo()
                {
                    Content = $"Volumes of \"{CommandParser.SymbolPair}\"({CommandParser.Interval}x{CommandParser.CandlesCount})",
                    RefValue = -1.0
                });


                
                foreach (var item in candles)
                {

                    currVol = item.Volume;


                    string volPercent = "";
                    char volumeChangeChar = currVol > prevVol
                       ? (char)EAsciMap.TriangleUp
                       : (char)EAsciMap.TriangleDown;

                    if (prevVol > 0)
                        volPercent = $"{volumeChangeChar}{((currVol - prevVol) * 100.0 / currVol).ToString("0.00\\%")}";


                    lstRows.Add(new CTelegramRowInfo()
                    {
                        Content = $" ▪ {item.Date.ToString("yy.MM.dd HH:mm")} | V: {item.Volume.ToString("N0")} {volPercent}",
                        RefValue = 0.0
                    });

                    prevVol = item.Volume;
                }

                currVol = DataController.getSymbolVolume(CommandParser.SymbolPair);
                string lineStr = getLinePercentString(candles.Min(c => c.Volume), currVol, candles.Max(c => c.Volume), ref linePercent);
                lstRows.Add(new CTelegramRowInfo()
                {
                    Content = $" ▪ Current | {currVol.ToString("N0")} ({linePercent.ToString("0\\%")})\n" +
                    $" ▪ Min {lineStr} Max",
                    RefValue = 0.0
                });
            }


            

           
        }

        private static void responsePriceList()
        {
            string cFormat = CommandParser.SymbolPair.EndsWith("BTC") ? "N8" : "C4";
            double prevPrice = 0, currPrice = 0, linePercent = 0;
            List<Ohlc> candles = DataController.getCandlesCached(
                SavedFolderPath,
                CommandParser.SymbolPair,
                CommandParser.Interval,
                //null,
                DateTime.Now,
                CommandParser.CandlesCount + 1);

            if (candles.Count > 0)
            {
                lstRows.Add(new CTelegramRowInfo()
                {
                    Content =   $"Prices of \"{CommandParser.SymbolPair}\"({CommandParser.Interval}x{CommandParser.CandlesCount})" ,
                    RefValue = -1.0
                });


                foreach (var item in candles)
                {
                    currPrice = item.Close;

                    string pricePercent = "";
                    char priceChangeChar = currPrice > prevPrice
                       ? (char)EAsciMap.TriangleUp
                       : (char)EAsciMap.TriangleDown;

                    if (prevPrice > 0)
                        pricePercent = $"{priceChangeChar}{((currPrice - prevPrice) * 100.0 / currPrice).ToString("0.00\\%")}";

                    lstRows.Add(new CTelegramRowInfo()
                    {
                        Content = $" ▪ {item.Date.ToString("yy.MM.dd HH:mm")} | " +
                        $"{item.Close.ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))} {pricePercent}",
                        RefValue = 0.0
                    });

                    prevPrice = item.Close;
                }


                currPrice = DataController.getSymbolPrice(CommandParser.SymbolPair);
                string lineStr = getLinePercentString(candles.Min(c => c.Close), currPrice, candles.Max(c => c.Close), ref linePercent);
                lstRows.Add(new CTelegramRowInfo()
                {
                    Content = $" ▪ Current {DateTime.Now.ToString("HH:mm")} | {currPrice.ToString(cFormat, CultureInfo.GetCultureInfo("en-US"))} ({linePercent.ToString("0\\%")})\n" +
                    $" ▪ Min {lineStr} Max",
                    RefValue = 0.0
                });
            }

        }

        private static void responseCommandRSI()
        {
            string refSymbol = CommandParser.SymbolPair.Replace("*", "");
            bool rsiBelow = CommandParser.C3.EndsWith("-");


            foreach (string symbolP in DataController.readAllSymbols(refSymbol, SavedFolderPath))
            {
                List<Ohlc> candles = DataController.getCandlesCached(
                                             SavedFolderPath,
                                             symbolP,
                                             CommandParser.Interval,
                                             DateTime.Now,
                                             CommandParser.CandlesCount
                                             );

                if (candles.Count == 0) continue;
                if (candles.Last().Date.Month != DateTime.Now.Month) continue;

                if (candles.Count >= CommandParser.CandlesCount)
                {
                    RSI rsi = new RSI(CommandParser.CandlesCount);

                    rsi.Load(candles);
                    RSISerie serie = rsi.Calculate();

                    if (rsiBelow && serie.RSI.Last().HasValue)
                    {
                        if (serie.RSI.Last().Value < 30.0)
                        {
                            lstRows.Add(new CTelegramRowInfo()
                            {
                                Content = $" ▪ {symbolP} | RSI: {serie.RSI.Last().Value.ToString("N2")}",
                                RefValue = serie.RSI.Last().Value
                            });
                        }
                    }
                    else if (!rsiBelow && serie.RSI.Last().HasValue)
                    {
                        if (serie.RSI.Last().Value > 70.0)
                        {
                            lstRows.Add(new CTelegramRowInfo()
                            {
                                Content = $" ▪ {symbolP} | RSI: {serie.RSI.Last().Value.ToString("N2")}",
                                RefValue = serie.RSI.Last().Value
                            });
                        }
                    }
                }

            }

        }

        private static void responseCommandMACD()
        {
            string refSymbol = CommandParser.SymbolPair.Replace("*", "");
            bool macdBelow = CommandParser.C3.EndsWith("-");
            string cFormat = CommandParser.SymbolPair.EndsWith("BTC") ? "N8" : "C4";


            foreach (string symbolP in DataController.readAllSymbols(refSymbol, SavedFolderPath))
            {
                List<Ohlc> candles = DataController.getCandlesCached(
                                             SavedFolderPath,
                                             symbolP,
                                             CommandParser.Interval,
                                             DateTime.Now,
                                             CommandParser.CandlesCount
                                             );

                if (candles.Count == 0) continue;
                if (candles.Last().Date.Month != DateTime.Now.Month) continue;

                if (candles.Count >= CommandParser.CandlesCount)
                {
                    List<double> macdValueList = new List<double>();

           
                    MACD macd = new MACD(12, 26, 9);
                    macd.Load(candles);
                    MACDSerie serie = macd.Calculate();
                    
                    int len = serie.MACDHistogram.Count;

                    bool IsThereIntersection =
                        serie.MACDHistogram[len - 1].HasValue &&
                        serie.MACDHistogram[len - 2].HasValue &&
                        serie.MACDHistogram[len - 1].Value * serie.MACDHistogram[len - 2].Value < 0.0;

                    double diff =
                        serie.MACDHistogram[len - 1].HasValue && serie.MACDHistogram[len - 2].HasValue
                        ? Math.Abs(serie.MACDHistogram[len - 1].Value - serie.MACDHistogram[len - 2].Value)
                        : double.MaxValue;

                    bool IsMacdLineAtNegative =
                        serie.MACDLine[len - 1].HasValue &&
                        serie.MACDLine[len - 1].Value < 0.0;

                    bool IsMacdLineAtPositive =
                       serie.MACDLine[len - 1].HasValue &&
                       serie.MACDLine[len - 1].Value > 0.0;

                    if (macdBelow)
                    {
                        if (IsMacdLineAtNegative && IsThereIntersection)
                        {
                            lstRows.Add(new CTelegramRowInfo()
                            {
                                Content = $" ▪ {symbolP} | {candles.Last().Close.ToString(cFormat, new CultureInfo("en-US"))} {(char)9650}",
                                RefValue = diff
                            });
                        }
                    }
                    else
                    {
                        if (IsMacdLineAtPositive && IsThereIntersection)
                        {
                            lstRows.Add(new CTelegramRowInfo()
                            {
                                Content = $" ▪ {symbolP} | {candles.Last().Close.ToString(cFormat)}",
                                RefValue = diff
                            });
                        }
                    }
                }

            }
        }

        public void setDataController(CBinanceDataController dataController)
        {
            DataController = dataController;

            //
            saveCandles("VIDTUSDT", KlineInterval.FiveMinutes, 1000);
        }

        private void saveCandles(string symbol, KlineInterval interval, int limit)
        {
            string cFormat = "C4";
            List<Ohlc> candles = DataController.getCandles(
                                             symbol,
                                             interval,
                                             null,
                                             DateTime.Now,
                                             limit
                                             );

            StringBuilder sb = new StringBuilder();
            foreach (var item in candles)
            {
                sb.AppendLine($"{item.Date.ToString("yyyy.MM.dd HH:mm:ss")}\t" +
                    $"{item.Open.ToString(cFormat, new CultureInfo("en-US"))}\t" +
                    $"{item.High.ToString(cFormat, new CultureInfo("en-US"))}\t" +
                    $"{item.Low.ToString(cFormat, new CultureInfo("en-US"))}\t" +
                    $"{item.Close.ToString(cFormat, new CultureInfo("en-US"))}\t" +
                    $"{item.Volume.ToString(cFormat, new CultureInfo("en-US"))}");
            }
            System.IO.File.WriteAllText(symbol + ".txt", sb.ToString());
        }

        private static DateTime getStartDateTime(KlineInterval interval, int candlesCount)
        {

            int multip = Math.Min(1, candlesCount - 1);
            switch (interval)
            {
                case KlineInterval.FifteenMinutes:
                    return DateTime.Now.AddMinutes(-15 * multip);
                case KlineInterval.OneHour:
                    return DateTime.Now.AddHours(-1 * multip);
                case KlineInterval.OneDay:
                    return DateTime.Now.AddDays(-1 * multip);
                case KlineInterval.OneWeek:
                    return DateTime.Now.AddDays(-7 * multip);
                case KlineInterval.OneMonth:
                    return DateTime.Now.AddDays(-30 * multip);
                default:
                    return DateTime.Now;
            }
        }

        //public static string TelegramSendMessage(string text)
        //{
        //    string urlString = $"https://api.telegram.org/bot{AccessToken}/sendMessage?chat_id={ChatID}&text={text}";

        //    WebClient webclient = new WebClient();

        //    return webclient.DownloadString(urlString);
        //}

      

        //public async Task sendMessage(string destID, string text)
        //{
        //    try
        //    {
        //        var bot = new Telegram.Bot.TelegramBotClient(YourBotTokenHere);
        //        await bot.SendTextMessageAsync(destID, text);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("err");
        //    }
        //}
    }

    public class CTelegramRowInfo
    {
        public string Content { get; set; }
        public double RefValue { get; set; }
    }
}
