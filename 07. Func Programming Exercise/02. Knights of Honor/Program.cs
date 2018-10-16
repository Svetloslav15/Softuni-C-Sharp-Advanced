using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(x => $"Sir {x}")
                 .ToList()
                 .ForEach(x => Console.WriteLine(x));
        }
    }
}
