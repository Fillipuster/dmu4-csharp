using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lek02_StringsAndFiles
{
    class WeightSorter : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Weight.CompareTo(y.Weight);
        }
    }
}
