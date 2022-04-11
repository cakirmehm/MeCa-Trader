using Binance.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoinTrader.Source
{
    public class CTelegramCommandParser
    {
        public string SymbolPair { get; set; }
        public KlineInterval Interval { get; set; }
        public string C3 { get; set; }

        public EAssetType AssetType { get; set; }
        public ECommandType CommandType { get; set; }
        public EIndicatorType IndicatorType { get; set; }
        public ECandleStickPatterns CandlePattern { get; set; }
        public string ErrorMessage { get; set; }
        public int CandlesCount { get; set; } = 0;
        public List<string> OrderParams { get; set; } = new List<string>();
        public char OrderBuyOrSell { get; set; }

        private string[] P3List = new string[] {
            "RSI-",
            "RSI+",
            "MACD-",
            "MACD+",
            "MA200+",
            "MA200-",
            "MA99+",
            "MA99-",
            "MA50+",
            "MA50-",
            "MA25+",
            "MA25-",
            "MA7+",
            "MA7-",
            "MA7<MA25",
            "MA7>MA25",
            "MA25>MA99",
            "MA25<MA99",
            "MA50>MA200",
            "MA50<MA200",
            "FIBS",
            "FIBR"
        };

        public CTelegramCommandParser ParseCommand(string command)
        {

            resetCommand();

            if (command.StartsWith("+") || command.StartsWith("-"))
            {
                // +ETHBUSD 0.5 4321 4320 (ETHBUSD 4320'ye gelince 0.5 miktar al & Bildirim yolla)
                // -ETHBUSD ALL (Tüm ETHBUSD'leri market değerinden sat)
                // -* ALL (Tüm cüzdanı sat - onaylı)
                // -* ALL BTC (Tüm cüzdanı BTC'ye dönüştür -onaylı)
                // -ETHBUSD ALL 4526 4525 (Tüm ETHBUSD'leri 4525 değerinden sat)
                // -ETHBUSD 0.2 4510 4511 (Fiyat 4511'e geldiğinde 0.2 adet ETHBUSD sat & Bildirim)
                // -ETHBUSD 1.0 4165 4150 => -ETHBUSD 0.4 4235 4236
                // +ETHBUSD 0.2 IF BTCBUSD<61000 (BTC 61000 altına indiğinde 0.2 adet ETHBUSD market alımı yap)
                // +ETHBUSD 0.2 4010 4000 IF BTCBUSD<61000 (BTC 61000 altına indiğinde 0.2 adet ETHBUSD  $4000 alım emri koy)
                // +ETHBUSD 0.4 15%
                // -ETHBUSD 0.4 20%  


                IndicatorType = EIndicatorType.ORDER;

                OrderBuyOrSell = command.First();
                string[] splitted = command.Split(new string[] { "+", "-", " " }, StringSplitOptions.RemoveEmptyEntries);
                OrderParams.AddRange(splitted);

                if (splitted.Length == 2)
                {
                    // -* ALL (Tüm cüzdanı sat - onaylı)
                    // -* ALL BTC (Tüm cüzdanı BTC'ye dönüştür -onaylı)
                    // -ETHBUSD ALL (Tüm ETHBUSD'leri market değerinden sat)
                }
                else if (splitted.Length == 3)
                {
                    // +ETHBUSD 0.4 15%
                    // -ETHBUSD 0.4 20%  
                    // +ETHBUSD 0.5 4321  
                    // -ETHBUSD ALL 4521  
                    // -ETHBUSD 0.2 4510  
                    // -ETHBUSD 1.0 4165  
                    string p1 = SymbolPair = splitted[0];
                    string p2 = splitted[1];
                    string p3 = splitted[2];
                }
              
               


            }
            else
            {
                string[] splitted = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                int len = splitted.Length;

                if (len == 4)
                {
                    // Alarm, Order, etc.
                    string p1 = splitted[0];
                    string p2 = splitted[1];
                    string p3 = splitted[2];
                    string p4 = C3 = splitted[3];

      



                    if (p1.Equals("ALARM"))
                    {
                        IndicatorType = EIndicatorType.ALARM;
                    }
                }
                else if (len == 3)
                {
                    string p1 = splitted[0].ToUpper();
                    string p2 = splitted[1];
                    string p3 = C3 = splitted[2];




                    // p1 = SymbolPair or pairs
                    SymbolPair = p1;
                    CommandType = p1.StartsWith("*") ? ECommandType.REGEX : ECommandType.STANDARD;


                    // p2 = Interval
                    try
                    {
                        Interval = getInterval(p2);
                    }
                    catch (Exception exc)
                    {
                        throw new Exception();
                    }



                    if (p3.Contains("#"))
                    {

                        if (p3.StartsWith("P#"))
                        {
                            AssetType = EAssetType.PRICE;
                            IndicatorType = EIndicatorType.PRICE_LIST;

                            CandlesCount = int.Parse(p3.Replace("P#", ""));

                        }
                        else if (p3.StartsWith("V#"))
                        {
                            AssetType = EAssetType.VOLUME;
                            IndicatorType = EIndicatorType.VOLUME_LIST;
                            CandlesCount = int.Parse(p3.Replace("V#", ""));

                        }
                        else
                        {
                            AssetType = EAssetType.NONE;
                            throw new Exception();
                        }
                        // Son N adet Hacim | Fiyat

                    }

                    else if (Regex.IsMatch(p3, "\"[^\"]+\""))
                    {
                        AssetType = EAssetType.PRICE;
                        IndicatorType = EIndicatorType.CANDLE_PATTERN;

                        p3 = p3.Replace("\"", "");
                        CandlePattern = getCandleStickPattern(p3);

                        if (CandlePattern == ECandleStickPatterns.NONE)
                        {
                            // Error P3 CandleStick Pattern
                        }
                        else
                        {
                            // TODO: 12 Candlestick Pattern
                        }
                    }
                    else if (P3List.Any(p => p.Equals(p3.Replace(" ", ""))))
                    {
                        CandlePattern = ECandleStickPatterns.NONE;
                        p3 = p3.Replace("\"", "");

                        // Listeden
                        if (p3.StartsWith("RSI"))
                        {
                            AssetType = EAssetType.PRICE;
                            IndicatorType = EIndicatorType.RSI;
                            CandlesCount = 14;
                        }
                        else if (p3.StartsWith("MACD"))
                        {
                            AssetType = EAssetType.PRICE;
                            IndicatorType = EIndicatorType.MACD;
                            CandlesCount = 26 * 14;
                        }
                        else if (Regex.IsMatch(p3, "MA[0-9]+"))
                        {
                            AssetType = EAssetType.PRICE;

                            if (p3.Contains("<") || p3.Contains(">"))
                            {
                                IndicatorType = EIndicatorType.MOVING_AVERAGE_INTERSECTION;

                                string firstMA = p3.Split(new string[] { "<", ">" }, StringSplitOptions.RemoveEmptyEntries).First().Trim();
                                string secondMA = p3.Split(new string[] { "<", ">" }, StringSplitOptions.RemoveEmptyEntries).Last().Trim();

                                if (firstMA.Equals("MA7") && secondMA.Equals("MA25"))
                                {
                                    CandlesCount = 25 + 1;
                                }
                                else if (firstMA.Equals("MA25") && secondMA.Equals("MA99"))
                                {
                                    CandlesCount = 99 + 1;
                                }
                                else if (firstMA.Equals("MA50") && secondMA.Equals("MA200"))
                                {
                                    CandlesCount = 200 + 1;
                                }
                                else
                                {
                                    throw new Exception();
                                }

                            }

                            else
                            {

                                IndicatorType = EIndicatorType.MOVING_AVERAGE;
                                try
                                {
                                    CandlesCount = int.Parse(p3.Replace("MA", "").TrimEnd(new char[] { '+', '-' }));
                                }
                                catch (Exception exc)
                                {

                                    throw new Exception();
                                }
                            }



                        }
                        else if (Regex.IsMatch(p3, "FIB(S|R)"))
                        {
                            // Fibonacci
                            IndicatorType = EIndicatorType.FIBONACCI;
                            CommandType = ECommandType.STANDARD;
                            CandlesCount = 24;

                        }

                        else
                        {
                            AssetType = EAssetType.NONE;
                            IndicatorType = EIndicatorType.NONE;
                            CandlesCount = 0;
                        }


                    }
                    else if (Regex.IsMatch(p3, @"(R|G)+"))
                    {
                        // Son N adet Fiyat R = Red, G  = Green
                        AssetType = EAssetType.PRICE;
                        IndicatorType = EIndicatorType.CANDLE_COLOR;
                        CandlePattern = ECandleStickPatterns.NONE;
                        char[] colors = p3.ToCharArray();
                        CandlesCount = colors.Length;


                    }
                    else if (Regex.IsMatch(p3, @"V%[1-9][0-9]{1,2}"))
                    {
                        AssetType = EAssetType.VOLUME;
                        IndicatorType = EIndicatorType.VOLUME_CHANGE;
                        CandlesCount = 2;
                    }
                    else if (Regex.IsMatch(p3, @"(P|F)%[1-9][0-9]{1,2}"))
                    {
                        AssetType = EAssetType.PRICE;
                        IndicatorType = EIndicatorType.PRICE_CHANGE;
                        CandlesCount = 2;
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                else if (len == 1)
                {
                    if (command.EndsWith("BTC") || command.EndsWith("USDT"))
                    {
                        SymbolPair = command;
                        CommandType = ECommandType.STANDARD;
                        IndicatorType = EIndicatorType.CURRENT_STAT;
                        AssetType = EAssetType.NONE;
                    }
                }
                else
                {
                    throw new Exception();
                }
            }

            

            return this;
        }

        private void resetCommand()
        {
            AssetType = EAssetType.NONE;
            OrderParams.Clear();
            IndicatorType = EIndicatorType.NONE;
            
        }

        private CTelegramCommandParser error(string pMsg)
        {
            ErrorMessage = pMsg;
            return this;
        }

        private ECandleStickPatterns getCandleStickPattern(string p3)
        {
            ECandleStickPatterns temp = ECandleStickPatterns.NONE;

            for (int i = 1; i < Enum.GetNames(typeof(ECandleStickPatterns)).Length; i++)
            {
                temp = (ECandleStickPatterns)i;
                if (temp.ToString().Equals(p3))
                {
                    return temp;
                }
                    
            }
            return ECandleStickPatterns.NONE;
        }

        private KlineInterval getInterval(string p2)
        {
            switch (p2)
            {
                case "1d":
                case "1m":
                    return KlineInterval.OneMinute;
                case "15d":
                case "15m":
                    return KlineInterval.FifteenMinutes;
                case "1s":
                case "1h":
                    return KlineInterval.OneHour;
                case "4s":
                case "4h":
                    return KlineInterval.FourHour;
                case "1G":
                case "1D":
                case "24s":
                case "24h":
                    return KlineInterval.OneDay;
                case "1H":
                case "1W":
                case "7G":
                case "7D":
                    return KlineInterval.OneWeek;
                case "1A":
                case "1M":
                case "4H":
                case "4W":
                case "30G":
                case "30D":
                    return KlineInterval.OneMonth;
                default:
                    throw new Exception();
            }
        }
    }

    public enum EAssetType
    {
        NONE,
        PRICE,
        VOLUME
    }

    public enum ECommandType
    {
        NONE,
        STANDARD,
        REGEX
    }

    public enum EIndicatorType
    {
        NONE,
        CURRENT_STAT,
        MOVING_AVERAGE,
        MOVING_AVERAGE_INTERSECTION,
        RSI,
        MACD,
        CANDLE_COLOR,
        PRICE_CHANGE,
        VOLUME_CHANGE,
        FIBONACCI,
        CANDLE_PATTERN,
        PRICE_LIST,
        VOLUME_LIST,
        ALARM,
        ORDER
    }

    public enum ECandleStickPatterns
    {
        NONE,
        Hammer,
        InvertedHammer,
        ThreeWhiteSoldiers,
        BullishHarami,
        HangingMan,
        ShootingStar,
        ThreeBlackCrows,
        BearishHarami,
        DarkCloudCover,
        RisingThree,
        FallingThree,
        GraveStoneDoji,
        LongLeggedDoji,
        DragonFlyDoji
    }

}
