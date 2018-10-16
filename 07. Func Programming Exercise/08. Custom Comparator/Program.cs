using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            nums.Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToList()
                .ForEach(x => Console.Write(x + " "));
            nums.Where(x => x % 2 != 0)
               .OrderBy(x => x)
               .ToList()
               .ForEach(x => Console.Write(x + " "));
        }
    }
}