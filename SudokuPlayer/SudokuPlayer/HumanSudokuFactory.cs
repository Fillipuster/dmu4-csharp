using SudokuLib;

namespace SudokuPlayer
{
    static class HumanSudokuFactory
    {
        public static ISudoku FromString(string str)
        {
            return SudokuFactory.CreateSudoku(str.Replace('.', '0'));
        }

        public static ISudoku[] FromArray(string[] strArr)
        {
            ISudoku[] result = new ISudoku[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                result[i] = FromString(strArr[i]);
            }

            return result;
        }
    }
}
