using System;

namespace Lek04_Sudoku
{
    class InvalidArgumentException : Exception
    {
        private string message;

        public InvalidArgumentException(string message = "Invalid argument.")
        {
            this.message = message;
        }

        public string GetMessage()
        {
            return message;
        }
    }
}
