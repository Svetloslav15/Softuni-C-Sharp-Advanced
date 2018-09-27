using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> dict = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];
                if (!dict.ContainsKey(continent))
                {
                    dict[continent] = new Dictionary<string, List<string>>();
                }
                if (!dict[continent].ContainsKey(country))
                {
                    dict[continent][country] = new List<string>();
                }
                dict[continent][country].Add(city);
            }
            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + ":");
                foreach (var country in dict[item.Key])
                {
                    Console.WriteLine($"    {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
