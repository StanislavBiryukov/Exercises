using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Data;
using System.Globalization;
using System.Threading;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"timecheck.txt");
            List<(TimeSpan, bool)> events = new List<(TimeSpan, bool)>();

            TimeSpan intervalFrom = TimeSpan.Zero;
            TimeSpan intervalTo = TimeSpan.Zero;
            TimeSpan previosFrom = TimeSpan.Zero;

            int maxCounter = 0;
            int counter = 0;

            for (var i = 0; i < lines.Length; i++)
            {
                var timestamps = lines[i].Split(';', StringSplitOptions.RemoveEmptyEntries);

                var enterTime = TimeSpan.Parse(timestamps[0]);
                events.Add((enterTime, true));

                var quitTime = TimeSpan.Parse(timestamps[1]);
                events.Add((quitTime, false));
            }

            foreach (var @event in events.OrderBy(e => e.Item1))
            {
                if (@event.Item2)
                {
                    counter++;
                    previosFrom = @event.Item1;
                }
                else
                {
                    if (counter > maxCounter)
                    {
                        maxCounter = counter;
                        intervalFrom = previosFrom;
                        intervalTo = @event.Item1;
                    }
                    counter--;
                }
            }

            Console.WriteLine("Максимальное количество посетителей в банке было " + maxCounter + " с " + intervalFrom + " до " + intervalTo);
            Console.ReadKey();
            
        }

        //foreach (string line in lines)
        //{
        //    TimeSpan ts = TimeSpan.Parse(line);
        //    Console.WriteLine(line);
        //}

    }
    
}
