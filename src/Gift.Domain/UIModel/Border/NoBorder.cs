using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.Border
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
            return new ScreenDisplay(bound, emptychar: fillingChar);
        }

        public IScreenDisplay GetDisplay(Bound bound, Color frontColor, Color backColor, char fillingChar = ' ')
        {
            return new ScreenDisplay(bound, frontColor, backColor, fillingChar);
        }

        public bool IsSimilarTo(IBorder border)
        {
            if (!(border is NoBorder)) return false;
            return true;
        }
    }
}
