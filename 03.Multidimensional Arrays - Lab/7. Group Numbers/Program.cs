using System;
using System.Linq;

namespace _7._Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[][] jagged = new int[3][];
            int[] sizes = new int[3];
            foreach (var item in nums)
            {
                sizes[Math.Abs(item % 3)]++;
            }
            int[] indexes = new int[3];
            for (int row = 0; row < sizes.Length; row++)
            {
                jagged[row] = new int[sizes[row]];
            }
            foreach (var item in nums)
            {
                int reminder = Math.Abs(item % 3);
                jagged[reminder][indexes[reminder]] = item;
                indexes[reminder]++;
            }

            foreach (var item in jagged)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}