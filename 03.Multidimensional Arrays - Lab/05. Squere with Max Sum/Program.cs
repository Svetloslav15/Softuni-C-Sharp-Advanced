using System;
using System.Linq;

namespace _05._Squere_with_Max_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] temp = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = temp[0];
            int cols = temp[1];
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] inputRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = inputRow[j];
                }
            }

            int maxUpLeft = 0;
            int maxUpRight = 0;
            int maxDownLeft = 0;
            int maxDownRight = 0;
            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentUpLeft = matrix[row, col];
                    int currentUpRight = matrix[row, col + 1];
                    int currentDownLeft = matrix[row + 1, col];
                    int currentDownRight = matrix[row + 1, col + 1];
                    int currentSum = currentDownLeft + currentDownRight + currentUpLeft + currentUpRight;

                    if (currentSum > maxSum)
                    {
                        maxDownLeft = currentDownLeft;
                        maxUpLeft = currentUpLeft;
                        maxUpRight = currentUpRight;
                        maxDownRight = currentDownRight;
                        maxSum = currentSum;
                    }
                }
            }
            Console.WriteLine($"{maxUpLeft} {maxUpRight}");
            Console.WriteLine($"{maxDownLeft} {maxDownRight}");
            Console.WriteLine(maxSum);
        }
    }
}
