using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Stack_Operations
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

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(inputTwo[i]);
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.ToArray().OrderByDescending(y => y).Last());
            }
        }
    }
}
