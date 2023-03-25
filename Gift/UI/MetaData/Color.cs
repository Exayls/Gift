using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift.UI.MetaData
{
    public enum Color
    {
        Black,
        Red,
        Green,
        Yellow,
        Blue,
        Magenta,
        Cyan,
        White
    }

    public static class ConsoleColorExExtensions
    {
        public static string GetForegroundEscapeCode(this Color color)
        {
            return $"\u001b[{(int)color + 30}m";
        }

        public static string GetBackgroundEscapeCode(this Color color)
        {
            return $"\u001b[{(int)color + 40}m";
        }
    }
}
