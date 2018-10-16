using System;
using System.Text.RegularExpressions;

namespace _03._Cubics_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "Over!")
            {
                int length = int.Parse(Console.ReadLine());
                string pattern = @"^[0-9]*([a-zA-Z]{" + length + @"})[^A-Za-z]*$";
                if (Regex.IsMatch(input, pattern))
                {
                    Match match = Regex.Match(input, pattern);
                    string text = match.Groups[1].Value;
                    string result = "";
                    foreach (var item in input)
                    {
                        if (item >= 48 && item <= 57)
                        {
                            int index = item - 48;
                            if (index < 0 || index >= length)
                            {
                                result += " ";
                            }
                            else
                            {
                                result += text[index];
                            }
                        }
                    }

                    Console.WriteLine($"{text} == {result}");
                }
                input = Console.ReadLine();
            }
        }
    }
}