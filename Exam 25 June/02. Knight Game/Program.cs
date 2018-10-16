using System;

namespace _02._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            char[][] matrix = new char[dimensions][];

            int maxRow = 0;
            int maxCol = 0;
            int knightsToRemove = 0;
            int currentKnightsInDanger = 0;
            int maxKnightsInDanger = -1;

            for (int row = 0; row < dimensions; row++)
            {
                string currRow = Console.ReadLine();
                matrix[row] = new char[dimensions];
                for (int col = 0; col < dimensions; col++)
                {
                    matrix[row][col] = currRow[col];
                }
            }
            while (true)
            {
                for (int row = 0; row < dimensions; row++)
                {
                    for (int col = 0; col < dimensions; col++)
                    {
                        if (matrix[row][col] == 'K')
                        {
                            if (IsCellInMatrix(dimensions, row - 1, col + 2, matrix))
                            {
                                currentKnightsInDanger++;
                            }
                            if (IsCellInMatrix(dimensions, row - 1, col - 2, matrix))
                            {
                                currentKnightsInDanger++;
                            }
                            if (IsCellInMatrix(dimensions, row + 1, col + 2, matrix))
                            {
                                currentKnightsInDanger++;
                            }
                            if (IsCellInMatrix(dimensions, row + 1, col - 2, matrix))
                            {
                                currentKnightsInDanger++;
                            }
                            if (IsCellInMatrix(dimensions, row - 2, col + 1, matrix))
                            {
                                currentKnightsInDanger++;
                            }
                            if (IsCellInMatrix(dimensions, row - 2, col - 1, matrix))
                            {
                                currentKnightsInDanger++;
                            }
                            if (IsCellInMatrix(dimensions, row + 2, col - 1, matrix))
                            {
                                currentKnightsInDanger++;
                            }
                            if (IsCellInMatrix(dimensions, row + 2, col + 1, matrix))
                            {
                                currentKnightsInDanger++;
                            }
                        }
                        if (maxKnightsInDanger < currentKnightsInDanger)
                        {
                            maxKnightsInDanger = currentKnightsInDanger;
                            maxRow = row;
                            maxCol = col;
                        }
                        currentKnightsInDanger = 0;
                    }
                }
                if (maxKnightsInDanger != 0)
                {
                    matrix[maxRow][maxCol] = '0';
                    knightsToRemove++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(knightsToRemove);
                    return;
                }
            }
        }
        private static bool IsCellInMatrix(int dimensions, int row, int col, char[][] matrix)
        {
            if (row >= 0 && row < dimensions && col >= 0 && col < dimensions)
            {
                if (matrix[row][col] == 'K')
                {
                    return true;
                }
            }
            return false;
        }
    }
}