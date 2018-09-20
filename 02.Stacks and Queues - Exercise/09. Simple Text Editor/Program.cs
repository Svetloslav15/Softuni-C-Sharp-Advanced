using System;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            string result = "";

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int operation = int.Parse(input[0]);
                switch (operation)
                {
                    case 1:
                        {
                            result += input[1];
                            string text = 1 + "<->" + input[1].Length.ToString();
                            stack.Push(text);
                        };break;
                    case 2:
                        {
                            int count = int.Parse(input[1]);
                            string partToRemove = result.Substring(result.Length - count);
                            result = result.Substring(0, result.Length - count);
                            string text = 2 + "<->" + partToRemove.ToString();
                            stack.Push(text);
                        }; break;
                    case 3:
                        {
                            int index = int.Parse(input[1]) - 1;
                            Console.WriteLine(result[index]);
                        }; break;
                    case 4:
                        {
                            string[] temp = stack.Pop().Split("<->");
                            int lastOperation = int.Parse(temp[0]);
                            string helpText = temp[1];
                            if (lastOperation == 2)
                            {
                                result += helpText;
                            }
                            else
                            {
                                int length = int.Parse(helpText);
                                result = result.Substring(0, result.Length - length);
                            }
                        }; break;
                }
            }
        }
    }
}
