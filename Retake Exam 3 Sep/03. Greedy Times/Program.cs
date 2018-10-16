using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Greedy_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> dict = new Dictionary<string, Dictionary<string, long>>();
            long capacity = long.Parse(Console.ReadLine());
            string[] tokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, long> allQuantity = new Dictionary<string, long>();

            allQuantity["Gold"] = 0;
            allQuantity["Gem"] = 0;
            allQuantity["Cash"] = 0;

            for (int index = 0; index < tokens.Length - 1; index++)
            {
                string item = tokens[index++];
                string copy = item.ToLower();
                long quantity = long.Parse(tokens[index]);

                if (CheckRules(copy, allQuantity["Gold"], allQuantity["Cash"], allQuantity["Gem"], quantity))
                {
                    if (copy.Length == 3)
                    {
                        FillDict(dict, "Cash", item, quantity, allQuantity);
                    }
                    else if (copy.EndsWith("gem") && copy.Length >= 4)
                    {
                        FillDict(dict, "Gem", item, quantity, allQuantity);
                    }
                    else if (copy == "gold")
                    {
                        FillDict(dict, "Gold", item, quantity, allQuantity);
                    }
                }
            }

            foreach (var kvp in allQuantity.OrderByDescending(x => x.Value))
            {
                if (dict.ContainsKey(kvp.Key))
                {
                    Console.WriteLine($"<{kvp.Key}> ${kvp.Value}");
                    foreach (var item in dict[kvp.Key].OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                    {
                        Console.WriteLine($"##{item.Key} - {item.Value}");
                    }
                }
            }
        }

        private static void FillDict(Dictionary<string, Dictionary<string, long>> dict, string outerKey, string item, long quantity, Dictionary<string, long> allQuantity)
        {
            if (!dict.ContainsKey(outerKey))
            {
                dict[outerKey] = new Dictionary<string, long>();
            }
            if (!dict[outerKey].ContainsKey(item))
            {
                dict[outerKey][item] = 0;
            }
            dict[outerKey][item] += quantity;
            allQuantity[outerKey] += quantity;
        }

        private static bool CheckRules(string item, long gold, long cash, long gems, long quantity)
        {
            if (item.Length == 3)
            {
                cash += quantity;
            }
            else if (item.EndsWith("gem"))
            {
                gems += quantity;
            }
            else if (item == "Gold")
            {
                gold += quantity;
            }
            if (gold >= gems && gems >= cash)
            {
                return true;
            }
            return false;
        }
    }
}