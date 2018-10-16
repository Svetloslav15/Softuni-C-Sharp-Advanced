using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bottlesCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> cups = new Queue<int>(cupsCapacity);
            Stack<int> bottles = new Stack<int>(bottlesCapacity);

            int wastedWater = 0;
            while (cups.Count > 0 && bottles.Count > 0) 
            {
                int currentCup = cups.Dequeue();
                while (currentCup > 0)
                {
                    if (bottles.Count > 0)
                    {
                        int bottle = bottles.Pop();
                        if (bottle > currentCup)
                        {
                            wastedWater += bottle - currentCup;
                            currentCup = 0;
                        }
                        else
                        {
                            currentCup = currentCup - bottle;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}