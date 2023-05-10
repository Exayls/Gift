using Gift.UI.Display;
using Gift.UI.MetaData;

namespace Gift.UI.Border
{
    public class NoBorder : IBorder
    {
        public int Thickness { get; }
        public char BorderChar { get; }

        public NoBorder()
        {
            BorderChar = ' ';
            Thickness = 0;
        }

        public IScreenDisplay GetDisplay(Bound bound)
        {
            return new ScreenDisplay(bound);
        }

        public IScreenDisplay GetDisplay(Bound bound, char fillingChar)
        {
            return new ScreenDisplay(bound, emptychar: fillingChar);
        }

        public IScreenDisplay GetDisplay(Bound bound, Color frontColor, Color backColor, char fillingChar = ' ')
        {
            return new ScreenDisplay(bound,frontColor, backColor, fillingChar);
        }
    }
}