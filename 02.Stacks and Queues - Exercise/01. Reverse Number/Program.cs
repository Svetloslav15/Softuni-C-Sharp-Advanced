using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>(nums);

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}
