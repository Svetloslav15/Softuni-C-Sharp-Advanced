using System;
using System.Linq;

namespace Live_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];
            for (int rows = 0; rows < rowsAndColumns[0]; rows++)
            {
                int[] rowValues = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
                for (int columns = 0; columns < rowsAndColumns[1]; columns++)
                {
                    matrix[rows, columns] = rowValues[columns];
                }
            }

            int maxUpLeft = 0;
            int maxUpRight = 0;
            int maxDownLeft = 0;
            int maxDownRight = 0;
            int maxSum = int.MinValue;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {

                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    int currentUpLeft = matrix[rows, cols];
                    int currentUpRight = matrix[rows, cols + 1];
                    int currentDownLeft = matrix[rows + 1, cols];
                    int currentDownRight = matrix[rows + 1, cols + 1];
                    int currentSum = currentUpLeft + currentUpRight + currentDownLeft + currentDownRight;

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxDownLeft = currentDownLeft;
                        maxDownRight = currentDownRight;
                        maxUpLeft = currentUpLeft;
                        maxUpRight = currentUpRight;
                    }
                }
            }

            Console.WriteLine($"{maxUpLeft} {maxUpRight}");
            Console.WriteLine($"{maxDownLeft} {maxDownRight}");
            Console.WriteLine(maxSum);
        }
    }
}
