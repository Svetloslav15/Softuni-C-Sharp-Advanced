using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            Stack<int> nums = new Stack<int>(numberOfLines);

            for (int i = 1; i <= numberOfLines; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int num = input[0];        

                switch (num)
                {
                    case 1: nums.Push(input[1]);break;
                    case 2: nums.Pop();break;
                    case 3: Console.WriteLine(nums.ToArray().OrderByDescending(x => x).First());break;
                }
            }
        }
    }
}
