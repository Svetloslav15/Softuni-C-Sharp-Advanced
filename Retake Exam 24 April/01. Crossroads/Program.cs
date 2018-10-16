using System;
using System.Collections.Generic;

namespace _01._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;

            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command == "green")
                {
                    int currentSec = greenLightDuration;
                    while (cars.Count > 0)
                    {
                        string currentCar = cars.Dequeue();
                        if (currentCar.Length < currentSec)
                        {
                            carsPassed++;
                            currentSec -= currentCar.Length;
                        }
                        else
                        {
                            currentSec += freeWindow;
                            if (currentCar.Length <= currentSec)
                            {
                                carsPassed++;
                                break;
                            }
                            else
                            {
                                char symbol = currentCar[currentSec];
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {symbol}.");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}