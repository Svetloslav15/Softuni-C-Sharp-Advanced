using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Ticket_Trouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string location = Console.ReadLine();
            string input = Console.ReadLine();
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            int ticketsCount = 0;
            string pattern = @"{[^]]*\[(?<country>[A-Z]{3}\s[A-Z]{2})\][^[]*\[(?<seat>[A-Z][0-9]{1,2})\][^[]*}|\[[^}]*\{(?<country1>[A-Z]{3}\s[A-Z]{2})\}[^}]*\{(?<seat1>[A-Z][0-9]{1,2})\}[^{]*\]";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                string seat = "";
                int row = 0;
                bool find = false;
                if (match.Groups["country"].Value != "" && match.Groups["country"].Value == location)
                {
                    seat = match.Groups["seat"].Value;
                    row = int.Parse(seat.Substring(1));
                    find = true;
                }
                else if (match.Groups["country1"].Value != "" && match.Groups["country1"].Value == location)
                {
                    seat = match.Groups["seat1"].Value;
                    row = int.Parse(seat.Substring(1));
                    find = true;
                }
                if (find)
                {
                    if (!dict.ContainsKey(row))
                    {
                        dict[row] = new List<string>();
                    }
                    dict[row].Add(seat);
                    ticketsCount++;
                }
            }
            if (ticketsCount > 2)
            {
                var list = dict.Where(x => x.Value.Count == 2).ToList();
                Console.WriteLine($"You are traveling to {location} on seats {list[0].Value[0]} and {list[0].Value[1]}.");
            }
            else
            {
                List<string> list = new List<string>();
                foreach (var item in dict)
                {
                    foreach (var seat in item.Value)
                    {
                        list.Add(seat);
                    }
                }
                Console.WriteLine($"You are traveling to {location} on seats {list[0]} and {list[1]}.");
            }
        }
    }
}