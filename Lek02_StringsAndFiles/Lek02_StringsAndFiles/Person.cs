using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lek02_StringsAndFiles
{

    class Person
    {
        public delegate void DPrint();
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

        private string name;
        private int age;
        private double weight;

        public Person(string parametersString)
        {
            try
            {
                string[] parameters = parametersString.Split(';');
                Name = parameters[0].Trim();

                int resAge;
                if (int.TryParse(parameters[1].Trim(), out resAge))
                {
                    Age = resAge;
                }

                double resWeight;
                if (double.TryParse(parameters[2].Trim(), out resWeight))
                {
                    Weight = resWeight;
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("Parameter string has insufficient information.");
            }
        }

        public override string ToString()
        {
            //return $"A person named {name}, aged {age} who weighs {weight}.";
            return $"{name}\t:\t{age} years,\t{weight} kg";
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value.Length > 0 ? value : "UNKNOWN";
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value > 0 ? value : -1;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value > 0 ? value : -1;
            }
        }
    }
}
