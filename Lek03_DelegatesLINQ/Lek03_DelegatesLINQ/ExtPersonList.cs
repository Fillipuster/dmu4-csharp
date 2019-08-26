using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lek03_DelegatesLINQ
{
    static class ExtPersonList
    {
        public static void SetAccepted(this List<Person> people, Predicate<Person> check)
        {
            foreach (var person in people)
            {
                person.Accepted = check(person);
            }
        }
    }
}
