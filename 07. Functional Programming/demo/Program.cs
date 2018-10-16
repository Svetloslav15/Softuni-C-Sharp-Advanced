using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int, int> func = (x, y, z) => (x + y + z);
            Console.WriteLine(func(50, 34, 5));
        }
    }
}
