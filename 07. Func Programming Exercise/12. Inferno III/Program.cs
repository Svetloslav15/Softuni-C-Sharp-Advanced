using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Inferno_III
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            nums.Insert(0, 0);
            nums.Insert(nums.Count, 0);
            List<int> numsCopy = new List<int>();
            nums.ForEach(x => numsCopy.Add(x));

            string input;
            while ((input = Console.ReadLine()) != "Forge")
            {
                string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string filterType = tokens[1];
                int filterParameter = int.Parse(tokens[2]);
                List<int> list = new List<int>();

                if (filterType == "Sum Left")
                {
                    list = SumLeft(numsCopy, filterParameter);
                }
                else if (filterType == "Sum Right")
                {
                    list = SumRight(numsCopy, filterParameter);
                }
                else if (filterType == "Sum Left Right")
                {
                    list = SumLeftRight(numsCopy, filterParameter);
                }

                if (command == "Exclude")
                {
                    foreach (var item in list)
                    {
                        if (nums.Contains(item))
                        {
                            nums.Remove(item);
                        }
                    }
                }
                else if (command == "Reverse")
                {
                    foreach (var item in list)
                    {
                        int index = list.IndexOf(item);
                        nums.Insert(index, item);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", nums.Where(x => x != 0)));
        }
        static List<int> SumLeft(List<int> nums, int number)
        {
            var list = new List<int>();
            for (int index = 1; index < nums.Count; index++)
            {
                int sum = nums[index] + nums[index - 1];
                if (sum == number)
                {
                    list.Add(nums[index]);
                }
            }
            return list;
        }
        static List<int> SumRight(List<int> nums, int number)
        {
            var list = new List<int>();
            for (int index = 0; index < nums.Count - 1; index++)
            {
                int sum = nums[index] + nums[index + 1];
                if (sum == number)
                {
                    list.Add(nums[index]);
                }
            }
            return list;
        }
        static List<int> SumLeftRight(List<int> nums, int number)
        {
            var list = new List<int>();
            for (int index = 1; index < nums.Count - 1; index++)
            {
                int sum = nums[index] + nums[index + 1] + nums[index - 1];
                if (sum == number)
                {
                    list.Add(nums[index]);
                }
            }
            return list;
        }
    }
}
