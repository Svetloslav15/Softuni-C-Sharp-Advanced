using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "add")
                {
                    nums = nums.Select(x => x + 1).ToList();
                }
                else if (command == "subtract")
                {
                    nums = nums.Select(x => x - 1).ToList();
                }
                else if (command == "multiply")
                {
                    nums = nums.Select(x => 2 * x).ToList();
                }
                else if (command == "print")
                {
                    nums.ForEach(x => Console.Write(x + " "));
                    Console.WriteLine();
                }
                command = Console.ReadLine();
            }
        }
    }
}
