using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Exercise1
{
    class Program
    {
        Dictionary<int, string> cashreg = new Dictionary<int, string>();
        
        static void Main(string[] args)
        {
            var fileLines1 = File.ReadAllLines(@"cashreg1.txt");
            var fileLines2 = File.ReadAllLines(@"cashreg2.txt");
            var fileLines3 = File.ReadAllLines(@"cashreg3.txt");
            var fileLines4 = File.ReadAllLines(@"cashreg4.txt");
            var fileLines5 = File.ReadAllLines(@"cashreg5.txt");

            // ... add new lines ...

            var allLines = new List<string[]> { fileLines1, fileLines2, fileLines3, fileLines4, fileLines5 };

            var dicts = new List<Dictionary<string, int>>();

            foreach (var lines in allLines)
            {

                var dict = lines
                    .Select(l => l.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    .ToDictionary(x => x[0], x => int.Parse(x[1]));

                dicts.Add(dict);
            }

            
            var averages = new Dictionary<string, float>();

            var keys = dicts.First().Keys;

            foreach (var key in keys)
            {
                float average = 0f;
                foreach (var dict in dicts)
                {
                    average += dict[key];
                }

                averages[key] = average / dicts.Count;
                
            }
            var maxInterval = "";
            var previous = "";
            var maxPrevious = "";
            var maxPeople = 0f;
            
            foreach (var kvp in averages)
            {


                if (kvp.Value > maxPeople)
                {
                    maxPeople = kvp.Value;
                    maxInterval = kvp.Key;
                    maxPrevious = previous;
                                     
                }

                previous = kvp.Key;
            }
                        

            Console.WriteLine("Максимальное количество людей заходило в магазин в интервале " + maxPrevious + " - " + maxInterval + ",  среднем " + maxPeople + " человек");
            Console.ReadKey();           
        }
        
    }
}