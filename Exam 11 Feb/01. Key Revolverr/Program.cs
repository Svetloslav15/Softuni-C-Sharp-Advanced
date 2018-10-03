using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Key_Revolverr
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfEachBullet = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locksInt = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            Stack<int> barrel = new Stack<int>(bullets);
            int count = 0;
            int index = bullets.Length - 1;
            Queue<int> locks = new Queue<int>(locksInt);
            int spentMoney = 0;
            while (true)
            {
                if (barrel.Count == 0)
                {
                    if (locks.Count > 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                        return;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count == gunBarrelSize)
                {
                    Console.WriteLine("Reloading!");
                    count = 0;
                }
                if (locks.Count == 0)
                {
                    break;
                }
                int currentLock = locks.Peek();
                int currentBullet = barrel.Pop();
                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                spentMoney += priceOfEachBullet;
                count++;
            }
            Console.WriteLine($"{barrel.Count} bullets left. Earned ${intelligenceValue - spentMoney}");
        }
    }
}
