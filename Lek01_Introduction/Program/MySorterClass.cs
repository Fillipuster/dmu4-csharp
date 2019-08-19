using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lek01_Introduction
{
    class MySorterClass
    {
        private List<int> numbers = new List<int>();

        public MySorterClass()
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                numbers.Add(rand.Next(10));
            }
        }

        public void Sort()
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 1; i < numbers.Count; i++)
                    if (numbers[i - 1] > numbers[i])
                    {
                        swap(i - 1, i);
                        swapped = true;
                    }
            }
        }

        private void swap(int a, int b)
        {
            int tmp = numbers[a];
            numbers[a] = numbers[b];
            numbers[b] = tmp;
        }

        public override string ToString()
        {
            return "{" + String.Join(", ", numbers) + "}";
        }
    }
}
