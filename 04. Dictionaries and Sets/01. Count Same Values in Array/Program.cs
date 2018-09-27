using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, double> dict = new Dictionary<double, double>();
            for (int index = 0; index < input.Length; index++)
            {
                if (!dict.ContainsKey(input[index]))
                {
                    dict[input[index]] = 0;
                }
                dict[input[index]]++;
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
