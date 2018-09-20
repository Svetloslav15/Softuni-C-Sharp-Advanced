using System;
using System.Linq;

namespace _05._Rubics_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] temp = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = temp[0];
            int cols = temp[1];
            int numberOfCommands = int.Parse(Console.ReadLine());
            int[, ] matrix = new int[rows, cols];
            int counter = 1;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = counter++;
                }
            }
            for (int index = 0; index < numberOfCommands; index++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                string command = input[1];
                int column = int.Parse(input[0]);
                int moves = int.Parse(input[2]);

                if (command == "up")
                {
                    MoveUp(matrix, column, moves);
                }
                else if (command == "down")
                {
                    MoveDown(matrix, column, moves);
                }
                else if (command == "left")
                {
                    MoveLeft(matrix, column, moves);
                }
                else if (command == "right")
                {
                    MoveRight(matrix, column, moves);
                }
            }
        }

        static void MoveUp(int[,] matrix, int col, int moves)
        {

        }

        private static void MoveDown(int[,] matrix, int col, int moves)
        {
            
        }

        private static void MoveLeft(int[,] matrix, int row, int moves)
        {
            
        }

        private static void MoveRight(int[,] matrix, int row, int moves)
        {
            
        }
    }
}
