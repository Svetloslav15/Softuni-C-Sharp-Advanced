using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _04._Movie_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            string wifeFavouriteGenre = Console.ReadLine();
            string wifeDurationPreference = Console.ReadLine();
            string input = Console.ReadLine();
            string format = @"hh\:mm\:ss";
            Dictionary<string, Dictionary<string, TimeSpan>> dict = new Dictionary<string, Dictionary<string, TimeSpan>>();

            while (input != "POPCORN!")
            {
                string[] tokens = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string genre = tokens[1];
                string duration = tokens[2];
                TimeSpan span = TimeSpan.ParseExact(duration, format, CultureInfo.InvariantCulture);

                if (!dict.ContainsKey(genre))
                {
                    dict[genre] = new Dictionary<string, TimeSpan>();
                }
                if (!dict[genre].ContainsKey(name))
                {
                    dict[genre][name] = span;
                }

                input = Console.ReadLine();
            }

            bool prefersShortMovies = wifeDurationPreference == "Short" ? true : false;
            var arr = dict[wifeFavouriteGenre]
                .OrderBy(p => prefersShortMovies ? p.Value : -p.Value)
                .ThenBy(x => x.Key)
                .ToArray();

            input = Console.ReadLine();
            int index = 0;
            while(input != "Yes")
            {
                Console.WriteLine(arr[index++].Key);
                input = Console.ReadLine();
            }
            Console.WriteLine(arr[index].Key);
            Console.WriteLine($"We're watching {arr[index].Key} - {arr[index].Value}");
            long allTime = dict.Sum(x => x.Value.Sum(y => y.Value.Ticks));
            var all = new TimeSpan(allTime);
            string totalPlaylistDuration = all.ToString(format, CultureInfo.InvariantCulture);
            Console.WriteLine($"Total Playlist Duration: {totalPlaylistDuration}");
        }
    }
}
