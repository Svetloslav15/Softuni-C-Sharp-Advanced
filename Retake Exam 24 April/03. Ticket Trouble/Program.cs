using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03._Ticket_Trouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string location = Console.ReadLine();
            string input = Console.ReadLine();
            string pattern = @"\{.+\[(BUL SF)\].+\[([A-Z][0-9]{1,2})\].+\}|\[.+{(BUL SF)\}.+\{(\2)}.+\]";
            List<string> list = new List<string>();
            var matches = Regex.Matches(input, pattern);
            foreach (Match item in matches)
            {
                list.Add(item.Groups[1].Value);
            }
            Console.WriteLine($"You are traveling to {location} on seats {list[0]} and {list[1]}.");
        }
    }
}
