using System;
using System.Collections.Generic;

namespace _06._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int numberOfPassedCars = 0;
            Queue<string> cars = new Queue<string>();
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    Console.WriteLine($"{numberOfPassedCars} cars passed the crossroads.");
                    return;
                }
                else if (command == "green")
                {
                    for (int count = 1; count <= num; count++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            numberOfPassedCars++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }
        }
    }
}
