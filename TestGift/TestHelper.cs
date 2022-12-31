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
            output.Add(Label.GetVisibleText(element));
            return output;
        }

        public static List<string> GetElementString(Container element)
        {
            List<string> output = new List<string>();
            for (int lineNumber = 0; lineNumber < (element?.Context?.Bounds?.Height ?? 0); lineNumber++)
            {

            }
            return output;
        }
    }
}
