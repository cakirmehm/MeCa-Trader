using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTrader.Fibonacci
{
    class CFibonacciRetracement
    {

        /// <summary>
        /// Get Fibonacci Retracements and Extensions for pure fibonacci levels.
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <returns></returns>
        public static CFibboLevels GetFibboLevels(double pointA, double pointB)
        {
            return new CFibboLevels
            {
                PointA = pointA,
                PointB = pointB,
                RetracementLevel_23_6 = pointA + CConstants.RetracementLevel_23_6 * (pointB - pointA),
                RetracementLevel_38_2 = pointA + CConstants.RetracementLevel_38_2 * (pointB - pointA),
                RetracementLevel_50_0 = pointA + CConstants.RetracementLevel_50_0 * (pointB - pointA),
                RetracementLevel_61_8 = pointA + CConstants.RetracementLevel_61_8 * (pointB - pointA),
                Extension1_Level_161_8 = pointA + CConstants.Extension1_Level_161_8 * (pointB - pointA),
                Extension2_Level_261_8 = pointA + CConstants.Extension2_Level_261_8 * (pointB - pointA),
                Extension3_Level_423_6 = pointA + CConstants.Extension3_Level_423_6 * (pointB - pointA),
                Extension4_Level_685_4 = pointA + CConstants.Extension4_Level_685_4 * (pointB - pointA),
                Extension5_Level_1109 = pointA + CConstants.Extension5_Level_1109 * (pointB - pointA),
                Extension6_Level_1794_4 = pointA + CConstants.Extension6_Level_1794_4 * (pointB - pointA),
                Extension7_Level_2903_4 = pointA + CConstants.Extension7_Level_2903_4 * (pointB - pointA),
                Extension8_Level_4697_8 = pointA + CConstants.Extension8_Level_4697_8 * (pointB - pointA),
                Extension9_Level_7601_2 = pointA + CConstants.Extension9_Level_7601_2 * (pointB - pointA),
                Extension10_Level_12299 = pointA + CConstants.Extension10_Level_12299 * (pointB - pointA)
            };
        }

        /// <summary>
        /// Get Fibonacci Retracement or Extension for given level.
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="fibonacciLevel">A decimal value specifying the level (Do not pass it as percentage).</param>
        /// <returns></returns>
        public static double GetFibboLevels(double pointA, double pointB, double fibonacciLevel)
        {
            return pointA + fibonacciLevel * (pointB - pointA);
        }
    }


}
