using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Crypto_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int maxCount = 1;
            for (int index = 0; index < nums.Length; index++)
            {
                for (int step = 1; step < nums.Length; step++)
                {
                    int currentIndex = index;
                    int nextIndex = (step + currentIndex) % nums.Length;

                    int currentCount = 1;
                    while (nums[currentIndex] < nums[nextIndex])
                    {
                        currentCount++;
                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                        }
                        currentIndex = nextIndex;
                        nextIndex = (step + currentIndex) % nums.Length;
                    }
                }
            }
            Console.WriteLine(maxCount);
        }
    }
}
