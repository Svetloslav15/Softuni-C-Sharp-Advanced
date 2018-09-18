using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputOne = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] inputTwo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int n = inputOne[0];
            int s = inputOne[1];
            int x = inputOne[2];

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(inputTwo[i]);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.ToArray().OrderBy(y => y).First());
            }
        }
    }
}