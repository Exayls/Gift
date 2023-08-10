using System.IO;
using Newtonsoft.Json;

namespace Gift.UI.Border
{
    public class BorderOption
    {
        public static BorderOption Default { get { return GetBorderCharsFromFile("ressources/borderchars/simple_border.json"); } }
        public static BorderOption Simple { get { return GetBorderCharsFromFile("ressources/borderchars/simple_border.json"); } }
        public static BorderOption Heavy { get { return GetBorderCharsFromFile("ressources/borderchars/heavy_border.json"); } }
        public char tlBorder { get; }
        public char trBorder { get; }
        public char blBorder { get; }
        public char brBorder { get; }
        public char tBorder { get; }
        public char bBorder { get; }
        public char lBorder { get; }
        public char rBorder { get; }

        public BorderOption(char ulBorder, char urBorder, char dlBorder, char drBorder,
            char uBorder, char dBorder, char lBorder, char rBorder)
        {
            this.tlBorder = ulBorder;
            this.trBorder = urBorder;
            this.blBorder = dlBorder;
            this.brBorder = drBorder;
            this.tBorder = uBorder;
            this.bBorder = dBorder;
            this.lBorder = lBorder;
            this.rBorder = rBorder;
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
