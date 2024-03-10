using Gift.Domain.Builders.UIModel.Display;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;

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

        public bool IsSimilarTo(IBorder border)
        {
            if (!(border is SimpleBorder))
                return false;
            if (Thickness != border.Thickness)
                return false;
            var simpleBorder = (SimpleBorder)border;
            if (BorderChar != simpleBorder.BorderChar)
                return false;
            return true;
        }

        public IScreenDisplay GetDisplay(ScreenDisplayBuilder screenDisplayBuilder)
        {
			var screen = screenDisplayBuilder.Build();
            AddBorder(screen);
            return screen;
        }
    }
}
