using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TooDeepLib
{
    public interface IMyExternalClass
    {
        string GetMeAsText();
    }

    public class MyExternalClass : IMyExternalClass
    {
        public string GetMeAsText()
        {
            return "I am MyExternalClass";
        }
    }
}
