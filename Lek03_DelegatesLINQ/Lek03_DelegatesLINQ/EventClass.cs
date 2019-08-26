using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lek03_DelegatesLINQ
{
    class EventClass
    {
        public delegate int StringToInt(string str);

        public static int CountChars(string str)
        {
            return str.Length;
        }

        public static int DelegateUser(StringToInt toInt, string str)
        {
            return toInt(str);
        }
    }
}
