using System;
using System.Linq;

namespace _07._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            var list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            list.Where(x => x.Length <= length)
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}