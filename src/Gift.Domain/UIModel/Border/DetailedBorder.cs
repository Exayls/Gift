﻿using Gift.Domain.Builders.UIModel.Display;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.Border
{
    public class DetailedBorder : IBorder
    {
        private readonly char tlBorder;
        private readonly char trBorder;
        private readonly char blBorder;
        private readonly char brBorder;
        private readonly char tBorder;
        private readonly char bBorder;
        private readonly char lBorder;
        private readonly char rBorder;

        public int Thickness { get; }

        public DetailedBorder(int thickness, char tlBorder, char trBorder, char blBorder, char brBorder, char tBorder,
                              char bBorder, char lBorder, char rBorder)
        {
            this.tlBorder = tlBorder;
            this.trBorder = trBorder;
            this.blBorder = blBorder;
            this.brBorder = brBorder;
            this.tBorder = tBorder;
            this.bBorder = bBorder;
            this.lBorder = lBorder;
            this.rBorder = rBorder;
            Thickness = thickness;
        }
        public DetailedBorder(int thickness, BorderOption borderChars)
        {
            this.tlBorder = borderChars.tlBorder;
            this.trBorder = borderChars.trBorder;
            this.blBorder = borderChars.blBorder;
            this.brBorder = borderChars.brBorder;
            this.tBorder = borderChars.tBorder;
            this.bBorder = borderChars.bBorder;
            this.lBorder = borderChars.lBorder;
            this.rBorder = borderChars.rBorder;
            Thickness = thickness;
        }

        private void AddBorder(IScreenDisplay screenDisplay)
        {
            for (int y = 0; y < screenDisplay.TotalBound.Height; y++)
            {
                for (int x = 0; x < screenDisplay.TotalBound.Width; x++)
                {
                    bool TopLeftBorder = IsTopLeftBorder(x, y, screenDisplay.TotalBound);
                    bool TopRightBorder = IsTopRightBorder(x, y, screenDisplay.TotalBound);
                    bool BottomLeftBorder = IsBottomLeftBorder(x, y, screenDisplay.TotalBound);
                    bool BottomRightBorder = IsBottomRightBorder(x, y, screenDisplay.TotalBound);
                    bool TopBorder = IsTopBorder(x, y, screenDisplay.TotalBound);
                    bool BottomBorder = IsBottomBorder(x, y, screenDisplay.TotalBound);
                    bool LeftBorder = IsLeftBorder(x, y, screenDisplay.TotalBound);
                    bool RightBorder = IsRightBorder(x, y, screenDisplay.TotalBound);
                    if (TopLeftBorder)
                    {
                        screenDisplay.AddChar(tlBorder, new Position(y, x));
                    }
                    else if (TopRightBorder)
                    {
                        screenDisplay.AddChar(trBorder, new Position(y, x));
                    }
                    else if (BottomLeftBorder)
                    {
                        screenDisplay.AddChar(blBorder, new Position(y, x));
                    }
                    else if (BottomRightBorder)
                    {
                        screenDisplay.AddChar(brBorder, new Position(y, x));
                    }
                    else if (TopBorder)
                    {
                        screenDisplay.AddChar(tBorder, new Position(y, x));
                    }
                    else if (BottomBorder)
                    {
                        screenDisplay.AddChar(bBorder, new Position(y, x));
                    }
                    else if (LeftBorder)
                    {
                        screenDisplay.AddChar(lBorder, new Position(y, x));
                    }
                    else if (RightBorder)
                    {
                        screenDisplay.AddChar(rBorder, new Position(y, x));
                    }
                }
            }
        }

        private bool IsTopBorder(int x, int y, Bound bound)
        {
            return (y < Thickness && y < x && y < bound.Width - x - 1);
        }

        private bool IsBottomBorder(int x, int y, Bound bound)
        {
            return (y >= bound.Height - Thickness && bound.Height - y - 1 < x &&
                    bound.Height - y - 1 < bound.Width - x - 1);
        }

        private bool IsLeftBorder(int x, int y, Bound bound)
        {
            return (x < Thickness && x < y && x < bound.Height - y - 1);
        }

        private bool IsRightBorder(int x, int y, Bound bound)
        {
            return x >= bound.Width - Thickness && bound.Width - x - 1 < y &&
                   bound.Width - x - 1 < bound.Height - y - 1;
        }

        private bool IsBottomLeftBorder(int x, int y, Bound bound)
        {
            return (x < Thickness && y >= bound.Height - Thickness && x == bound.Height - y - 1);
        }

        private bool IsBottomRightBorder(int x, int y, Bound bound)
        {
            return (x >= bound.Width - Thickness && y >= bound.Height - Thickness &&
                    bound.Width - x - 1 == bound.Height - y - 1);
        }

        private bool IsTopLeftBorder(int x, int y, Bound bound)
        {
            return (x < Thickness && y < Thickness && x == y);
        }

        private bool IsTopRightBorder(int x, int y, Bound bound)
        {
            return (y < Thickness && x >= bound.Width - Thickness && bound.Width - x - 1 == y);
        }

        private bool IsBorder(int x, int y, Bound bound)
        {
            return x < Thickness || y < Thickness || x >= bound.Width - Thickness || y >= bound.Height - Thickness;
        }

        public bool IsSimilarTo(IBorder border)
        {
            if (!(border is DetailedBorder))
                return false;
            if (Thickness != border.Thickness)
                return false;
            var detailedBorder = (DetailedBorder)border;

            if (tlBorder != detailedBorder.tlBorder)
                return false;
            if (trBorder != detailedBorder.trBorder)
                return false;
            if (blBorder != detailedBorder.blBorder)
                return false;
            if (brBorder != detailedBorder.brBorder)
                return false;
            if (tBorder != detailedBorder.tBorder)
                return false;
            if (bBorder != detailedBorder.bBorder)
                return false;
            if (lBorder != detailedBorder.lBorder)
                return false;
            if (rBorder != detailedBorder.rBorder)
                return false;

            return true;
        }

        public IScreenDisplay GetDisplay(ScreenDisplayBuilder screenDisplayBuilder)
        {
            IScreenDisplay screenDisplay = screenDisplayBuilder.Build();
            AddBorder(screenDisplay);
            return screenDisplay;
        }
    }
}
