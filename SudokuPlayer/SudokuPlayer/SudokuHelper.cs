using SudokuLib;

namespace SudokuPlayer
{
    static class SudokuHelper
    {
        public static ISudoku FromHumanString(string str)
        {
            return SudokuFactory.CreateSudoku(str.Replace('.', '0'));
        }

        public static ISudoku[] FromHumanStringArray(string[] strArr)
        {
            ISudoku[] result = new ISudoku[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                result[i] = FromHumanString(strArr[i]);
            }

            return result;
        }
    }
}
