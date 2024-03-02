using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.Border
{
    public interface IBorder
    {
        int Thickness { get; }

        public IScreenDisplay GetDisplay(Bound bound, char fillingChar = ' ');
        public IScreenDisplay GetDisplay(Bound bound, Color frontColor, Color backColor, char fillingChar = ' ');
        public bool Equals(IBorder border);
    }
}
