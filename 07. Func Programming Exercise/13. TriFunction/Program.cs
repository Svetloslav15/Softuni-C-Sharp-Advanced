using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<string> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Func<char[], int, bool> checkFunc = (a, b) => (a.Select(x=> (int)x).Sum() >= b);
            Console.WriteLine(list.FirstOrDefault(x => checkFunc(x.ToCharArray(), length)));
        }
    }
}