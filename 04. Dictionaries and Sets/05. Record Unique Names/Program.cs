using System;
using System.Collections.Generic;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                set.Add(input);
            }
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
