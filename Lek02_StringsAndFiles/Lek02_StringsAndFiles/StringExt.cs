using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lek02_StringsAndFiles
{
    static class StringExt
    {
        public static bool IsPalindrome(this string str)
        {
            return RecursionTools.IsPalindrome(str);
        }
    }
}
