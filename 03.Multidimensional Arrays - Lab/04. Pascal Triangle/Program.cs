using System;

namespace _04._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long height = long.Parse(Console.ReadLine());
            long current = 1;
            long[][] triangle = new long[height][];

            for (long currentHeight = 0; currentHeight < height; currentHeight++)
            {
                triangle[currentHeight] = new long[current];
                triangle[currentHeight][0] = 1;
                triangle[currentHeight][current - 1] = 1;
                if (current > 2)
                {
                    for (long widthCount = 1; widthCount < current - 1; widthCount++)
                    {
                        triangle[currentHeight][widthCount] = triangle[currentHeight - 1][widthCount - 1] + 
                            triangle[currentHeight - 1][widthCount];
                    }
                }
                current++;
            }
            for (long i = 0; i < height; i++)
            {
                Console.WriteLine(string.Join(" ",triangle[i]));
            }
        }
    }
}
