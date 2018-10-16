using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(" -> ");
                if (!dict.ContainsKey(tokens[0]))
                {
                    dict[tokens[0]] = new Dictionary<string, int>();
                }
                string[] products = tokens[1].Split(",");
                foreach (var product in products)
                {
                    if (!dict[tokens[0]].ContainsKey(product))
                    {
                        dict[tokens[0]][product] = 0;
                    }
                    dict[tokens[0]][product]++;
                }
            }
            string[] found = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (var item in dict[kvp.Key])
                {
                    if (item.Key == found[1] && kvp.Key == found[0])
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
