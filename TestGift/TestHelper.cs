using Gift.UI.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift
{
    public class TestHelper
    {
        public static string Replace(string s, string replace, int index)
        {
            return s.Remove(index, replace.Length).Insert(index, replace);
        }
    }
}
