using Gift.UI.MetaData;

namespace Gift.UI.Display
{
    public interface IScreenDisplayFactory
    {
        IScreenDisplay Create(Bound bound);
        IScreenDisplay Create(Bound bound, char emptyChar);
    }
}