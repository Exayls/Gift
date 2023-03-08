using Gift.UI.Display;
using Gift.UI.MetaData;

namespace Gift.UI.Border
{
    public interface IBorder
    {
        int Thickness { get; }

        public IScreenDisplay GetDisplay(Bound bound);
        public IScreenDisplay GetDisplay(Bound bound, char fillingChar);
    }
}