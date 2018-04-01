using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfQueries = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            Stack<int> max = new Stack<int>();
            max.Push(int.MinValue);

            for (int querie = 0; querie < numberOfQueries; querie++)
            {
                int[] tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int num = tokens[0];

                switch (num)
                {
                    case 1:
                        stack.Push(tokens[1]);
                        if (max.Peek() <= tokens[1])
                        {
                            max.Push(tokens[1]);
                        }
                        break;
                    case 2:
                        var poped = stack.Pop();
                        if (max.Peek() == poped)
                        {
                            max.Pop();
                        }
                        break;
                    case 3:
                        Console.WriteLine(max.Peek());
                        break;
                }
            }
        }
    }
}
