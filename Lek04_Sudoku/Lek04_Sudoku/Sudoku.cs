namespace Lek04_Sudoku
{
    class Sudoku
    {
        private byte[] data = new byte[81];

        public Sudoku(string layout)
        {
            if (layout.Length > 81)
                throw new InvalidArgumentException("Array length cannot exceed 81.");

            for (int i = 0; i < 81; i++)
            {
                data[i] = (byte)layout[i];
            }
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < 81; i++)
            {
                if (i % 3 == 0)
                    res += "|";

                if (i % 9 == 0)
                    res += "\n";

                if (i % 27 == 0)
                    res += "---------------------\n";

                char c = (char)data[i];
                if (c == '0') c = '~';

                res += c;
                res += ' ';
            }

            return res.Substring(1) + "|\n---------------------";
        }
    }
}
