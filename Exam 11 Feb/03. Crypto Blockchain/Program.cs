using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Crypto_Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\[[^0-9]*([0-9]{3,})[^0-9]*\]|\{[^0-9]*([0-9]{3,})[^0-9]*\}";
            int rows = int.Parse(Console.ReadLine());
            string text = "";
            string result = "";
            for (int row = 0; row < rows; row++)
            {
                text += Console.ReadLine();
            }

            var matches = Regex.Matches(text, pattern);
            foreach (Match item in matches)
            {
                string value = item.Groups[2].Value;
                if (value == "")
                {
                    value = item.Groups[1].Value;
                }
                int length = item.Length;
                if (value.Length % 3 == 0)
                {
                    for (int index = 0; index < value.Length / 3; index++)
                    {
                        string currString = MakeToString(value.Skip(index * 3).Take(3).ToArray());
                        int code = int.Parse(currString);
                        result += (char)(code - length);
                    }
                }
            }
            Console.WriteLine(result);
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
    }
}
