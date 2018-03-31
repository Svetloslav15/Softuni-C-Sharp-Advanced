using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int hotPotato = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(input);

            int counter = 0;

            while (queue.Count > 1)
            {
                counter++;
                if (counter == hotPotato)
                {
                    string name = queue.Dequeue();
                    Console.WriteLine($"Removed {name}");
                    counter = 0;
                }
                else
                {
                    string name = queue.Dequeue();
                    queue.Enqueue(name);
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
