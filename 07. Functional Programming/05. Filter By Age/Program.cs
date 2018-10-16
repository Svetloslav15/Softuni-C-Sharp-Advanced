using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int line = 0; line < lines; line++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                dict[tokens[0]] = int.Parse(tokens[1]);
            }
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            if (condition == "older")
            {
                dict = dict.Where(x => x.Value >= age)
                    .ToDictionary(x => x.Key, y => y.Value);
            }
            else
            {
                dict = dict.Where(x => x.Value < age)
                    .ToDictionary(x => x.Key, y => y.Value);
            }
            if (format == "name")
            {
                foreach (var item in dict)
                {
                    Console.WriteLine(item.Key);
                }
            }
            else if (format == "age")
            {
                foreach (var item in dict)
                {
                    Console.WriteLine(item.Value);
                }
            }
            else
            {
                foreach (var item in dict)
                {
                    Console.WriteLine(item.Key + " - " + item.Value);
                }
            }
        }
    }
}