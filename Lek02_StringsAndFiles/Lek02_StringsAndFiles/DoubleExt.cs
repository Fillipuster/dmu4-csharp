using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lek02_StringsAndFiles
{
    static class DoubleExt
    {
        public static double power(this double baseNum, double expNum)
        {
            return Math.Pow(baseNum, expNum);
        }

        public static double sqrt(this double baseNum)
        {
            return Math.Sqrt(baseNum);
        }
    }
}
