namespace _06.TargetPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = sizes[0];
            int cols = sizes[1];
            string word = Console.ReadLine();
            int[] tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int impactRow = tokens[0];
            int impactCol = tokens[1];
            int radius = tokens[2];
            int counter = 0;
            Queue<char> queue = new Queue<char>(word);
            char[,] matrix = new char[rows, cols];
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (counter % 2 == 0)
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
                counter++;
            }
            Destroy(matrix, impactRow, impactCol, radius);
            Rearrange(matrix);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        static void Destroy(char[,] matrix, int impactRow, int impactCol, int radius)
        {
            matrix[impactRow, impactCol] = ' ';
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (((row - impactRow) * (row - impactRow) + (col - impactCol) * (col - impactCol)) <= radius * radius)
                    {
                        matrix[row, col] = ' ';
                    }
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
                    int lastIndex = currentColumn.LastIndexOf(' ');
                    int firstIndex = currentColumn.IndexOf(' ');
                    firstIndex--;
                    while (firstIndex >= 0)
                    {
                        matrix[lastIndex, col] = matrix[firstIndex, col];
                        matrix[firstIndex, col] = ' ';
                        lastIndex--;
                        firstIndex--;
                    }
                }
            }
        }
    }
}