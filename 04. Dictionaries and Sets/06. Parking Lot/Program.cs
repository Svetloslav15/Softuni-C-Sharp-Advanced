using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> set = new HashSet<string>();

            while(input != "END")
            {
                string[] tokens =input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "IN")
                {
                    set.Add(tokens[1]);
                }
                else if (tokens[0] == "OUT")
                {
                    set.Remove(tokens[1]);
                }
                input = Console.ReadLine();
            }
            if (set.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }
            Console.WriteLine(string.Join(Environment.NewLine, set));
        }
    }
}