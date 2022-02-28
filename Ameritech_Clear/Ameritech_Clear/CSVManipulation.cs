using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ameritech_Clear
{
    public static class CSVManipulation
    {
        public static List<long> SplitAndAdd(List<string> lines, List<long> rawTotal)
        {
            for (int i = 0; i < lines.Count; i++) //iterates through the list and seperates the data, and stores them.
            {
                List<long> nums = lines[i].Split(',').Select(x => long.Parse(x)).ToList();
                rawTotal.Add(nums.Sum());
            }
            return rawTotal;
        }

        public static string TenTrimmer(char[] x)
        {
            var tool = new List<char>();

            for (int i = x.Length - 10; i < x.Length; i++)
            {
                tool.Add(x[i]);
            }

            string finalTotal = new string(tool.ToArray());

            return finalTotal;
        }


    }
}
