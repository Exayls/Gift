using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI.Display
{
    public class ScreenDisplay : IScreenDisplay
    {
        private Color frontColor;
        private Color backColor;

        public Color[,] FrontColorMap { get; }
        public Color[,] BackColorMap { get; }

        public Bound TotalBound { get; }
        public StringBuilder DisplayString { get; }
        public char[,] DisplayMap { get; }


        public ScreenDisplay(string display, Color frontColor = Color.White, Color backColor = Color.Black) : this(new(1, display.Length), frontColor, backColor, GiftBase.FILLINGCHAR)
        {
            DisplayString.Clear().Append(display);
        }

        public ScreenDisplay(Bound bound, Color frontColor = Color.White, Color backColor = Color.Black, char emptychar = GiftBase.FILLINGCHAR)
        {
            DisplayString = new StringBuilder();
            TotalBound = bound;
            FillDisplay(emptychar);

            FrontColorMap = new Color[bound.Height, bound.Width];
            BackColorMap = new Color[bound.Height, bound.Width];
            DisplayMap = new char[bound.Height, bound.Width];

            fillColor(FrontColorMap, frontColor);
            fillColor(BackColorMap, backColor);
            fillDisplayMap(DisplayMap, emptychar);

            this.frontColor = frontColor;
            this.backColor = backColor;
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
        public void fillDisplayMap(char[,] displaymap, char emptychar)
        {
            for (int i = 0; i < displaymap.GetLength(0); i++)
            {
                for (int j = 0; j < displaymap.GetLength(1); j++)
                {
                    displaymap[i, j] = emptychar;
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
            DisplayString.Insert(indexLineToReplace, stringToInsert);

            FillColorMapAtPosition(display, position, i, indexLineToReplace, indexWidthToReplace, lenghtToReplace);
            FillDisplayMapAtPosition(position, i, indexLineToReplace, indexWidthToReplace, lenghtToReplace, stringToInsert);
        }

        private void FillColorMapAtPosition(IScreenDisplay display, Position position, int i, int indexLineToReplace, int indexWidthToReplace, int lenghtToReplace)
        {
            for (int j = 0; j < lenghtToReplace; j++)
            {
                FrontColorMap[position.y + i, indexWidthToReplace + j] = display.FrontColorMap[i, j];
                BackColorMap[position.y + i, indexWidthToReplace + j] = display.BackColorMap[i, j];
            }
        }

        private void FillDisplayMapAtPosition(Position position, int i, int indexLineToReplace, int indexWidthToReplace, int lenghtToReplace, string stringToInsert)
        {
            for (int j = 0; j < lenghtToReplace; j++)
            {
                DisplayMap[position.y + i, indexWidthToReplace + j] = stringToInsert[j];
            }
        }

        public string GetLine(int i)
        {
            return DisplayString.ToString().Split('\n')[i];
        }

        public void AddString(string display, Position position)
        {
            ScreenDisplay tmpScreen = new ScreenDisplay(display,frontColor,backColor);
            AddDisplay(tmpScreen, position);
        }

        public void AddChar(char display, Position position)
        {
            ScreenDisplay tmpScreen = new ScreenDisplay(display.ToString(),frontColor, backColor);
            AddDisplay(tmpScreen, position);
        }
    }
}
