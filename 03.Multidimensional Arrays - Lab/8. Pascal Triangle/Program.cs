using System;

namespace _8._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            long[][] triangle = new long[size][];
            for (int row = 0; row < size; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[row][0] = 1;
                triangle[row][row] = 1;
                if (row >= 2)
                {
                    for (int index = 1; index < row; index++)
                    {
                        long a = triangle[row - 1][index - 1];
                        long b = triangle[row - 1][index];
                        triangle[row][index] = a + b;
                    }
                }
            }
            foreach (var item in triangle)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
