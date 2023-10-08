using Gift.UI.Display;
using Gift.UI.MetaData;

namespace Gift.Domain.UIModel.Border
{
    public class SimpleBorder : IBorder
    {
        public char BorderChar { get; }
        public int Thickness { get; }


        public SimpleBorder(int thickness, char borderChar)
        {
            BorderChar = borderChar;
            Thickness = thickness;
        }

        public IScreenDisplay GetDisplay(Bound bound, char fillingChar = ' ')
        {
            IScreenDisplay screenDisplay = new ScreenDisplay(bound, emptychar: fillingChar);
            AddBorder(screenDisplay);
            return screenDisplay;
        }
        public IScreenDisplay GetDisplay(Bound bound, Color frontColor, Color backColor, char fillingChar = ' ')
        {
            IScreenDisplay screenDisplay = new ScreenDisplay(bound,frontColor,backColor, emptychar: fillingChar);
            AddBorder(screenDisplay);
            return screenDisplay;
        }


        private void AddBorder(IScreenDisplay screenDisplay)
        {
            for (int y = 0; y < screenDisplay.TotalBound.Height; y++)
            {
                for (int x = 0; x < screenDisplay.TotalBound.Width; x++)
                {
                    bool isborder = IsBorder(x, y, screenDisplay.TotalBound);
                    if (isborder)
                    {
                        screenDisplay.AddChar(BorderChar, new Position(y, x));
                    }
                }
            }
        }

        private bool IsBorder(int x, int y, Bound bound)
        {
            return x < Thickness || y < Thickness || x >= bound.Width - Thickness || y >= bound.Height - Thickness;
        }

    }
}
