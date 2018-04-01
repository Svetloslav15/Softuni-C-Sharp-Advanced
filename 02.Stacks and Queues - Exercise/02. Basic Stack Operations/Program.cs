using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numberOfElementsToPush = nums[0];
            int numberOfElementsToPop = nums[1];
            int numberSearchFor = nums[2];
            Stack<int> stack = new Stack<int>();

            int[] tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int count = 0; count <= numberOfElementsToPush - 1; count++)
            {
                stack.Push(tokens[count]);
            }
            for (int count = 0; count <= numberOfElementsToPop - 1; count++)
            {
                stack.Pop();
            }
            if (stack.Contains(numberSearchFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count > 0)
                {
                    Console.WriteLine(stack.OrderBy(x => x).First());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
