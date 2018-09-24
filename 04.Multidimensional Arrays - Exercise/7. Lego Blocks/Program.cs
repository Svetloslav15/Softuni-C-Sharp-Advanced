using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] firstJagged = new int[rows][];
            int[][] secondJagged = new int[rows][];
            int cellsNumber = 0;

            for (int row = 0; row < rows; row++)
            {
                firstJagged[row] = Console.ReadLine()
                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToArray();
                cellsNumber += firstJagged[row].Length;
            }
            for (int row = 0; row < rows; row++)
            {
                secondJagged[row] = Console.ReadLine()
                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .Reverse()
                       .ToArray();
                cellsNumber += secondJagged[row].Length;
            }

            int sizeFirst = firstJagged[0].Length + secondJagged[0].Length;
            for (int row = 1; row < rows; row++)
            {
                int currentLength = firstJagged[row].Length + secondJagged[row].Length;
                if (currentLength != sizeFirst)
                {
                    Console.WriteLine($"The total number of cells is: {cellsNumber}");
                    return;
                }
            }
            
            for (int row = 0; row < rows; row++)
            {
                int[] currentResultRow = new int[firstJagged[0].Length + secondJagged[0].Length];
                currentResultRow = firstJagged[row].Concat(secondJagged[row]).ToArray();
                Console.WriteLine($"[{string.Join(", ", currentResultRow)}]");
            }
        }
    }
}
