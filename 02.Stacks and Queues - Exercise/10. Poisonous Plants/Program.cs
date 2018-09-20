using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlants = int.Parse(Console.ReadLine());
            List<int> pesticides = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int days = 0;
            bool stopDying = true;
            Stack<int> indexes = new Stack<int>();

            while (true)
            {
                stopDying = true;
                days++;

                for (int index = 0; index < pesticides.Count - 1; index++)
                {
                    int firstPlant = pesticides[index];
                    int secondPlant = pesticides[index + 1];

                    if (firstPlant < secondPlant)
                    {
                        indexes.Push(index + 1);
                        stopDying = false;
                    }
                }
                while (indexes.Count != 0)
                {
                    pesticides.RemoveAt(indexes.Pop());
                }
                if (stopDying)
                {
                    Console.WriteLine(days - 1);
                    return;
                }
            }
        }
    }
}