using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int impactRow = input[0];
            int impactCol = input[1];
            int radius = input[2];
            char[,] matrix = new char[dimensions[0], dimensions[1]];
            Queue<char> queue = new Queue<char>(snake);

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (row % 2 == 0)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        char innerText = queue.Dequeue();
                        matrix[row, col] = innerText;
                        queue.Enqueue(innerText);
                    }
                }
                else
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        char innerText = queue.Dequeue();
                        matrix[row, col] = innerText;
                        queue.Enqueue(innerText);
                    }
                }
            }
            Destroy(matrix, impactRow, impactCol, radius);
            Rearrange(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Destroy(char[,] matrix, int row, int col, int radius)
        {
            matrix[row, col] = ' ';
            if (row - 1 >= 0 && col - 1 >= 0)
            {
                matrix[row - 1, col - 1] = ' ';
            }
            if (row - 1 >= 0 && col + 1 < matrix.GetLength(1))
            {
                matrix[row - 1, col + 1] = ' ';
            }
            if (row + 1 < matrix.GetLength(0) && col - 1 >= 0)
            {
                matrix[row + 1, col - 1] = ' ';
            }
            if (row + 1 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1))
            {
                matrix[row + 1, col + 1] = ' ';
            }
            for (int index = 1; index <= radius; index++)
            {
                if (row + index < matrix.GetLength(0))
                {
                    matrix[row + index, col] = ' ';
                }
                if (row - index >= 0)
                {
                    matrix[row - index, col] = ' ';
                }
                if (col + index < matrix.GetLength(1))
                {
                    matrix[row, col + index] = ' ';
                }
                if (col - index >= 0)
                {
                    matrix[row, col - index] = ' ';
                }
            }
        }
        static void Rearrange(char[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                string currentColumn = "";
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    currentColumn += matrix[row, col];
                }
                if (currentColumn.Contains(' '))
                {
                    int index = currentColumn.LastIndexOf(' ');
                    int last = index;
                    for (int row = last - 2; row >= 0; row--)
                    {
                        char currentSymbol = matrix[row, col];
                        matrix[row, col] = ' ';
                        matrix[row + index, col] = currentSymbol;
                        index--;
                    }
                }
            }
        }
    }
}
