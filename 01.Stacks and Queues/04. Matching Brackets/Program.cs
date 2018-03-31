using System;
using System.Collections.Generic;

namespace _04._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stackOpenBracketsIndexes = new Stack<int>();

            for (int counter = 0; counter <= input.Length - 1; counter++)
            {
                if (input[counter] == '(')
                {
                    stackOpenBracketsIndexes.Push(counter);
                }
                if (input[counter] == ')')
                {
                    var openBracketIndex = stackOpenBracketsIndexes.Pop();
                    int length = counter - openBracketIndex + 1;
                    Console.WriteLine(input.Substring(openBracketIndex, length));
                }
            }
        }
    }
}
