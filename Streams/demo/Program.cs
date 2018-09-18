using System;
using System.IO;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var streamReader = new StreamReader("Program.cs"))
            {
                using (var writeSream = new StreamWriter("REVERSED.txt"))
                {
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        for (int counter = line.Length - 1; counter >= 0; counter--)
                        {
                            writeSream.Write(line[counter]);
                        }
                        writeSream.WriteLine();
                    }
                }
            }
        }
    }
}