using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.MetaData;
using System.Linq;
using System.Text;

namespace Gift.Domain.UIModel.Display
{
    public class ScreenDisplay : IScreenDisplay
    {
        public Color[,] FrontColorMap { get; }
        public Color[,] BackColorMap { get; }
        public StringBuilder DisplayString { get; }

        private Color frontColor;
        private Color backColor;


        public Bound TotalBound { get; }
        public char[,] DisplayMap { get; }

        public ScreenDisplay(string display, Color frontColor = Color.White, Color backColor = Color.Transparent)
            : this(new(1, display.Length), frontColor, backColor, '*')
        {
            DisplayString.Clear().Append(display);
        }

        public ScreenDisplay(Bound bound, Color frontColor = Color.White, Color backColor = Color.Transparent,
                             char emptychar = '*')
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
                bool ShouldAddLine = globalPosition.x <= TotalBound.Width &&
                                     globalPosition.y + i + 1 <= TotalBound.Height && globalPosition.y + i >= 0;
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
            FillDisplayMapAtPosition(position, i, indexLineToReplace, indexWidthToReplace, lenghtToReplace,
                                     stringToInsert);
        }

        private void FillColorMapAtPosition(IScreenDisplay display, Position position, int i, int indexLineToReplace,
                                            int indexWidthToReplace, int lenghtToReplace)
        {
            for (int j = 0; j < lenghtToReplace; j++)
            {
                FrontColorMap[position.y + i, indexWidthToReplace + j] = display.FrontColorMap[i, j];
                BackColorMap[position.y + i, indexWidthToReplace + j] = display.BackColorMap[i, j];
            }
        }

        private void FillDisplayMapAtPosition(Position position, int i, int indexLineToReplace, int indexWidthToReplace,
                                              int lenghtToReplace, string stringToInsert)
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
            ScreenDisplay tmpScreen = new ScreenDisplay(display, frontColor, backColor);
            AddDisplay(tmpScreen, position);
        }

        public void AddChar(char display, Position position)
        {
            ScreenDisplay tmpScreen = new ScreenDisplay(display.ToString(), frontColor, backColor);
            AddDisplay(tmpScreen, position);
        }

        private bool CheckEquality<T>(T[,] t1, T[,] t2)
        {
            var equal =
                t1.Rank == t2.Rank &&
                Enumerable.Range(0, t1.Rank).All(dimension => t1.GetLength(dimension) == t2.GetLength(dimension)) &&
                t1.Cast<double>().SequenceEqual(t2.Cast<double>());
            return equal;
        }

        public bool Equals(ScreenDisplay other)
        {
            bool sameBackColor = CheckEquality<Color>(other.BackColorMap, this.BackColorMap);
            bool sameFrontColor = CheckEquality<Color>(other.FrontColorMap, this.FrontColorMap);
            bool sameChars = CheckEquality<char>(other.DisplayMap, this.DisplayMap);
            return (sameChars && sameBackColor && sameFrontColor);
        }


        public void AddBorder(int thickness, BorderOption borderChars)
        {
            for (int y = 0; y < TotalBound.Height; y++)
            {
                for (int x = 0; x < TotalBound.Width; x++)
                {
                    bool TopLeftBorder = IsTopLeftBorder(x, y, thickness);
                    bool TopRightBorder = IsTopRightBorder(x, y, thickness);
                    bool BottomLeftBorder = IsBottomLeftBorder(x, y, thickness);
                    bool BottomRightBorder = IsBottomRightBorder(x, y, thickness);
                    bool TopBorder = IsTopBorder(x, y, thickness);
                    bool BottomBorder = IsBottomBorder(x, y, thickness);
                    bool LeftBorder = IsLeftBorder(x, y, thickness);
                    bool RightBorder = IsRightBorder(x, y, thickness);
                    if (TopLeftBorder)
                    {
                        AddChar(borderChars.tlBorder, new Position(y, x));
                    }
                    else if (TopRightBorder)
                    {
                        AddChar(borderChars.trBorder, new Position(y, x));
                    }
                    else if (BottomLeftBorder)
                    {
                        AddChar(borderChars.blBorder, new Position(y, x));
                    }
                    else if (BottomRightBorder)
                    {
                        AddChar(borderChars.brBorder, new Position(y, x));
                    }
                    else if (TopBorder)
                    {
                        AddChar(borderChars.tBorder, new Position(y, x));
                    }
                    else if (BottomBorder)
                    {
                        AddChar(borderChars.bBorder, new Position(y, x));
                    }
                    else if (LeftBorder)
                    {
                        AddChar(borderChars.lBorder, new Position(y, x));
                    }
                    else if (RightBorder)
                    {
                        AddChar(borderChars.rBorder, new Position(y, x));
                    }
                }
            }
        }

        private bool IsTopBorder(int x, int y, int thickness)
        {
            return (y < thickness && y < x && y < TotalBound.Width - x - 1);
        }

        private bool IsBottomBorder(int x, int y, int thickness)
        {
            return (y >= TotalBound.Height - thickness && TotalBound.Height - y - 1 < x &&
                    TotalBound.Height - y - 1 < TotalBound.Width - x - 1);
        }

        private bool IsLeftBorder(int x, int y, int thickness)
        {
            return (x < thickness && x < y && x < TotalBound.Height - y - 1);
        }

        private bool IsRightBorder(int x, int y, int thickness)
        {
            return x >= TotalBound.Width - thickness && TotalBound.Width - x - 1 < y &&
                   TotalBound.Width - x - 1 < TotalBound.Height - y - 1;
        }

        private bool IsBottomLeftBorder(int x, int y, int thickness)
        {
            return (x < thickness && y >= TotalBound.Height - thickness && x == TotalBound.Height - y - 1);
        }

        private bool IsBottomRightBorder(int x, int y, int thickness)
        {
            return (x >= TotalBound.Width - thickness && y >= TotalBound.Height - thickness &&
                    TotalBound.Width - x - 1 == TotalBound.Height - y - 1);
        }

        private bool IsTopLeftBorder(int x, int y, int thickness)
        {
            return (x < thickness && y < thickness && x == y);
        }

        private bool IsTopRightBorder(int x, int y, int thickness)
        {
            return (y < thickness && x >= TotalBound.Width - thickness && TotalBound.Width - x - 1 == y);
        }

        private bool IsBorder(int x, int y, int thickness)
        {
            return x < thickness || y < thickness || x >= TotalBound.Width - thickness || y >= TotalBound.Height - thickness;
        }
    }
}
