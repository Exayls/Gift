using Gift.UI.MetaData;

namespace Gift.UI.Display
{
    public class ScreenDisplayFactory : IScreenDisplayFactory
    {
        public IScreenDisplay Create(Bound bound)
        {
            return new ScreenDisplay(bound);
        }
        public IScreenDisplay Create(Bound bound, char emptyChar)
        {
            return new ScreenDisplay(bound, emptychar: emptyChar);
        }

        public IScreenDisplay Create(Bound bound, Color frontColor, Color backColor, char emptyChar)
        {
            return new ScreenDisplay(bound,frontColor, backColor, emptyChar);
        }
    }
}