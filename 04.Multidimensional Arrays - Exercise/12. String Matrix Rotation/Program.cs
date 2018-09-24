using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _12._String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string degreesText = Console.ReadLine();
            int degrees = int.Parse(Regex.Match(degreesText, "[0-9]+").Value) % 360;
            List<string> texts = new List<string>();
            int maxLength = int.MinValue;
            string input = Console.ReadLine();
            while(input != "END")
            {
                texts.Add(input);
                if (input.Length > maxLength)
                {
                    maxLength = input.Length;
                }
                input = Console.ReadLine();
            }
            if (degrees == 90)
            {
                texts = Rotate(texts, maxLength);
            }
            else if (degrees == 180)
            {
                for (int i = 1; i <= 2; i++)
                {
                    texts = Rotate(texts, maxLength);
                }
            }
            else if (degrees == 270)
            {
                for (int i = 1; i <= 3; i++)
                {
                    texts = Rotate(texts, maxLength);
                }
            }
            foreach (var item in texts)
            {
                Console.WriteLine(string.Join("", item));
            }
        }

        private static List<string> Rotate(List<string> texts, int maxLength)
        {
            List<string> temp = new List<string>();
            for (int col = 0; col < maxLength; col++)
            {
                string currentString = "";
                for (int row = texts.Count - 1; row >= 0; row--)
                {
                    if (col >= texts[row].Length)
                    {
                        currentString += " ";
                    }
                    else
                    {
                        currentString += texts[row][col];
                    }
                }
                temp.Add(currentString);
            }

            return temp;
        }
    }
}