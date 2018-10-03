using System;
using System.IO;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../";
            string fileName = "Program.cs";

            path = Path.Combine(path, fileName);
            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}
