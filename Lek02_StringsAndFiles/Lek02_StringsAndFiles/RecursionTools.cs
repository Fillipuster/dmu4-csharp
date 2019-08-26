using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lek02_StringsAndFiles
{
    public static class RecursionTools
    {
        public static int Factorial(int num)
        {
            return (num <= 0) ? 1 : num * Factorial(--num);
        }

        public static int Power(int num, int exponent)
        {
            if (exponent <= 0)
                return 1;

            return num * Power(num, --exponent);
        }

        public static bool IsPalindrome(string str)
        {
            return IsPalindrome(str, 0);
        }

        private static bool IsPalindrome(string str, int step)
        {
            if (step >= str.Length / 2)
                return true;

            if (str[step] != str[str.Length - step - 1])
                return false;

            return IsPalindrome(str, ++step);
        }
    }
}
