using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._SoftUni_Party
{
    class Program
    {
        public static object SortedSET { get; private set; }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> regular = new HashSet<string>();
            HashSet<string> vips = new HashSet<string>();

            while(input != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vips.Add(input);
                }
                else
                {
                    regular.Add(input);
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while(input != "END")
            {
                regular.Remove(input);
                vips.Remove(input);
                input = Console.ReadLine();
            }
            Console.WriteLine(vips.Count + regular.Count);
            foreach (var item in vips)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}
