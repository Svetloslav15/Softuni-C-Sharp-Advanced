using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();
            for (int index = 0; index < count; index++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = tokens[0];
                double grade = double.Parse(tokens[1]);
                if (!dict.ContainsKey(name))
                {
                    dict[name] = new List<double>();
                }
                dict[name].Add(grade);
            }
            foreach (var item in dict)
            {
                string value = "";
                for (int i = 0; i < item.Value.Count; i++)
                {
                    value += $"{item.Value[i]:f2} ";
                }
                value = value.Trim();
                Console.WriteLine($"{item.Key} -> {value} (avg: {item.Value.Average():f2})");
            }
        }
    }
}
