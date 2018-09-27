using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];
            List<List<int>> matrix = new List<List<int>>();
            int counter = 1;
            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<int>());
                for (int col = 0; col < cols; col++)
                {
                    matrix[row].Add(counter++);
                }
            }
            string input = Console.ReadLine();
            while(input != "Nuke it from orbit")
            {
                int[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int impactRow = tokens[0];
                int impactCol = tokens[1];
                int radius = tokens[2];
                Destroy(matrix, impactRow, impactCol, radius);
                input = Console.ReadLine();
            }
            Print(matrix);
        }
        static void Print(List<List<int>> matrix)
        {
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(' ', item.Where(x => x != 0)));
            }
        }
        static void Destroy(List<List<int>> matrix, int impactRow, int impactCol, int radius)
        {
            if (impactRow >= 0 && impactRow < matrix.Count && impactCol >= 0 && impactCol < matrix[impactRow].Count)
            {
                matrix[impactRow][impactCol] = 0;
            }
            for (int row = impactRow - radius; row <= impactRow + radius; row++)
            {
                if (row >= 0 && row < matrix.Count && impactCol >= 0 && impactCol < matrix[row].Count)
                {
                    matrix[row][impactCol] = 0;
                }
            }
            for (int col = impactCol - radius; col <= impactCol + radius; col++)
            {
                if (impactRow >= 0 && impactRow < matrix.Count)
                {
                    int cols = matrix[impactRow].Count;
                    if (col >= 0 && col < cols)
                    {
                        matrix[impactRow][col] = 0;
                    }
                }
            }
            for (int row = 0; row < matrix.Count; row++)
            {
                int cols = matrix[row].Count;
                if (matrix[row].Where(x => x == 0).Count() == cols)
                {
                    matrix.RemoveAt(row);
                    row--;
                }
                else
                {
                    matrix[row] = matrix[row].Where(x => x != 0).ToList();
                }
            }
        }
    }
}