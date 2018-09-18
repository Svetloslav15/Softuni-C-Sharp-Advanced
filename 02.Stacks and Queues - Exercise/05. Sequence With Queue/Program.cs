using System;
using System.Collections.Generic;

namespace _05._Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long startNum = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            List<long> result = new List<long>();
            queue.Enqueue(startNum);
            result.Add(startNum);

            int counter = 1;

            for (int i = 1; i < 50; i++)
            {
                if (counter == 1)
                {
                    queue.Enqueue(queue.Peek() + 1);
                    result.Add(queue.Peek() + 1);
                    counter++;
                }
                else if (counter == 2)
                {
                    long num = queue.Peek() * 2 + 1;
                    queue.Enqueue(num);
                    result.Add(num);
                    counter++;
                }
                else if (counter == 3)
                {
                    counter = 1;
                    long num = queue.Dequeue() + 2;
                    queue.Enqueue(num);
                    result.Add(num);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
