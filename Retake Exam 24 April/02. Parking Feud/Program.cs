using System;
using System.Linq;

namespace _02._Parking_Feud
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] temp = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = temp[0];
            int cols = temp[1];
            int entrance = int.Parse(Console.ReadLine());
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine().Split(' ');
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string helpingString = "abcdefghijklmnopqrstuvwxyz";
            int totalDistance = 0;
        }
    }
}
