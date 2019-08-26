using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lek03_DelegatesLINQ
{
    class Program
    {
        public static void Exercise1()
        {
            List<Person> people = Person.ParseCSVFile(@"C:\git\dmu4-csharp\Lek03_DelegatesLINQ\data1.csv");

            Console.WriteLine("Score below 2:");
            people.FindAll(p => p.Score < 2).ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.WriteLine("Even score:");
            people.FindAll(p => p.Score % 2 == 0).ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.WriteLine("Even score, weight > 60:");
            people.FindAll(p => p.Score % 2 == 0 && p.Weight > 60).ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.WriteLine("Score divisible by 3:");
            people.FindAll(p => p.Score % 3 == 0).ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        public static void Exercise2()
        {
            List<Person> people = Person.ParseCSVFile(@"C:\git\dmu4-csharp\Lek03_DelegatesLINQ\data1.csv");

            Console.WriteLine("First person with a score of 3:");
            Console.WriteLine(people[people.FindIndex(p => p.Score == 3)]);
            Console.WriteLine();

            Console.WriteLine("First person with a score of 3, under 10 years:");
            Console.WriteLine(people[people.FindIndex(p => p.Score == 3 && p.Age < 10)]);
            Console.WriteLine();

            Console.WriteLine(string.Format("There are {0} people with a score of 3, under 10 years.\n", people.Count(p => p.Age < 10 && p.Score == 3)));

            Console.WriteLine("First person with a score of 3, under 8 years has index:");
            Console.WriteLine(people.FindIndex(p => p.Score == 3 && p.Age < 10));
            Console.WriteLine();
        }

        public static void Exercise3()
        {
            List<Person> people = Person.ParseCSVFile(@"C:\git\dmu4-csharp\Lek03_DelegatesLINQ\data1.csv");

            people.SetAccepted(p => p.Age > 10);

            people.ForEach(Console.WriteLine);
        }

        public static void Exercise4()
        {
            List<Person> people = Person.ParseCSVFile(@"C:\git\dmu4-csharp\Lek03_DelegatesLINQ\data1.csv");

            Console.WriteLine("Sorted by age (asc):");
            people.Sort(new Person.SortAge());
            people.GetRange(0, 10).ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.WriteLine("Sorted by score (desc):");
            people.Sort(new Person.SortScore(true));
            people.GetRange(0, 10).ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        public static void Exercise6()
        {
            EventClass.StringToInt length = new EventClass.StringToInt(EventClass.CountChars);
            Console.WriteLine($"Chars in 'Mulle' = {length("Mulle")}");
        }

        public static void Exercise7()
        {
            Console.WriteLine($"Der er {EventClass.DelegateUser(u => u.Count(c => c == 'a'), "Mads")} a'er i 'Mads'.");
            Console.WriteLine($"Der er {EventClass.DelegateUser(u => u.Count(c => c == 'a'), "Mazda")} a'er i 'Mazda'.");
        }

        static void Main(string[] args)
        {
            // Ad, ad, ad.
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise6();
            Exercise7();

            Console.ReadLine();
        }
    }
}
