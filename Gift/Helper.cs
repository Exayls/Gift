using Gift.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift
{
    internal class Helper
    {

        public static string Replace(string s, string replace, int index)
        {
            return s.Remove(index, replace.Length).Insert(index, replace);
        }
        public static void Replace(StringBuilder s, string replace, int index)
        {
            s.Remove(index, replace.Length).Insert(index, replace);
        }
    }
}
