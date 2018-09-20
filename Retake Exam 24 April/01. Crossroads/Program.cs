using System;
using System.Collections.Generic;

namespace _01._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int durationGreenLight = int.Parse(Console.ReadLine());
            int durationOfFreeWindows = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            string input = Console.ReadLine();
            int carPassed = 0;
            while(input != "END")
            {
                if (input == "green")
                {
                    int temp = durationGreenLight;
                    while(queue.Count != 0)
                    {
                        string currentCar = queue.Dequeue();
                        if (currentCar.Length >= temp)
                        {
                            temp += durationOfFreeWindows;
                            if (temp >= currentCar.Length)
                            {
                                carPassed++;
                                
                                break;
                            }
                            else
                            {
                                char symbol = currentCar[temp];
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {symbol}.");
                                return;
                            }
                        }
                        else
                        {
                            temp -= currentCar.Length;
                            carPassed++;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carPassed} total cars passed the crossroads.");
        }
    }
}
