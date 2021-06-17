using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace BenfordLab
{
    public class BenfordData
    {
        public int Digit { get; set; }
        public int Count { get; set; }

        public BenfordData()
        { }
    }

    public class Benford
    {
        public static IEnumerable<BenfordData> D2 { get; private set; }

        public static BenfordData[] CalculateBenford(string csvFilePath)
        {
            // load the data
            var data = File.ReadAllLines(csvFilePath)
                .Skip(1) // For header
                .Select(s => Regex.Match(s, @"^(.*?),(.*?)$"))
                .Select(data => new
                {
                    Country = data.Groups[1].Value,
                    Population = int.Parse(data.Groups[2].Value)
                    
                });
            int ki = 0;
            foreach (var s in data)
            {
                ki++;
            }

            int[] arr = new int[ki];
            int j = 0;
            foreach (var s in data)
            {
              arr[j]=FirstDigit.getFirstDigit(s.Population);
                j++;    
            }
            List<BenfordData> D = new List<BenfordData>();
            for (int i = 1; i < 10; i++)
            {
                int x1 = 0;
                for(int x=0;x<arr.Length;x++)
                {
                    if( i ==arr[x])
                    {
                        x1++;
                    }
                }
                D.Add(new BenfordData
                {
                    Digit = i,
                    Count = x1
                }) ;
                D.Concat(D);
            }
            var m = D;

            return m.ToArray();
        }
    }
}
