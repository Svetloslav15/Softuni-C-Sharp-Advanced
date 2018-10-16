using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Rankling
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var contestAndPass = new Dictionary<string, string>();
            var dict = new Dictionary<string, Dictionary<string, int>>();
            while(input != "end of contests")
            {
                string[] tokens = input.Split(":");
                contestAndPass[tokens[0]] = tokens[1];
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] tokens = input.Split("=>");
                string contest = tokens[0];
                string password = tokens[1];
                string participent = tokens[2];
                int points = int.Parse(tokens[3]);
                if (contestAndPass.ContainsKey(contest))
                {
                    if (contestAndPass[contest] == password)
                    {
                        if (!dict.ContainsKey(participent))
                        {
                            dict[participent] = new Dictionary<string, int>();
                        }
                        if (!dict[participent].ContainsKey(contest))
                        {
                            dict[participent][contest] = points;
                        }
                        else if (dict[participent][contest] < points)
                        {
                            dict[participent][contest] = points;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            var best = dict.OrderByDescending(x => x.Value.Values.Sum()).Take(1);
            foreach (var item in best)
            {
                Console.WriteLine($"Best candidate is {item.Key} with total {item.Value.Values.Sum()} points.");
                break;
            }
            Console.WriteLine("Ranking:");
            foreach (var kvp in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (var item in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}