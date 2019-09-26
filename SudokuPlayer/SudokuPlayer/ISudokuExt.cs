using SudokuLib;

namespace SudokuPlayer
{
    static class ISudokuExt
    {
        public static string ToHumanString(this ISudoku sudoku)
        {
            return sudoku.ToString().Replace('0', '.'); // ☐
        }
    }
}
