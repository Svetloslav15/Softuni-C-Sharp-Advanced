using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            int petrolTotal = 0;
            int distanceTotal = 0;
            Queue<int> petrol = new Queue<int>();
            Queue<int> distance = new Queue<int>();

            for (int counter = 0; counter < petrolPumps; counter++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int currentPetrol = input[0];
                int currentDistance = input[1];
                petrol.Enqueue(currentPetrol);
                distance.Enqueue(currentDistance);
                petrolTotal += currentPetrol;
                distanceTotal += currentDistance;
            }

            if (petrolTotal >= distanceTotal)
            {
                petrolTotal = 0;
                distanceTotal = 0;
                int minIndex = int.MaxValue;
                int currentIndex = 0;
                int count = 0;

                while (count < petrolPumps)
                {
                    petrolTotal += petrol.Peek();
                    distanceTotal += distance.Peek();

                    if (petrolTotal >= distanceTotal)
                    {
                        if (currentIndex < minIndex)
                        {
                            minIndex = currentIndex;
                        }
                        count++;
                    }
                    else
                    {
                        int currentPetrol = petrol.Dequeue();
                        int currentDistance = distance.Dequeue();
                        petrol.Enqueue(currentPetrol);
                        distance.Enqueue(currentDistance);
                        count = 0;
                        currentIndex++;
                        petrolTotal = 0;
                        distanceTotal = 0;
                    }
                }
                Console.WriteLine(minIndex);
            }
        }
    }
}
