using System;
using System.Collections.Generic;

namespace _03._Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }
            Stack<int> stack = new Stack<int>();

            while (number > 0)
            {
                stack.Push(number % 2);
                number /= 2;
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
