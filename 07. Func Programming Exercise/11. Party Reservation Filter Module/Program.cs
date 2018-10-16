using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> inputCopy = new List<string>();
            foreach (var item in input)
            {
                inputCopy.Add(item);
            }
            string command = Console.ReadLine();
            Func<List<string>, string, List<string>> startsWith = (x, y) => x.FindAll(i => i.StartsWith(y));
            Func<List<string>, string, List<string>> endsWith = (x, y) => x.FindAll(i => i.EndsWith(y));
            Func<List<string>, string, List<string>> contains = (x, y) => x.FindAll(i => i.Contains(y));
            Func<List<string>, int, List<string>> length = (x, y) => x.FindAll(i => i.Length == y);
            while (command != "Print")
            {
                string[] tokens = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string filter = tokens[0];
                string filterType = tokens[1];

                List<string> list = new List<string>();
                if (filterType == "Starts with")
                {
                    list = startsWith(inputCopy, tokens[2]);
                }
                else if (filterType == "Ends with")
                {
                    list = endsWith(inputCopy, tokens[2]);
                }
                else if (filterType == "Contains")
                {
                    list = contains(inputCopy, tokens[2]);
                }
                else if (filterType == "Length")
                {
                    list = length(inputCopy, int.Parse(tokens[2]));
                }
                if (filter == "Add filter")
                {
                    foreach (var item in list)
                    {
                        if (input.Contains(item))
                        {
                            input.Remove(item);
                        }
                    }
                }
                else
                {
                    foreach (var item in list)
                    {
                        input.Add(item);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
