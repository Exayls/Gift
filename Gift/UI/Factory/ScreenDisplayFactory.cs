using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI.Factory
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