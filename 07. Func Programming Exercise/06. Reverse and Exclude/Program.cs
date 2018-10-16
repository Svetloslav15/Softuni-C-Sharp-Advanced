using System;
using System.Linq;

namespace _06._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(" ", nums.Where(x => x % num != 0).Reverse()));
        }
    }
}