using System;
using System.Collections.Generic;

namespace _08._Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long generations = long.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();
            stack.Push(0);

            for (int i = 1; i <= generations; i++)
            {
                if (stack.Count <= 2)
                {
                    stack.Push(1);
                }
                else
                {
                    long firstNum = stack.Pop();
                    long secondNum = stack.Peek();
                    long thirdNum = firstNum + secondNum;
                    stack.Push(firstNum);
                    stack.Push(thirdNum);
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
