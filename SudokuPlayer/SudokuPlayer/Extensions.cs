using SudokuLib;
using System;
using System.Windows.Controls;

namespace SudokuPlayer
{
    static class Extensions
    {
        public static string ToHumanString(this ISudoku sudoku)
        {
            return sudoku.ToString().Replace('0', '.'); // ☐
        }

        public static Tuple<int, int> GetCoordinate(this Label cell)
        {
            return (Tuple<int, int>)cell.Tag;
        }

        public static int GetRow(this Label cell)
        {
            return cell.GetCoordinate().Item1;
        }

        public static int GetColumn(this Label cell)
        {
            return cell.GetCoordinate().Item2;
        }
    }
}
