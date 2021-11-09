using System;
using System.Collections.Generic;
using System.Linq;

namespace GAInitialisePopulation
{
    class Program
    {
        static int filled = 0;
        static List<Bin> bins = new List<Bin>();
        static Bin bin = new Bin();

        static void Main(string[] args)
        {
            int[] initialArray = { 20, 10, 4, 3, 35, 1, 2, 8, 7, 4 };

            fillBins(initialArray);

            for (int i = 0; i < bins.Count; i++)
            {
                var bin = bins[i];

                Console.WriteLine("Bin: " + i + ", mbushur: " + bin.elementet.Sum(q=>q.value));

                for (int j = 0; j < bin.elementet.Count; j++)
                {
                    Console.WriteLine("Vlera elementit: {0}", bin.elementet[j].value);
                }

            }
        }


        public static void fillBins(int[] array)
        {
            for (int i = 0; i < 100; i++)
            {
                generateSolution(array);
            }
        }

        public static void generateSolution(int[] array)
        {
            Random r = new Random();

            array = array.OrderBy(x => r.Next()).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                AddElement(i, array[i]);
            }
        }

        public static void AddElement(int id, int value)
        {
            if (filled + value <= 50)
            {
                filled += value;
                bin.elementet.Add(new Element { id = id, value = value });

                if(!bins.Contains(bin))
                {
                    bins.Add(bin);
                }
            }
            else
            {
                bin = new Bin();
                filled = 0;
                AddElement(id, value);
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

        public class Element
        {
            public int id { get; set; }

            public int value { get; set; }
        }

        public class Bin
        {
            public Bin()
            {
                elementet = new List<Element>();
            }

            public List<Element> elementet { get; set; }
        }
    }
}
