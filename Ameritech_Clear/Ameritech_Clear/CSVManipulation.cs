using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ameritech_Clear
{
    public static class CSVManipulation
    {
        public static long SplitAndAdd(List<string> lines)
        {            
            long returnVar = 0;
            int intVar = 0;
            long longVar = 0;
           
            for (int i = 0; i < lines.Count; i++) //iterates through the list and seperates the data, and stores them.
            {

                String[] Cells = lines[i].Split(',');

                for (int z = 0; z < Cells.Length; z++)
                {
                    if (int.TryParse(Cells[z], out intVar))
                    {
                        returnVar = intVar + returnVar;
                        
                    }
                    else if (long.TryParse(Cells[z], out longVar))
                    {
                        returnVar = longVar + returnVar;
                    }                   
                }                
            }
            return returnVar;            
        }

        public static string TenTrimmer(long total) //trims down the number to the last ten digits. 
        {
            if(total.ToString().ToArray().Length >= 10)
            {
                var @throw = total.ToString().ToCharArray();
                var @catch = new List<char>();
                for (int i = @throw.Length - 10; i < @throw.Length; i++)
                {
                    @catch.Add(@throw[i]);
                }
                var str = new string(@catch.ToArray());
                return str;
            }
            else
            {
                return total.ToString();
            }
           
        }


    }
}
