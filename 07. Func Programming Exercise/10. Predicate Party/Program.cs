using System;
using System.Linq;

namespace _10._Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            while (command != "Party!")
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "remove")
                {
                    if (tokens[1] == "StartsWith")
                    {

                    }
                    else if (tokens[1] == "EndsWith")
                    {

                    }
                } 
                command = Console.ReadLine();
            }
        }
    }
}
