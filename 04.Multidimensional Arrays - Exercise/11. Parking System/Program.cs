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
            FillMatrix(matrix, rows, cols);

            while (input != "stop")
            {
                int[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int entryRow = tokens[0];
                int parkingPlaceRow = tokens[1];
                int parkingPlaceCol = tokens[2];
                CheckIsFree(matrix, entryRow, parkingPlaceRow, parkingPlaceCol);
                input = Console.ReadLine();
            }
        }

        private static void FillMatrix(int[][] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 1; col < cols; col++)
                {
                    matrix[row][col] = 0;
                }
                matrix[row][0] = 1;
            }
        }

        private static void CheckIsFree(int[][] matrix, int entryRow, int parkingPlaceRow, int parkingPlaceCol)
        {
            if (matrix[parkingPlaceRow].All(x => x == 1))
            {
                Console.WriteLine($"Row {parkingPlaceRow} full");
            }
            else
            {

                if (matrix[parkingPlaceRow][parkingPlaceCol] == 0)
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
        }

        private static int FindNearestFreePlace(int[] row, int parkingPlaceCol)
        {
            for (int col = 1; col < row.Length; col++)
            {
                if (parkingPlaceCol > col && row[parkingPlaceCol - col] == 0)
                {
                    return parkingPlaceCol - col;
                }
                if (parkingPlaceCol + col < row.Length && row[parkingPlaceCol + col] == 0)
                {
                    return parkingPlaceCol + col;
                }
            }
            return -1;
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 1;
                }
            }
        }
        //80/100
    }
}