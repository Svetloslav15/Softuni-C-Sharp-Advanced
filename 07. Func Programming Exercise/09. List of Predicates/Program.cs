using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var nums = new List<int>();
            for (int i = 1; i <= num; i++)
            {
                nums.Add(i);
            }
            foreach (var item in dividers)
            {
                nums = nums.Where(x => x % item == 0).ToList();
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}