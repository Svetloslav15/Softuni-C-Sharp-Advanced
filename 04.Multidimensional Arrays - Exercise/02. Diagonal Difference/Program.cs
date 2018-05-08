using System;
using System.Linq;

namespace _02._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[,] matrix = new int[length, length];
            for (int row = 0; row < length; row++)
            {
                int[] temp = Console.ReadLine().Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < length; col++)
                {
                    matrix[row, col] = temp[col];
                }
            }
            int sumPrimary = 0;
            int sumSecondary = 0;
            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < length; col++)
                {
                    if (row == col)
                    {
                        sumPrimary += matrix[row, col];
                    }
                    if (row + col + 1 == length)
                    {
                        sumSecondary += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(sumPrimary - sumSecondary));
        }
    }
}
