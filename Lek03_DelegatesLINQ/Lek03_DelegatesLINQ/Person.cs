using System.Collections.Generic;
using System.IO;

namespace Lek03_DelegatesLINQ
{
    class Person
    {
        public class SortScore : IComparer<Person>
        {
            private bool desc;
            public SortScore(bool desc)
            {
                this.desc = desc;
            }

            public int Compare(Person x, Person y)
            {
                return desc ? y.Score.CompareTo(x.Score) : x.Score.CompareTo(y.Score);
            }
        }

        public class SortAge : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.Age.CompareTo(y.Age);
            }
        }

        public static List<Person> ParseCSVFile(string filename)
        {
            List<Person> result = new List<Person>();
            using (var file = new StreamReader(filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    result.Add(new Person(line));
                }
            }

            return result;
        }

        public string Name = "UNKNOWN";
        public int Age = -1;
        public int Weight = -1;
        public int Score = -1;
        public bool Accepted = false;

        public Person(string argsString)
        {
            string[] args = argsString.Split(';');

            string name = args[0].Trim();
            if (name.Length > 0) Name = name;

            int.TryParse(args[1], out Age);
            int.TryParse(args[2], out Weight);
            int.TryParse(args[3], out Score);
        }

        public override string ToString()
        {
            return string.Format("{0,-15} : {1,10} years {2,10} kg {3,10} points {4,10} acceptance", Name, Age, Weight, Score, Accepted);
        }

        // Doesn't do the trick when using Intersect (LINQ)
        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                Person p = (Person)obj;
                return string.Equals(p.Name, Name);
            }

            return false;
        }
    }
}
