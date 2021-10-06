using System;
using System.Collections.Generic;
using System.IO;

namespace Exercise1
{
    class Program
    {
        private static IList<int> Data = new List<int>();


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"1.txt");
            foreach (var line in lines)
            {
                var parsed = int.Parse(line);
                //Console.WriteLine(parsed);

                Data.Add(parsed);
            }


            //Console.WriteLine($"Количество: {Data.Count}");

            //Console.WriteLine($"Data: {string.Join(';', Data)}");
            string command = "";

            do
            {
                Console.WriteLine("Введите: \n1 для получения среднего значения\n2 для получения максимального значения\n3 для получения миниимального значения\n4 для получения медианного значения\n5 для получения значения процентиль 90");
                command = Console.ReadLine();


                switch (command)
                {
                    case "1":
                        CalculateAverage();
                        break;
                    case "2":
                        CalculateMax();
                        break;
                    case "3":
                        CalculateMin();
                        break;
                    case "4":
                        CalculateMedian();
                        break;
                    case "5":
                        CalculatePercentile();
                        break;

                    default:
                        break;
                };
            }
            while (!"exit".Equals(command));
        }

        static void CalculateAverage()
        {
            var result = 0f;
            int sum = 0;

            for (int i = 0; i < Data.Count; i++)
            {
                sum += Data[i];
                result = (float)sum / Data.Count;
            }

            Console.WriteLine("Average: " + result);
        }

        static void CalculateMax()
        {
            var result = 0f;
            int max = 0;


            for (int i = 0; i < Data.Count; i++)
            {
                if (max < Data[i])
                {
                    max = Data[i];
                    result = max;
                }


            }

            Console.WriteLine("Max: " + result);
        }

        static void CalculateMin()
        {
            var result = 0f;
            int min = int.MaxValue;


            for (int i = 0; i < Data.Count; i++)
            {
                if (min > Data[i])
                {
                    min = Data[i];
                    result = min;
                }


            }

            Console.WriteLine("Min: " + result);
        }

        static void CalculateMedian()

        {
            int temp = 0;
            if (Data.Count % 2 != 0)
            {
                for (int i = 0; i < Data.Count - 1; i++)
                {
                    for (int j = i + 1; j < Data.Count; j++)
                    {
                        if (Data[i] > Data[j])
                        {
                            temp = Data[i];
                            Data[i] = Data[j];
                            Data[j] = temp;
                        }
                    }
                }

                Console.WriteLine(Data[(Data.Count / 2)]);
                
            }
            else
            {
                
                for (int i = 0; i < Data.Count - 1; i++)
                {
                    for (int j = i + 1; j < Data.Count; j++)
                    {
                        if (Data[i] > Data[j])
                        {
                            temp = Data[i];
                            Data[i] = Data[j];
                            Data[j] = temp;
                        }
                    }
                }
                //Console.WriteLine("Вывод отсортированного массива");
                //for (int i = 0; i < Data.Count; i++)
                //{
                //    Console.WriteLine(Data[i]);
                //}
                var position1 = Data.Count / 2 - 1;
                var position2 = Data.Count / 2;
                Console.WriteLine((Data[position1] + Data[position2])/2);
                // Console.WriteLine(Data[(((Data.Count / 2 - 1) + Data.Count / 2))]);
            }
        }
        static void CalculatePercentile()

        {
            int temp = 0;
            
            {
                for (int i = 0; i < Data.Count - 1; i++)
                {
                    for (int j = i + 1; j < Data.Count; j++)
                    {
                        if (Data[i] > Data[j])
                        {
                            temp = Data[i];
                            Data[i] = Data[j];
                            Data[j] = temp;
                        }
                    }
                }

               
            }

            var n = 0f;
            n = (90f / 100f) * Data.Count - 1;
            int result = (int)n;
            Console.WriteLine(Data[result]);
            //Console.WriteLine("Вывод отсортированного массива");
            //for (int i = 0; i < Data.Count; i++)
            //{
            //    Console.WriteLine(Data[i]);
            }

        }
        
    
}