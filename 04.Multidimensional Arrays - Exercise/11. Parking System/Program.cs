using System;
using System.Linq;

namespace _11._Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            string input = Console.ReadLine();
            int[][] matrix = new int[rows][];

            while (input != "stop")
            {
                int[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int entryRow = tokens[0];
                int parkingPlaceRow = tokens[1];
                int parkingPlaceCol = tokens[2];
                if (matrix[parkingPlaceRow]  == null)
                {
                    matrix[parkingPlaceRow] = new int[cols];
                    matrix[parkingPlaceRow][0] = 1;
                }
                CheckIsFree(matrix, entryRow, parkingPlaceRow, parkingPlaceCol);
                input = Console.ReadLine();
            }
        }

        private static void CheckIsFree(int[][] matrix, int entryRow, int parkingPlaceRow, int parkingPlaceCol)
        {
            if (matrix[parkingPlaceRow].All(x => x == 1))
            {
                Console.WriteLine($"Row {parkingPlaceRow} full");
                return;
            }
            
            if (matrix[parkingPlaceRow][parkingPlaceCol] != 1)
            {
                matrix[parkingPlaceRow][parkingPlaceCol] = 1;
            }
            else
            {
                parkingPlaceCol = FindNearestFreePlace(matrix[parkingPlaceRow], parkingPlaceCol);
                matrix[parkingPlaceRow][parkingPlaceCol] = 1;
            }
            Console.WriteLine(Math.Abs(entryRow - parkingPlaceRow) + parkingPlaceCol + 1);
        }

        private static int FindNearestFreePlace(int[] row, int parkingPlaceCol)
        {
            for (int col = 1; col < row.Length; col++)
            {
                if (parkingPlaceCol > col && row[parkingPlaceCol - col] != 1)
                {
                    return parkingPlaceCol - col;
                }
                if (parkingPlaceCol + col < row.Length && row[parkingPlaceCol + col] != 1)
                {
                    return parkingPlaceCol + col;
                }
            }
            return -1;
        }
    }
}