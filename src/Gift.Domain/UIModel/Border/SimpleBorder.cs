using Gift.Domain.Builders.UIModel.Display;
using Gift.Domain.UIModel.Display;

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
            // AddBorder(screen);
            screen.AddBorder(Thickness, new BorderOption(BorderChar));
            return screen;
        }
    }
}
