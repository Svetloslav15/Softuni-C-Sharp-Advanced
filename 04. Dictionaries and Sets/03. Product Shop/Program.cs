using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, double>> dict = new Dictionary<string, Dictionary<string, double>>();
            while (input != "Revision")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);
                if (!dict.ContainsKey(shop))
                {
                    dict[shop] = new Dictionary<string, double>();
                }
                dict[shop][product] = price;
                
                input = Console.ReadLine();
            }
            foreach (var item in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key + "->");
                foreach (var kvp in dict[item.Key])
                {
                    Console.WriteLine($"Product: {kvp.Key}, Price: {kvp.Value}");
                }
            }
        }
    }
}
