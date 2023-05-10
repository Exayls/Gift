using Newtonsoft.Json;

namespace Gift.UI.Border
{
    public class BorderChars
    {
        public char tlBorder { get; }
        public char trBorder { get; }
        public char blBorder { get; }
        public char brBorder { get; }
        public char tBorder { get; }
        public char bBorder { get; }
        public char lBorder { get; }
        public char rBorder { get; }
        public BorderChars(char ulBorder, char urBorder, char dlBorder, char drBorder,
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
        public static BorderChars GetBorderCharsFromFile(string file)
        {
            string json = File.ReadAllText(file);
            dynamic? borderChars = JsonConvert.DeserializeObject(json);

            char topLeft = borderChars?.BorderChars.TopLeft?? ' ';
            char topRight = borderChars?.BorderChars.TopRight?? ' ';
            char bottomLeft = borderChars?.BorderChars.BottomLeft?? ' ';
            char bottomRight = borderChars?.BorderChars.BottomRight?? ' ';
            char top = borderChars?.BorderChars.Top?? ' ';
            char bottom = borderChars?.BorderChars.Bottom?? ' ';
            char right = borderChars?.BorderChars.Right?? ' ';
            char left = borderChars?.BorderChars.Left?? ' ';

            return new BorderChars(topLeft, topRight, bottomLeft, bottomRight, top, bottom, left, right);
        }

    }
}