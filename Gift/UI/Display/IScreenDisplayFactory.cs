using Gift.UI.MetaData;

namespace Gift.UI.Display
{
    public interface IScreenDisplayFactory
    {
        IScreenDisplay Create(Bound bound);
        IScreenDisplay Create(Bound bound, char emptyChar);
        IScreenDisplay Create(Bound boundEmptyVStack, Color frontColor, Color backColor, char fILLINGCHAR);
    }
}