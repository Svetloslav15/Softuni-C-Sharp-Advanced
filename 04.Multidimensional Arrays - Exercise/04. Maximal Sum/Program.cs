using System;
using System.Linq;

namespace _04._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] length = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[,] matrix = new int[length[0], length[1]];
            for (int row = 0; row < length[0]; row++)
            {
                int[] temp = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < length[1]; col++)
                {
                    matrix[row, col] = temp[col];
                }
            }
            int maxSum = 0;
            int[,] maxMatrix = new int[3, 3];
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxMatrix[0, 0] = matrix[row, col];
                        maxMatrix[0, 1] = matrix[row, col + 1];
                        maxMatrix[0, 2] = matrix[row, col + 2];
                        maxMatrix[1, 0] = matrix[row + 1, col];
                        maxMatrix[1, 1] = matrix[row + 1, col + 1];
                        maxMatrix[1, 2] = matrix[row + 1, col + 2];
                        maxMatrix[2, 0] = matrix[row + 2, col];
                        maxMatrix[2, 1] = matrix[row + 2, col + 1];
                        maxMatrix[2, 2] = matrix[row + 2, col + 2];
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < maxMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < maxMatrix.GetLength(1); col++)
                {
                    Console.Write(maxMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
