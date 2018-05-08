using System;
using System.Linq;

namespace _03._Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new[] { ", " },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] sizes = new int[3];

            foreach (var number in input)
            {
                sizes[Math.Abs(number % 3)]++;
            }
            int[][] jaggedArray = new int[3][];
            for (int couter = 0; couter < sizes.Length; couter++)
            {
                jaggedArray[couter] = new int[sizes[couter]];
            }
            int[] index = new int[3];
            foreach (var number in input)
            {
                int reminder = Math.Abs(number % 3);
                jaggedArray[reminder][index[reminder]] = number;
                index[reminder]++;
            }

            for (int row = 0; row < 3; row++)
            {
                Console.WriteLine(string.Join(" ",jaggedArray[row]));
            }
        }
    }
}
