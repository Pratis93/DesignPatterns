using System;
using System.Collections.Generic;

namespace DesignPatterns.Library.Solid
{
    public class SingleResponsibilityPrinciple
    {
        public List<string> entires = new List<string>();
        static int count = 0;

        public int AddEntry(string text)
        {
            entires.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entires.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entires);
        }

        public class Persisance
        {

            public void SaveToFile(SingleResponsibilityPrinciple j, string filename, bool overwrite = false)
            {
                if (overwrite || !System.IO.File.Exists(filename))
                {
                    System.IO.File.WriteAllText(filename, j.ToString());
                }
            }
        }
        /*
        //MAIN..
             var j = new DP.Library.Solid.SingleResponsibilityPrinciple();
             {
                   j.AddEntry("Some Day");
                   j.AddEntry("I will ");

                   var p = new DP.Library.Solid.SingleResponsibilityPrinciple.Persisance();
                   string filename = @"D:\Projekty_VS\DesignPatterns\DP.Library\Solid\Text.txt";
                   p.SaveToFile(j, filename, true);
             }
       */
    }
}
