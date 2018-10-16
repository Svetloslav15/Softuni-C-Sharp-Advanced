using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x += 0.2 * x)
                .ToList()
                .ForEach(x => Console.WriteLine("{0:f2}", x));
        }
    }
}