using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            string commandsText = Console.ReadLine();

            bool win = false;
            int[] playerCordinates = new int[2] { -1, -1 };
            foreach (var item in commandsText)
            {
                if (playerCordinates[0] == -1)
                {
                    FindPlayerCordinates(matrix, playerCordinates);
                }
                MovePlayer(item, playerCordinates, matrix);
            }
        }
        static void FindPlayerCordinates(char[,] matrix, int[] cords)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        cords[0] = row;
                        cords[1] = col;
                        return;
                    }
                }
            }
        }
        static void ValidateNextMove(char[,] matrix, int row, int col)
        {
            if (matrix[row, col] == '.')
            {
                matrix[row, col] = 'P';
            }
            FindBunnies(matrix);
            if (matrix[row, col] == 'B')
            {
                GameOver(matrix, row, col, "dead");
            }
        }
        static void FindBunnies(char[,] matrix)
        {
            char[,] copy = new char[matrix.GetLength(0), matrix.GetLength(1)];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char value = matrix[row, col];
                    copy[row, col] = value;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char value = copy[row, col];
                    if (value == 'B')
                    {
                        if (row - 1 >= 0)
                        {
                            matrix[row - 1, col] = 'B';
                        }
                        if (row + 1 < matrix.GetLength(0))
                        {
                            matrix[row + 1, col] = 'B';
                        }
                        if (col - 1 >= 0)
                        {
                            matrix[row, col - 1] = 'B';
                        }
                        if (col + 1 < matrix.GetLength(1))
                        {
                            matrix[row, col + 1] = 'B';
                        }
                    }
                }
            }
        }
        static void MovePlayer(char command, int[] cords, char[,] matrix)
        {
            int row = cords[0];
            int col = cords[1];
            matrix[row, col] = '.';
            if (command == 'U' && row - 1 >= 0)
            {
                ValidateNextMove(matrix, row - 1, col);
            }
            if (command == 'D' && row + 1 < matrix.GetLength(0))
            {
                ValidateNextMove(matrix, row + 1, col);
            }
            if (command == 'L' && col - 1 >= 0)
            {
                ValidateNextMove(matrix, row, col - 1);
            }
            if (command == 'R' && col + 1 >= 0)
            {
                matrix[row, col + 1] = 'P';
                ValidateNextMove(matrix, row, col + 1);
            }
            else
            {
                FindBunnies(matrix);
                GameOver(matrix, row, col, "won");
                return;
            }
        }
        static void GameOver(char[,] matrix, int row, int col, string text)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"{text}: {row} {col}");
            Environment.Exit(0);
        }
    }
}