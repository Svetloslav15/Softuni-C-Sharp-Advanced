using System;
using System.IO;
using System.Text;

namespace demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello my name is Svetli!";
            FileStream fileStream = new FileStream("../../../log.txt", FileMode.Create);

            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                fileStream.Write(bytes, 0, bytes.Length);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
