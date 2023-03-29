using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI.Display
{
    public class ScreenDisplay : IScreenDisplay
    {
        public Color FrontColor { get; set; }
        public Color BackColor { get; set; }

        private Color[,] frontColorMap;
        private Color[,] backColorMap;

        public Bound TotalBound { get; }
        public StringBuilder DisplayString { get; }


        public ScreenDisplay(string display, Color frontColor = Color.White, Color backColor = Color.Black) : this(new(1, display.Length),frontColor, backColor, GiftBase.FILLINGCHAR)
        {
            DisplayString.Clear().Append(display);
        }

        public ScreenDisplay(Bound bound, Color frontColor = Color.White, Color backColor = Color.Black, char emptychar = GiftBase.FILLINGCHAR)
        {
            DisplayString = new StringBuilder();
            TotalBound = bound;
            FillDisplay(emptychar);

            FrontColor = frontColor;
            BackColor = backColor;

            frontColorMap = new Color[bound.Height, bound.Width];
            backColorMap = new Color[bound.Height, bound.Width];
            fillColor(frontColorMap, frontColor);
            fillColor(backColorMap, backColor);
        }

        public void fillColor(Color[,] colormap, Color color)
        {
            for (int i = 0; i < colormap.GetLength(0); i++)
            {
                for (int j = 0; j < colormap.GetLength(1); j++)
                {
                    colormap[i, j] = color;
                }
            }
        }
        private void FillDisplay(char emptychar)
        {
            DisplayString.Append(new string(emptychar, TotalBound.Width));
            for (int i = 1; i < TotalBound.Height; i++)
            {
                DisplayString.Append('\n');
                DisplayString.Append(new string(emptychar, TotalBound.Width));
            }
        }

        public void AddDisplay(IScreenDisplay display, Position globalPosition)
        {
            for (int i = 0; i < display.TotalBound.Height; i++)
            {
                bool ShouldAddLine = globalPosition.x <= TotalBound.Width
                    && globalPosition.y + i + 1 <= TotalBound.Height
                    && globalPosition.y + i >= 0;
                if (ShouldAddLine)
                {
                    AddLineToDisplay(display, globalPosition, i);
                }
            }
        }

        private void AddLineToDisplay(IScreenDisplay display, Position position, int i)
        {
            int indexLineToReplace = (position.y + i) * (TotalBound.Width + 1) + position.x;
            int indexWidthToReplace = position.x;
            int lenghtToReplace = display.TotalBound.Width;
            if (position.x + display.TotalBound.Width > TotalBound.Width)
            {
                lenghtToReplace = TotalBound.Width - position.x;
            }
            else if (position.x < 0)
            {
                indexLineToReplace = (position.y + i) * (TotalBound.Width + 1);
                indexWidthToReplace = 0;
                lenghtToReplace = display.TotalBound.Width + position.x;
            }
            DisplayString.Remove(indexLineToReplace, lenghtToReplace);

            string lineToInsert = display.GetLine(i);
            string stringToInsert = lineToInsert.Substring(0, lenghtToReplace);

            FillColorMapAtPosition(display, position, i, indexLineToReplace, indexWidthToReplace, lenghtToReplace);
            DisplayString.Insert(indexLineToReplace, stringToInsert);
        }

        private void FillColorMapAtPosition(IScreenDisplay display, Position position, int i, int indexLineToReplace, int indexWidthToReplace, int lenghtToReplace)
        {
            for (int j = indexLineToReplace; j < lenghtToReplace; j++)
            {
                frontColorMap[position.y + i, indexWidthToReplace + j] = display.FrontColor;
                backColorMap[position.y + i, indexWidthToReplace + j] = display.BackColor;
            }
        }

        public string GetLine(int i)
        {
            return DisplayString.ToString().Split('\n')[i];
        }

        public void AddString(string display, Position position)
        {
            ScreenDisplay tmpScreen = new ScreenDisplay(display);
            AddDisplay(tmpScreen, position);
        }

        public void AddChar(char display, Position position)
        {
            ScreenDisplay tmpScreen = new ScreenDisplay(display.ToString());
            AddDisplay(tmpScreen, position);
        }
    }
}