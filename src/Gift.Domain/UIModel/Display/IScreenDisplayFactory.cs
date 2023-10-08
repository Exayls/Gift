using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.Display
{
    public interface IScreenDisplayFactory
    {
        IScreenDisplay Create(Bound boundEmptyVStack, Color frontColor = Color.White, Color backColor = Color.Black, char fillingChar = '*');
    }
}
