using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Cubics_Rube
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            long hitted = 0;
            int hittedCount = 0;
            List<string> hittedPoints = new List<string>();
            
            string input = Console.ReadLine();
            while (input != "Analyze")
            {
                long[] tokens = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
                if (tokens[0] >= 0 && tokens[0] < length &&
                    tokens[1] >= 0 && tokens[1] < length && 
                    tokens[2] >= 0 && tokens[2] < length && tokens[3] != 0)
                {
                    string currentPoint = $"{tokens[0]} {tokens[1]} {tokens[2]}";
                    if (!hittedPoints.Contains(currentPoint))
                    {
                        hitted += tokens[3];
                        hittedCount++;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(hitted);
            Console.WriteLine((length * length * length) - hittedCount);
        }
    }
}