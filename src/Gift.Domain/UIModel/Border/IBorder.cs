using Gift.UI.Display;
using Gift.UI.MetaData;

namespace Gift.Domain.UIModel.Border
{
    public interface IBorder
    {
        int Thickness { get; }

        public IScreenDisplay GetDisplay(Bound bound, char fillingChar = ' ');
        IScreenDisplay GetDisplay(Bound bound, Color frontColor, Color backColor, char fillingChar = ' ');
    }
}
