using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTrader.Fibonacci
{

    public class CFibboLevels
    {
        public double PointA { get; set; }
        public double PointB { get; set; }
        public double RetracementLevel_23_6 { get; set; }
        public double RetracementLevel_38_2 { get; set; }
        public double RetracementLevel_50_0 { get; set; }
        public double RetracementLevel_61_8 { get; set; }
        public double Extension1_Level_161_8 { get; set; }
        public double Extension2_Level_261_8 { get; set; }
        public double Extension3_Level_423_6 { get; set; }
        public double Extension4_Level_685_4 { get; set; }
        public double Extension5_Level_1109 { get; set; }
        public double Extension6_Level_1794_4 { get; set; }
        public double Extension7_Level_2903_4 { get; set; }
        public double Extension8_Level_4697_8 { get; set; }
        public double Extension9_Level_7601_2 { get; set; }

       

        public double Extension10_Level_12299 { get; set; }

        public double GetResistanceValue(double val, ref double resistance2)
        {
            if (val > PointA && val < RetracementLevel_23_6)
            {
                resistance2 = RetracementLevel_38_2;
                return RetracementLevel_23_6;
            }
            else if (val >= RetracementLevel_23_6 && val < RetracementLevel_38_2)
            {
                resistance2 = RetracementLevel_50_0;
                return RetracementLevel_38_2;
            }
            else if (val >= RetracementLevel_38_2 && val < RetracementLevel_50_0)
            {
                resistance2 = RetracementLevel_61_8;
                return RetracementLevel_50_0;
            }
            else if (val >= RetracementLevel_50_0 && val < RetracementLevel_61_8)
            {
                resistance2 = PointB;
                return RetracementLevel_61_8;
            }
            else if (val >= RetracementLevel_61_8 && val < PointB)
            {
                resistance2 = Extension1_Level_161_8;
                return PointB;
            }
            else
            {
                return -1.0;
            }
        }

        public double GetSupportValue(double val, ref double support2)
        {
            if (val > PointA && val < RetracementLevel_23_6)
            {
                support2 = PointA * 0.236;
                return PointA;
            }
            else if (val >= RetracementLevel_23_6 && val < RetracementLevel_38_2)
            {
                support2 = PointA;
                return RetracementLevel_23_6;
            }
            else if (val >= RetracementLevel_38_2 && val < RetracementLevel_50_0)
            {
                support2 = RetracementLevel_23_6;
                return RetracementLevel_38_2;
            }
            else if (val >= RetracementLevel_50_0 && val < RetracementLevel_61_8)
            {
                support2 = RetracementLevel_38_2;
                return RetracementLevel_50_0;
            }
            else if (val >= RetracementLevel_61_8 && val < PointB)
            {
                support2 = RetracementLevel_50_0;
                return RetracementLevel_61_8;
            }
            else
            {
                support2 = RetracementLevel_61_8;
                return -1.0;
            }
        }
    }
}
