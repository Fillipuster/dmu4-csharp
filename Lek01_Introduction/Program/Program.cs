using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TooDeepLib;

namespace Lek01_Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Helle World!");
            MyClass c = new MyClass(7);
            Console.WriteLine(c);
            try
            {
                c.id = -5;
            } catch (Exception e)
            {
                Console.WriteLine($"Caught exception: {e.Message}");
            } finally
            {
                Console.WriteLine("Nothing to clean up from try block.");
            }
            c.id = 2;
            Console.WriteLine(c);
            MyExternalClassEx cx = new MyExternalClassEx();
            Console.WriteLine(cx);
            Console.WriteLine();
            MySorterClass sorter = new MySorterClass();
            Console.WriteLine("Created sorter with numbers: " + sorter);
            sorter.Sort();
            Console.WriteLine("Sorted with result: " + sorter);
            Console.ReadLine();
        }
    }

    class MyClass
    {
        private int _id;

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Identifier cannot be negative.");
                } else
                {
                    this._id = value;
                }
            }
        }

        public MyClass(int id = 0)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return $"MyClass with id: {this.id}";
        }
    }

    class MyExternalClassEx : MyExternalClass
    {
        public override string ToString()
        {
            return base.GetMeAsText() + "Ex";
        }
    }
}
