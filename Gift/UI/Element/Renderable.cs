using Gift.UI.Display;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI.Element
{
    public interface Renderable
    {
        int Height { get; }
        int Width { get; }

        IScreenDisplay GetDisplay(Bound bound);
        Position GetGlobalPosition(Context context);
        bool IsFixed();
    }
}