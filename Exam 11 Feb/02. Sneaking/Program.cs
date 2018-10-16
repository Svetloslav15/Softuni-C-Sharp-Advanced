using System;

namespace _02._Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());
            char[][] matrix = new char[sizes][];
            for (int i = 0; i < sizes; i++)
            {
                string currentRow = Console.ReadLine();
                matrix[i] = new char[currentRow.Length];
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[i][col] = currentRow[col];
                }
            }
            string commands = Console.ReadLine();
            foreach (char symbol in commands)
            {
                MoveEnemies(matrix);
                MoveSam(matrix, symbol);
            }
        }
        private static void MoveSam(char[][] matrix, char direction)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 'S' && direction != 'W')
                    {
                        int currentRow = row;
                        if (direction == 'U')
                        {
                            matrix[row - 1][col] = 'S';
                            currentRow--;
                        }
                        else if (direction == 'D')
                        {
                            matrix[row + 1][col] = 'S';
                            currentRow++;
                        }
                        else if (direction == 'R')
                        {
                            matrix[row][col + 1] = 'S';
                        }
                        else if (direction == 'L')
                        {
                            matrix[row][col - 1] = 'S';
                        }
                        matrix[row][col] = '.';
                        CheckIfNikoladzeIsKilled(matrix, currentRow);
                        return;
                    }
                }
            }
        }
        private static void CheckIfNikoladzeIsKilled(char[][] matrix, int row)
        {
            bool containsNikoladze = ConvertFromCharArrToString(matrix[row]).Contains("N");
            if (containsNikoladze)
            {
                int index = ConvertFromCharArrToString(matrix[row]).IndexOf("N");
                matrix[row][index] = 'X';
                Console.WriteLine("Nikoladze killed!");
                PrintMatrix(matrix);
            }
        }
        private static void MoveEnemies(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    char currentSymbol = matrix[row][col];
                    if (currentSymbol == 'd')
                    {
                        if (col > 0)
                        {
                            matrix[row][col - 1] = 'd';
                            matrix[row][col] = '.';
                            if (ConvertFromCharArrToString(matrix[row]).Substring(0, col).Contains("S"))
                            {
                                int samCol = ConvertFromCharArrToString(matrix[row]).IndexOf("S");
                                SamDied(matrix, row, samCol);
                                PrintMatrix(matrix);
                            }
                        }
                        else
                        {
                            matrix[row][col] = 'b';
                            if (ConvertFromCharArrToString(matrix[row]).Substring(col).Contains("S"))
                            {
                                int samCol = ConvertFromCharArrToString(matrix[row]).IndexOf("S");
                                SamDied(matrix, row, samCol);
                                PrintMatrix(matrix);
                            }
                        }
                       
                    }
                    else if (currentSymbol == 'b')
                    {
                        
                        if (col < matrix[row].Length - 1)
                        {
                            matrix[row][col + 1] = 'b';
                            matrix[row][col] = '.';
                            col++;
                            if (ConvertFromCharArrToString(matrix[row]).Substring(col).Contains("S"))
                            {
                                int samCol = ConvertFromCharArrToString(matrix[row]).IndexOf("S");
                                SamDied(matrix, row, samCol);
                                PrintMatrix(matrix);
                            }
                        }
                        else
                        {
                            matrix[row][col] = 'd';
                            if (ConvertFromCharArrToString(matrix[row]).Substring(0, col).Contains("S"))
                            {
                                int samCol = ConvertFromCharArrToString(matrix[row]).IndexOf("S");
                                SamDied(matrix, row, samCol);
                                PrintMatrix(matrix);
                            }
                        }
                    }
                }
            }
        }
        private static void SamDied(char[][] matrix, int row, int col)
        {
            matrix[row][col] = 'X';
            Console.WriteLine($"Sam died at {row}, {col}");
        }
        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join("", item));
            }
            Environment.Exit(0);
        }
        private static string ConvertFromCharArrToString(char[] arr)
        {
            string result = "";
            foreach (var item in arr)
            {
                result += item;
            }
            return result;
        }
    }
}
