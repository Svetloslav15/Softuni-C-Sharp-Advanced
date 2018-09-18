using System;
using System.Collections.Generic;

namespace _07._Balanced_Parenthsis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            int countA = 0;
            int countB = 0;

            foreach (var item in input)
            {
                if (item == '[' || item == '{' || item == '(')
                {
                    stack.Push(item);
                    countA++;
                }
                else
                {
                    countB++;
                    if (stack.Count != 0)
                    {
                        char lastItem = stack.Pop();
                        if ((lastItem == '[' && item != ']') || (lastItem == '{' && item != '}') || (lastItem == '(' && item != ')'))
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            if (countA == countB)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
