using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTrader.Fibonacci
{
    class CPivotPoints
    {
        /// <summary>
        /// Get commonly known PivotPoints types.
        /// </summary>
        /// <param name="high"></param>
        /// <param name="low"></param>
        /// <param name="close"></param>
        /// <param name="type">Type of PivotPoints to get, default is ClassicOrStandard.</param>
        /// <returns></returns>
        public static CPivotLevelsBase GetPivotPointsLevels(double high, double low, double close, EPivotPointsType type = EPivotPointsType.ClassicOrStandard)
        {
            //https://www.babypips.com/tools/pivot-point-calculator
            //https://www.babypips.com/learn/forex/other-pivot-point-calculation-methods
            switch (type)
            {
                case EPivotPointsType.Fibonacci:
                    return GetFibonacciPivotPoints(high, low, close);
                case EPivotPointsType.ClassicOrStandard:
                case EPivotPointsType.Default:
                    return GetClassicOrStandardPivotPoints(high, low, close);
            }

            throw new InvalidOperationException();
        }

        private static CFibonacciPivotLevels GetFibonacciPivotPoints(double high, double low, double close)
        {
            var pivotLevels = new CFibonacciPivotLevels();
            double PP = (high + low + close) / 3;
            pivotLevels.PivotPoint = PP;
            pivotLevels.R1 = PP + ((high - low) * .382);
            pivotLevels.S1 = PP - ((high - low) * .382);

            pivotLevels.R2 = PP + ((high - low) * .618);
            pivotLevels.S2 = PP - ((high - low) * .618);

            pivotLevels.R3 = PP + ((high - low) * 1.000);
            pivotLevels.S3 = PP - ((high - low) * 1.000);

            return pivotLevels;
        }

        private static CClassicOrStandardPivotLevels GetClassicOrStandardPivotPoints(double high, double low, double close)
        {
            var pivotLevels = new CClassicOrStandardPivotLevels();
            double PP = (high + low + close) / 3;
            pivotLevels.PivotPoint = PP;
            pivotLevels.R1 = (2 * PP) - low;
            pivotLevels.S1 = (2 * PP) - high;

            pivotLevels.R2 = PP + (high - low);
            pivotLevels.S2 = PP - (high - low);

            pivotLevels.R3 = high + 2 * (PP - low);
            pivotLevels.S3 = low - 2 * (high - PP);

            return pivotLevels;
        }


    }


}
