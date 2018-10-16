using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _04._Cubic_Assault
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, BigInteger> dict = new Dictionary<string, BigInteger>();
            string input = Console.ReadLine();

            while (input != "Count em all")
            {
                string[] tokens = input.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                string region = tokens[0].Trim();
                string type = tokens[1].Trim();
                BigInteger count = BigInteger.Parse(tokens[2].Trim());
                if (!dict.ContainsKey(region))
                {
                    dict[region] = 0;
                }
                if (type == "Green")
                {
                    dict[region] += count;
                }
                else if (type == "Red")
                {
                    dict[region] += 1_000_000 * count;
                }
                else if (type == "Black")
                {
                    dict[region] += 1_000_000_000_000 * count;
                }
                input = Console.ReadLine();
            }
            Dictionary<string, Dictionary<string, BigInteger>> result = new Dictionary<string, Dictionary<string, BigInteger>>();
            foreach (var item in dict)
            {
                BigInteger black = item.Value / 1_000_000_000_000;
                BigInteger red = item.Value / 1_000_000 % 1_000_000;
                BigInteger green = item.Value % 1_000_000;
                result[item.Key] = new Dictionary<string, BigInteger>();
                result[item.Key]["Red"] = red;
                result[item.Key]["Black"] = black;
                result[item.Key]["Green"] = green;
            }
            foreach (var kvp in result.OrderByDescending(x => x.Value["Black"]).ThenBy(x => x.Key.Length).ThenBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (var item in kvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {item.Key} : {item.Value}");
                }
            }
        }
    }
}
// 70/100