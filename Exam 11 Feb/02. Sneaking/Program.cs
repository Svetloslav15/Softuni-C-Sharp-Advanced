using System;

namespace _02._Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                matrix[row] = new char[currentRow.Length];
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row][col] = currentRow[col];
                }
            }
            string commands = Console.ReadLine();
            for (int count = 0; count < commands.Length; count++)
            {
                char currentCommand = commands[count];
                MoveOponents(matrix);
                MoveSam(matrix, currentCommand);
            }
        }

        private static void MoveSam(char[][] matrix, char direction)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                string currentRow = MakeToString(matrix[row]);
                if (currentRow.Contains("S") && direction != 'W')
                {
                    int indexOfSam = currentRow.IndexOf('S');
                    matrix[row][indexOfSam] = '.';
                    if (direction == 'U')
                    {
                        matrix[row - 1][indexOfSam] = 'S';
                        if (MakeToString(matrix[row - 1]).Contains("N"))
                        {
                            int indexOfNikoladze = MakeToString(matrix[row - 1]).IndexOf('N');
                            matrix[row - 1][indexOfNikoladze] = 'X';
                            Console.WriteLine("Nikoladze killed!");
                            Print(matrix);
                        }
                    }
                    else if (direction == 'R')
                    {
                        matrix[row][indexOfSam + 1] = 'S';
                    }
                    else if (direction == 'L')
                    {
                        matrix[row][indexOfSam - 1] = 'S';
                    }
                    else if (direction == 'D')
                    {
                        matrix[row + 1][indexOfSam] = 'S';
                        if (MakeToString(matrix[row + 1]).Contains("N"))
                        {
                            int indexOfNikoladze = MakeToString(matrix[row + 1]).IndexOf('N');
                            matrix[row + 1][indexOfNikoladze] = 'X';
                            Console.WriteLine("Nikoladze killed!");
                            Print(matrix);
                        }
                        row++;
                    }
                }
            }
        }

        static void MoveOponents(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    char currentEl = matrix[row][col];
                    if (currentEl == 'b')
                    {
                        if (col + 1 <= matrix[row].Length - 1)
                        {
                            matrix[row][col] = '.';
                            matrix[row][col + 1] = 'b';
                            string subst = MakeToString(matrix[row]);
                            int indexOfSam = subst.IndexOf('S');
                            if (subst.Contains("S") && ((col + 1) < indexOfSam))
                            {
                                matrix[row][indexOfSam] = 'X';
                                Console.WriteLine($"Sam died at {row}, {indexOfSam}");
                                Print(matrix);
                            }
                            col++;
                        }
                        else
                        {
                            matrix[row][col] = 'd';
                            string subst = MakeToString(matrix[row]);
                            int indexOfSam = subst.IndexOf('S');
                            if (subst.Contains("S") && (col < indexOfSam))
                            {
                                matrix[row][indexOfSam] = 'X';
                                Console.WriteLine($"Sam died at {row}, {indexOfSam}");
                                Print(matrix);
                            }
                        }
                    }
                    else if (currentEl == 'd')
                    {
                        if (col - 1 >= 0)
                        {
                            matrix[row][col] = '.';
                            matrix[row][col - 1] = 'd';
                            string subst = MakeToString(matrix[row]);
                            int indexOfSam = subst.IndexOf('S');
                            if (subst.Contains("S") && ((col - 1) >= indexOfSam))
                            {
                                matrix[row][indexOfSam] = 'X';
                                Console.WriteLine($"Sam died at {row}, {indexOfSam}");
                                Print(matrix);
                            }
                        }
                        else
                        {
                            matrix[row][col] = 'b';
                            string subst = MakeToString(matrix[row]);
                            int indexOfSam = subst.IndexOf('S');
                            if (subst.Contains("S") && (col <= indexOfSam))
                            {
                                matrix[row][indexOfSam] = 'X';
                                Console.WriteLine($"Sam died at {row}, {indexOfSam}");
                                Print(matrix);
                            }
                        }
                    }
                }
            }
        }

        private static string MakeToString(char[] arr)
        {
            string result = "";
            foreach (var item in arr)
            {
                result += item;
            }
            return result;
        }

        static void Print(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }
    }
}
