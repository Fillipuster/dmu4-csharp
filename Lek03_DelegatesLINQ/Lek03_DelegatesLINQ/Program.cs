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

        public static void Exercise8()
        {
            List<Person> people = Person.ParseCSVFile(@"C:\git\dmu4-csharp\Lek03_DelegatesLINQ\data1.csv");

            var sorted = from p in people orderby p.Age descending select p; // Sleek way
            sorted = people.OrderBy(p => p.Age); // Method / old way

            sorted.ToList().ForEach(Console.WriteLine);
        }

        public static void Exercise9()
        {
            List<Person> people = Person.ParseCSVFile(@"C:\git\dmu4-csharp\Lek03_DelegatesLINQ\data1.csv");

            // a
            Console.WriteLine("Sorted by deviance from average age:");
            var avgAge = (int)people.Select(p => p.Age).Average();
            var diff = from p in people orderby Math.Abs((p.Age > avgAge ? p.Age - avgAge : p.Age + avgAge) - avgAge) select p;
            //Console.WriteLine("Average = " + avgAge);
            diff.ToList().ForEach(Console.WriteLine);
            Console.WriteLine();

            // b
            Console.WriteLine("Alternate method:");
            var b = from p in people orderby Math.Sqrt(p.Weight * p.Weight + p.Age * p.Age) select p;
            b.ToList().ForEach(Console.WriteLine);
        }

        public static void Exercise10()
        {
            int[] numbers = { 34, 8, 56, 31, 79, 150, 88, 7, 200, 47, 88, 20 };

            // a
            var twoDigitAsc = from n in numbers where n > 9 orderby n ascending select n;
            twoDigitAsc.ToList<int>().ForEach(n => Console.Write($"{n}, "));
            Console.WriteLine();

            // b
            var twoDigitDesc = from n in numbers where n > 9 orderby n descending select n;
            twoDigitDesc.ToList<int>().ForEach(n => Console.Write($"{n}, "));
            Console.WriteLine();

            // c
            var asStrings = from n in numbers select n.ToString();
            asStrings.ToList<string>().ForEach(n => Console.Write($"{n}, "));
            Console.WriteLine();

            // d
            var classification = from n in numbers select n.ToString() + (n % 2 == 0 ? " even" : " uneven");
            classification.ToList<string>().ForEach(n => Console.Write($"{n}, "));
            Console.WriteLine();

            // e
            var objClassification = from n in numbers select new { num = n, even = n % 2 == 0 };
            objClassification.ToList().ForEach(o => Console.WriteLine($"{o.num} (even ? {o.even})"));
            Console.WriteLine();
        }

        public static void Exercise11()
        {
            List<Person> people = Person.ParseCSVFile(@"C:\git\dmu4-csharp\Lek03_DelegatesLINQ\data1.csv");

            Console.WriteLine("Accepted = Age > 15:");
            people.SetAccepted(p => p.Age > 15);
            people.ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.WriteLine("Reset:");
            people.Reset();
            people.ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        public static void Exercise12()
        {
            Random rand = new Random();
            List<int> numbers = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                numbers.Add(rand.Next(100));
            }

            numbers.ForEach(n => Console.Write($"{n}, "));
            Console.WriteLine("\n");

            // a
            int oddNums = (from n in numbers where n % 2 == 0 select n).Count();
            Console.WriteLine($"There are {oddNums} odd numbers in the list.\n");

            // b
            int distinctNums = (from n in numbers select n).Distinct().Count();
            Console.WriteLine($"There are {distinctNums} distinct numbers in the list.\n");

            // c
            Console.WriteLine("First three odd numbers:");
            var threeOdd = (from n in numbers where n % 2 != 0 select n).Take(3);
            threeOdd.ToList().ForEach(n => Console.Write($"{n}, "));
            Console.WriteLine("\n");

            // d
            int distinctOddNums = (from n in numbers where n % 2 != 0 select n).Distinct().Count();
            Console.WriteLine($"There are {distinctOddNums} distinct odd numbers in the list.\n");
        }

        public static void Exercise13()
        {
            List<Person> people = Person.ParseCSVFile(@"C:\git\dmu4-csharp\Lek03_DelegatesLINQ\data1.csv");

            var groups = from p in people let first = p.Name[0] group p by first into GroupFirstChar select GroupFirstChar;
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Key} ({group.Count()})");
            }
        }

        public static void Exercise14()
        {
            List<Person> data1 = Person.ParseCSVFile(@"C:\git\dmu4-csharp\Lek03_DelegatesLINQ\data1.csv");
            List<Person> data2 = Person.ParseCSVFile(@"C:\git\dmu4-csharp\Lek03_DelegatesLINQ\data2.csv");

            Console.WriteLine("The people from data1 whose names also occur in data2:");
            var diff = (from p in data1 select p).Intersect(from p in data2 select p, new PersonNameEquality());
            diff.ToList().ForEach(Console.WriteLine);
        }

        static void Main(string[] args)
        {
            // Ad, ad, ad.
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13();
            Exercise14();

            Console.ReadLine();
        }
    }
}
