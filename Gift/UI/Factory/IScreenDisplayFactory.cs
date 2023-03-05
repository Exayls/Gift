using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI.Factory
{
    public interface IScreenDisplayFactory
    {
        IScreenDisplay Create(Bound bound);
        IScreenDisplay Create(Bound bound, char emptyChar);
    }
}