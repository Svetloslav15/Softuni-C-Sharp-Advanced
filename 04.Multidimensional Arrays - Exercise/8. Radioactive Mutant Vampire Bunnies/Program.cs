using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            char[][] matrix = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                string currentRow = Console.ReadLine();
                matrix[i] = new char[cols];
                for (int col = 0; col < cols; col++)
                {
                    matrix[i][col] = currentRow[col];
                }
            }
            string commands = Console.ReadLine();
            for (int index = 0; index < commands.Length; index++)
            {
                char currentCommand = commands[index];
                Move(matrix, currentCommand);            
            }
        }
        private static int[] FindPlayerCordinates(char[][] matrix)
        {
            int[] sizes = new int[2];
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        sizes[0] = row;
                        sizes[1] = col;
                        return sizes;
                    }
                }
            }
            return sizes;
        }
        private static string CheckWin(char[][] matrix, int playerRow, int playerCol, char command)
        {
            if (command == 'U')
            {
                matrix[playerRow + 1][playerCol] = '.';
            }
            else if (command == 'D')
            {
                matrix[playerRow - 1][playerCol] = '.';
            }
            else if (command == 'L')
            {
                matrix[playerRow][playerCol + 1] = '.';
            }
            else if (command == 'R')
            {
                matrix[playerRow][playerCol - 1] = '.';
            }
            if (playerRow < 0 || playerRow >= matrix.Length || playerCol < 0 || playerCol >= matrix[0].Length)
            {
                return "win";
            }
            if (matrix[playerRow][playerCol] == 'B')
            {
                return "die";
            }
            matrix[playerRow][playerCol] = 'P';
            return "continue";
        }
        private static void Move(char[][] matrix, char currentCommand)
        {
            int[] sizes = FindPlayerCordinates(matrix);
            int playerRow = sizes[0];
            int playerCol = sizes[1];
            
            if (currentCommand == 'U')
            {
                playerRow--;
            }
            else if (currentCommand == 'D')
            {
                playerRow++;
            }
            else if (currentCommand == 'L')
            {
                playerCol--;
            }
            else if (currentCommand == 'R')
            {
                playerCol++;
            }
            string winOrDie = CheckWin(matrix, playerRow, playerCol, currentCommand);
            List<string> bunniesCordinates = new List<string>();
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        bunniesCordinates.Add($"{row} {col}");
                    }
                }
            }
            foreach (var item in bunniesCordinates)
            {
                int[] cords = item.Split(' ').Select(int.Parse).ToArray();
                int row = cords[0];
                int col = cords[1];
                if (row + 1 < matrix.Length)
                {
                    matrix[row + 1][col] = 'B';
                }
                if (row - 1 >= 0)
                {
                    matrix[row - 1][col] = 'B';
                }
                if (col - 1 >= 0)
                {
                    matrix[row][col - 1] = 'B';
                }
                if (col + 1 < matrix[0].Length)
                {
                    matrix[row][col + 1] = 'B';
                }
            }
            if (winOrDie == "win")
            {
                if (playerCol < 0)
                {
                    playerCol = 0;
                }
                if (playerCol >= matrix[0].Length)
                {
                    playerCol = matrix[0].Length - 1;
                }
                if (playerRow < 0)
                {
                    playerRow = 0;
                }
                if (playerRow >= matrix[0].Length)
                {
                    playerRow = matrix.Length - 1;
                }
                Console.WriteLine($"win: {playerRow} {playerCol}");
                Environment.Exit(0);
            }
            else if (winOrDie == "die")
            {
                if (playerCol < 0)
                {
                    playerCol = 0;
                }
                if (playerCol >= matrix[0].Length)
                {
                    playerCol = matrix[0].Length - 1;
                }
                if (playerRow < 0)
                {
                    playerRow = 0;
                }
                if (playerRow >= matrix[0].Length)
                {
                    playerRow = matrix.Length - 1;
                }
                Console.WriteLine($"die: {playerRow} {playerCol}");
                Environment.Exit(0);
            }
        }
    }
}