using Gift.UI.MetaData;

namespace Gift.UI.Display
{
    internal class ScreenDisplayFactory : IScreenDisplayFactory
    {
        public IScreenDisplay Create(Bound bound)
        {
            return new ScreenDisplay(bound);
        }
        public IScreenDisplay Create(Bound bound, char emptyChar)
        {
            return new ScreenDisplay(bound, emptyChar);
        }
    }
}