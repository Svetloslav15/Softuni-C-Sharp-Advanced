using System;
using System.Linq;

namespace _01._Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] length = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = length[0];
            int cols = length[1];
            string[,] matrix = new string[rows, cols];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    string word = $"{alphabet[row]}{alphabet[col + row]}{alphabet[row]}";
                    matrix[row, col] = word;
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
