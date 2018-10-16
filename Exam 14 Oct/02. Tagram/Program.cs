using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length > 1)
                {
                    string username = tokens[0];
                    string tag = tokens[1];
                    int likes = int.Parse(tokens[2]);
                    if (!dict.ContainsKey(username))
                    {
                        dict[username] = new Dictionary<string, int>();
                    }
                    if (!dict[username].ContainsKey(tag))
                    {
                        dict[username][tag] = 0;
                    }
                    dict[username][tag] += likes;
                }
                else
                {
                    string[] token = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (dict.ContainsKey(token[1]))
                    {
                        dict.Remove(token[1]);
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var kvp in dict.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Count))
            {
                Console.WriteLine(kvp.Key);
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"- {item.Key}: {item.Value}");
                }
            }
        }
    }
}
