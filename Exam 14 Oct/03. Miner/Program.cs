using System;

namespace _03._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[][] matrix = new char[sizes][];
            for (int row = 0; row < sizes; row++)
            {
                matrix[row] = new char[sizes];
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row][col] = currentRow[col][0];
                }
            }
            foreach (var command in commands)
            {
                MoveMiner(matrix, command);
            }
            CheckCoals(matrix);
        }

        private static void CheckCoals(char[][] matrix)
        {
            int coalsLeft = 0;
            int minerRow = 0;
            int minerCol = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 'c')
                    {
                        coalsLeft++;
                    }
                    else if (matrix[row][col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                }
            }
            if (coalsLeft == 0)
            {
                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
            }
            else
            {
                Console.WriteLine($"{coalsLeft} coals left. ({minerRow}, {minerCol})");
            }
        }

        private static void MoveMiner(char[][] matrix, string command)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    char currentSymbol = matrix[row][col];
                    if (currentSymbol == 's')
                    {
                        int currentRow = row;
                        int currentCol = col;
                        if (command == "up" && row - 1 >= 0)
                        {
                            currentRow--;
                        }
                        else if (command == "down" && row + 1 < matrix.Length)
                        {
                            currentRow++;
                        }
                        else if (command == "left" && col - 1 >= 0)
                        {
                            currentCol--;
                        }
                        else if (command == "right" && col + 1 < matrix.Length)
                        {
                            currentCol++;
                        }
                        if (matrix[currentRow][currentCol] == 'e')
                        {
                            GameOver(currentRow, currentCol);
                        }
                        matrix[row][col] = '*';
                        matrix[currentRow][currentCol] = 's';
                        return;
                    }
                }
            }
        }

        private static void GameOver(int row, int col)
        {
            Console.WriteLine($"Game over! ({row}, {col})");
            Environment.Exit(0);
        }
    }
}