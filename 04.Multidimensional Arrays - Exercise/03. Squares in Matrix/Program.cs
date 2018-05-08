using System;
using System.Linq;

namespace _03._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] length = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            char[,] matrix = new char[length[0], length[1]];
            for (int row = 0; row < length[0]; row++)
            {
                char[] temp = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < length[1]; col++)
                {
                    matrix[row, col] = temp[col];
                }
            }
            int squareMatrixesCount = 0;
            for (int row = 0; row < length[0] - 1; row++)
            {
                for (int col = 0; col < length[1] - 1; col++)
                {
                   if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row + 1, col] == matrix[row, col] &&
                        matrix[row + 1, col + 1] == matrix[row, col])
                    {
                        squareMatrixesCount++;
                    }
                }
            }
            Console.WriteLine(squareMatrixesCount);
        }
    }
}
