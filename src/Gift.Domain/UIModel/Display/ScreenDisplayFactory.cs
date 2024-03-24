using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.Display
{
    public class ScreenDisplayFactory : IScreenDisplayFactory
    {

        public IScreenDisplay Create(Size bound, Color frontColor, Color backColor, char emptyChar)
        {
            return new ScreenDisplay(bound, frontColor, backColor, emptyChar);
        }
    }
}
