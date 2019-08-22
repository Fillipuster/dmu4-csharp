using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lek02_StringsAndFiles
{
    class SimplePerson
    {
        public delegate string FormatName(SimplePerson person);

        public static string FormatFullName(SimplePerson person)
        {
            return person.FirstName + " " + person.LastName;
        }

        public static string FormatFormalName(SimplePerson person)
        {
            return person.LastName + ", " + person.FirstName;
        }

        public static string FormatFirstName(SimplePerson person)
        {
            return person.FirstName;
        }

        public string FirstName;
        public String LastName;

        public SimplePerson(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void FormattedPrint(FormatName format)
        {
            Console.WriteLine(format(this));
        }
    }
}
