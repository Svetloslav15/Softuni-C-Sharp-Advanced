using System;
using System.Text.RegularExpressions;

namespace _04._Treasure_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"![^!#]*(?<name>[a-zA-Z]{4})[^0-9A-Za-z][^!#]*(?<num>[0-9]{3})-(?<pass>[0-9]{6}|[0-9]{4})#|#[^!#]*(?<name1>[a-zA-Z]{4})[^0-9A-Za-z][^!#]*(?<num1>[0-9]{3})-(?<pass1>[0-9]{6}|[0-9]{4})!";
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                if (Regex.IsMatch(input, pattern))
                {
                    var matches = Regex.Matches(input, pattern);
                    int counter = 1;
                    if (matches.Count % 2 == 0)
                    {
                        foreach (Match match in matches)
                        {
                            if (counter % 2 == 0)
                            {
                                if (match.Groups["name"].Value != "")
                                {
                                    Console.WriteLine($"Go to str. {match.Groups["name"].Value} {match.Groups["num"].Value}. Secret pass: {match.Groups["pass"].Value}.");
                                }
                                else
                                {
                                    Console.WriteLine($"Go to str. {match.Groups["name1"].Value} {match.Groups["num1"].Value}. Secret pass: {match.Groups["pass1"].Value}.");
                                }
                            }
                            counter++;

                        }
                    }
                    else
                    {
                        foreach (Match match in matches)
                        {
                            if (match.Groups["name"].Value != "")
                            {
                                Console.WriteLine($"Go to str. {match.Groups["name"].Value} {match.Groups["num"].Value}. Secret pass: {match.Groups["pass"].Value}.");
                            }
                            else
                            {
                                Console.WriteLine($"Go to str. {match.Groups["name1"].Value} {match.Groups["num1"].Value}. Secret pass: {match.Groups["pass1"].Value}.");
                            }
                        }
                    }
                }
            }
        }
    }
}
