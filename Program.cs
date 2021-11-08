using System;
using System.Collections.Generic;
using System.Linq;

namespace GAInitialisePopulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = initialPopulation(100);

            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(i + " [{0}]", string.Join(", ", array[i]));

                Console.WriteLine(Environment.NewLine);
            }

        }

        public static List<int[]> initialPopulation(int popSize)
        {
            var arrayList = new List<int[]>();
            int Min = 1;
            int Max = 50;

            Random randNum = new Random();

            for (int i = 0; i < popSize; i++)
            {
                arrayList.Add(Enumerable
                    .Repeat(0, 10)
                    .Select(i => randNum.Next(Min, Max))
                    .ToArray());
            }

            return arrayList;
        }
    }
}
