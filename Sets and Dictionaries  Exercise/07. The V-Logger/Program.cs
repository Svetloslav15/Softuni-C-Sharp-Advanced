using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, HashSet<string>> following = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> followers = new Dictionary<string, HashSet<string>>();

            while(input != "Statistics")
            {
                string[] tokens = input.Split(' ');
                string first = tokens[0];
                string second = tokens[2];
                if (input.Contains("joined"))
                {
                    if (!followers.ContainsKey(first))
                    {
                        following[first] = new HashSet<string>();
                        followers[first] = new HashSet<string>();
                    }
                }
                else
                {
                    if (first != second)
                    {
                        if (!following.ContainsKey(first))
                        {
                            following[first] = new HashSet<string>();
                        }
                        else if(followers.ContainsKey(second))
                        {
                            followers[second].Add(first);
                            following[first].Add(second);
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {followers.Count} vloggers in its logs.");
            followers = followers
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => following[x.Key].Count)
                .ToDictionary(x => x.Key, y => y.Value);
            int count = 1;
            foreach (var kvp in followers)
            {
                Console.WriteLine($"{count}. {kvp.Key} : {followers[kvp.Key].Count} followers, {following[kvp.Key].Count} following");
                if (count == 1 && followers[kvp.Key].Count > 0)
                {
                    foreach (var item in followers[kvp.Key].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }
                count++;
            }
        }
    }
}