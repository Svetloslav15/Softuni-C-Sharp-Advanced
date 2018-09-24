using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                jagged[row] = new int[currentRow.Length];
                for (int index = 0; index < currentRow.Length; index++)
                {
                    jagged[row][index] = currentRow[index];
                }
            }
            string command = Console.ReadLine();
            while(command != "END")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row][col])
                {
                    if (tokens[0] == "Add")
                    {
                        jagged[row][col] += value;
                    }
                    else if (tokens[0] == "Subtract")
                    {
                        jagged[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
                
                command = Console.ReadLine();
            }

            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
