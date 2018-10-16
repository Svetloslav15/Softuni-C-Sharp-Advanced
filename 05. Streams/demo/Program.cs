using System;
using System.IO;
using System.Linq;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../";
            string fileName = "Program.cs";
            string textName = "text.txt";

            string pathName = Path.Combine(path, fileName);
            string textPath = Path.Combine(path, textName);

            using (StreamReader reader = new StreamReader(pathName))
            {
                using(StreamWriter writer = new StreamWriter(textPath))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine(string.Join("", line.Reverse()));
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
