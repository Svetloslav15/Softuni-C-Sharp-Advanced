using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int cols = 0; cols < row.Length; cols++)
                {
                    matrix[rows, cols] = row[cols];
                }
            }
            int sum = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                sum += matrix[col, col];
            }
            Console.WriteLine(sum);
        }
    }
}
