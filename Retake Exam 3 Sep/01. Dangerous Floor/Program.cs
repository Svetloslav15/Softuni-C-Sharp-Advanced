using System;
using System.Linq;

namespace _01._Dangerous_Floor
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] matrix = new char[8][];
            for (int row = 0; row < 8; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                matrix[row] = new char[8];
                for (int col = 0; col < 8; col++)
                {
                    matrix[row][col] = currentRow[col];
                }
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                char figure = command[0];
                int currentRow = command[1] - 48;
                int currentCol = command[2] - 48;

                int rowToMove = command[4] - 48;
                int colToMove = command[5] - 48;

                if (matrix[currentRow][currentCol] != figure)
                {
                    Console.WriteLine("There is no such a piece!");
                }
                else if (!CanMove(figure, currentRow, currentCol, rowToMove, colToMove))
                {
                    Console.WriteLine("Invalid move!");
                }
                else if (rowToMove >= 8 || colToMove >= 8)
                {
                    Console.WriteLine("Move go out of board!");
                }
                else
                {
                    matrix[currentRow][currentCol] = 'x';
                    matrix[rowToMove][colToMove] = figure;
                }

                command = Console.ReadLine();
            }
        }

        private static bool CanMove(char figure, int currentRow, int currentCol, int rowToMove, int colToMove)
        {
            bool value = true;
            switch (figure)
            {
                case 'P': value = currentRow - 1 == rowToMove && currentCol == colToMove; break;
                case 'K': value = Math.Max(Math.Abs(rowToMove - currentRow), Math.Abs(colToMove - currentCol)) == 1; break;
                case 'R': value = colToMove == currentCol || currentRow == rowToMove; break;
                case 'B': value = Math.Abs(currentRow - rowToMove) == Math.Abs(colToMove - currentCol); break;
                case 'Q':
                    value = (Math.Abs(currentRow - rowToMove) == Math.Abs(colToMove - currentCol)) ||
                  (currentCol == colToMove || currentRow == rowToMove); break;
            }
            return value;
        }
    }
}