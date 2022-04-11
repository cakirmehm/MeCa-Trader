using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTrader.Source
{
    // Karakter ASCII Map
    // -------------------
    // 9650: Yukarı üçgen
    // 9632: Dolu Kare
    // 9633: Boş Kare
    public enum EAsciMap
    {
        SquareSolid = 9632,
        SquareEmpty = 9633,

        TriangleUp = 9650,
        TriangleDown = 9660,

    }
}
