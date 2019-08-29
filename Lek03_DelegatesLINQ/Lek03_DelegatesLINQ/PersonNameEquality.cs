using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lek03_DelegatesLINQ
{
    class PersonNameEquality : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return string.Equals(x.Name, y.Name);
        }

        public int GetHashCode(Person obj)
        {
            return obj.Name.Length;
        }
    }
}
