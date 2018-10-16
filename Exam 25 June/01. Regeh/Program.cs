using System;
using System.Text.RegularExpressions;

namespace _01._Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\[\w+<(?<nums>[0-9]+)REGEH(?<nums2>[0-9]+)>\w+\]";
            var matches = Regex.Matches(input, pattern);

            string result = "";
            int index = 0;
            foreach (Match match in matches)
            {
                int firstIndex = int.Parse(match.Groups["nums"].Value);
                index += firstIndex;
                result += input[index % input.Length];
                int secondIndex = int.Parse(match.Groups["nums2"].Value);
                index += secondIndex;
                result += input[index % input.Length];
            }
            Console.WriteLine(result);
        }
    }
}
