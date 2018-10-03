using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hit_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string, Dictionary<string, string>>();
            while(input != "end transmissions")
            {
                string[] tokens = input
                    .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                if (!dict.ContainsKey(name))
                {
                    dict[name] = new Dictionary<string, string>();
                }
                for (int index = 1; index < tokens.Length; index++)
                {
                    string[] curr = tokens[index].Split(':');
                    string key = curr[0];
                    string value = curr[1];
                    dict[name][key] = value;
                }
                input = Console.ReadLine();
            }
            string killPerson = Console.ReadLine().Split(' ')[1];
            int justNumber = 0;
            Console.WriteLine($"Info on {killPerson}:");
            foreach (var kvp in dict[killPerson].OrderBy(x => x.Key))
            {
                justNumber += kvp.Key.Length + kvp.Value.Length;
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine($"Info index: {justNumber}");
            if (justNumber >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - justNumber} more info.");
            }
        }
    }
}
