using System.IO;
using Newtonsoft.Json;

namespace Gift.Domain.UIModel.Border

{
    public class BorderOption
    {

        public static BorderOption Default => GetBorderCharsFromFile("ressources/borderchars/simple_border.json");
        public static BorderOption Simple => GetBorderCharsFromFile("ressources/borderchars/simple_border.json");
        public static BorderOption Heavy => GetBorderCharsFromFile("ressources/borderchars/heavy_border.json");

        public char TlBorder { get; }
        public char TrBorder { get; }
        public char BlBorder { get; }
        public char BrBorder { get; }
        public char TBorder { get; }
        public char BBorder { get; }
        public char LBorder { get; }
        public char RBorder { get; }

        public BorderOption(char ulBorder, char urBorder, char dlBorder, char drBorder, char uBorder, char dBorder,
                            char lBorder, char rBorder)
        {
            TlBorder = ulBorder;
            TrBorder = urBorder;
            BlBorder = dlBorder;
            BrBorder = drBorder;
            TBorder = uBorder;
            BBorder = dBorder;
            LBorder = lBorder;
            RBorder = rBorder;
        }

        public BorderOption(char borderChar)
            : this(borderChar, borderChar, borderChar, borderChar, borderChar,
                   borderChar, borderChar, borderChar)
        {
        }

        public static BorderOption GetBorderCharsFromFile(string file)
        {
            string json = File.ReadAllText(file);
            dynamic? borderChars = JsonConvert.DeserializeObject(json);

            char topLeft = borderChars?.BorderChars.TopLeft ?? ' ';
            char topRight = borderChars?.BorderChars.TopRight ?? ' ';
            char bottomLeft = borderChars?.BorderChars.BottomLeft ?? ' ';
            char bottomRight = borderChars?.BorderChars.BottomRight ?? ' ';
            char top = borderChars?.BorderChars.Top ?? ' ';
            char bottom = borderChars?.BorderChars.Bottom ?? ' ';
            char right = borderChars?.BorderChars.Right ?? ' ';
            char left = borderChars?.BorderChars.Left ?? ' ';

            return new BorderOption(topLeft, topRight, bottomLeft, bottomRight, top, bottom, left, right);
        }
    }
}
