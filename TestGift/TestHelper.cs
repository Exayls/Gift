using Gift.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift
{
    public class TestHelper
    {
        public static List<string> GetElementString(Label element)
        {
            List<string> output = new List<string>();
            output.Add(element.GetDisplay());
            return output;
        }

        public static List<string> GetElementString(Container element)
        {
            List<string> output = new List<string>();
            for (int lineNumber = 0; lineNumber < (element?.Context?.Bounds?.Height ?? 0); lineNumber++)
            {
                //output.Add(element)
            }
            return output;
        }
        public static string Replace(string s, string replace, int index)
        {
            return s.Remove(index, replace.Length).Insert(index, replace);
        }
    }
}
