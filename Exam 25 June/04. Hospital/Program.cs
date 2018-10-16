using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> doctorAndPatients = new Dictionary<string, List<string>>();

            while (input != "Output")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string department = tokens[0];
                string doctor = tokens[1] + " " + tokens[2];
                string patient = tokens[3];
                
                if (!dict.ContainsKey(department))
                {
                    dict[department] = new List<string>();
                }
                dict[department].Add(patient);
                if (!doctorAndPatients.ContainsKey(doctor))
                {
                    doctorAndPatients[doctor] = new List<string>();
                }
                doctorAndPatients[doctor].Add(patient);

                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 1)
                {
                    foreach (var kvp in dict.Where(x => x.Key == tokens[0]))
                    {
                        foreach (var item in kvp.Value)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                else if (tokens[1].Length <= 2)
                {
                    int index = int.Parse(tokens[1]);
                    if (index <= 20)
                    {
                        var patients = dict[tokens[0]];
                        var room = patients.Skip(3 * (index - 1)).Take(3).OrderBy(x => x).ToArray();
                        foreach (var item in room)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                else
                {
                    string key = tokens[0] + " " + tokens[1];
                    foreach (var kvp in doctorAndPatients.Where(x => x.Key == key))
                    {
                        foreach (var item in doctorAndPatients[kvp.Key].OrderBy(x => x))
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}