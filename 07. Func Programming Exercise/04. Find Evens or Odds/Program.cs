using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int min = sizes[0];
            int max = sizes[1];
            var nums = new List<int>();
            for (int i = min; i <= max; i++)
            {
                nums.Add(i);
            }
            string command = Console.ReadLine();
            if (command == "odd")
            {
                nums = nums.Where(x => x % 2 != 0).ToList();
            }
            else
            {
                nums = nums.Where(x => x % 2 == 0).ToList();
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}