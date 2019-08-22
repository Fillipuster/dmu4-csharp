using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lek02_StringsAndFiles
{
    class Program
    {
        static void Experimentation()
        {
            int num;
            if (int.TryParse("22", out num)) // TryParse doesn't throw an exception, but rather returns false if the parse failed
            {
                Console.WriteLine(num);
            }

            string str = "This is really great!";
            foreach (var v in str.Split(' '))
            {
                Console.WriteLine(v);
            }
        }

        static void PeopleList()
        {
            List<Person> people = Person.ParseCSVFile(@"C:\git\dmu4-csharp\Lek02_StringsAndFiles\data.csv");

            people.Sort(new NameSorter());

            people.Sort((p1, p2) => p1.Weight.CompareTo(p2.Weight));

            people.Reverse();

            people = people.GetRange(0, 10);

            foreach (var p in people)
            {
                Console.WriteLine(p);
            }
        }

        static void Extensions()
        {
            double number = 9;
            Console.WriteLine(number.power(2));
            Console.WriteLine(number.sqrt());
        }

        static void Recursion()
        {
            Console.WriteLine(RecursionTools.IsPalindrome("test"));
            Console.WriteLine(RecursionTools.IsPalindrome("radar"));
            Console.WriteLine(RecursionTools.IsPalindrome("raddar"));
            Console.WriteLine(RecursionTools.IsPalindrome("regninger"));

            Console.WriteLine(RecursionTools.Factorial(5));
            Console.WriteLine(RecursionTools.Factorial(-12));
        }

        static void Delegates()
        {
            // Delegates opgaver here
        }

        static void Main(string[] args)
        {
            Recursion();

            Console.ReadLine();
        }
    }
}
