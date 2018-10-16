using System;
using System.Text.RegularExpressions;

namespace _01._Data_Transfer
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            string pattern = "^s:(?<sender>[^;]+);r:(?<receiver>[^;]+);m--\"(?<msg>[a-zA-Z\\s]+)\"$";
            int dataSize = 0;
            for (int i = 0; i < numberOfLines; i++)
            {
                string input = Console.ReadLine();
                var match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string sender = match.Groups["sender"].Value;
                    string receiver = match.Groups["receiver"].Value;
                    string message = match.Groups["msg"].Value;
                    dataSize += CalculateData(sender, receiver);
                    sender = ReturnText(sender);
                    receiver = ReturnText(receiver);
                    Console.WriteLine($"{sender} says \"{message}\" to {receiver}");
                }
            }
            Console.WriteLine($"Total data transferred: {dataSize}MB");
        }
        private static string ReturnText(string text)
        {
            string result = "";
            var matches = Regex.Matches(text, "[A-Za-z\\s]");
            foreach (Match item in matches)
            {
                result += item.Value;
            }
            return result;
        }
        private static int CalculateData(string sender, string receiver)
        {
            int data = 0;
            foreach (var item in sender)
            {
                if (item >= '0' && item <= '9')
                {
                    data += item - 48;
                }
            }
            foreach (var item in receiver)
            {
                if (item >= '0' && item <= '9')
                {
                    data += item - 48;
                }
            }
            return data;
        }
    }
}
