using System;

namespace Lek04_Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Sudoku!");

            Sudoku s = new Sudoku("083020000041003825702000000020085036050301080430290050000000308896100540000040160");

            Console.WriteLine(s);

            Console.ReadLine();
        }
    }
}
