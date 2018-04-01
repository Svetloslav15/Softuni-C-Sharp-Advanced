using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numberOfElementsToPush = nums[0];
            int numberOfElementsToPop = nums[1];
            int numberSearchFor = nums[2];

            int[] tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); 

            Queue<int> queue = new Queue<int>();

            for (int count = 0; count < numberOfElementsToPush; count++)
            {
                queue.Enqueue(tokens[count]);
            }
            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count != 0)
            {
                if (queue.Contains(numberSearchFor))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.OrderBy(x => x).First());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
