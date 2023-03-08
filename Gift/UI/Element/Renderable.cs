using Gift.UI.Display;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI.Element
{
    public interface IRenderable
    {
        int Height { get; }
        int Width { get; }

        IScreenDisplay GetDisplay(Bound bound);
        Position GetGlobalPosition(Context context);
        Position GetRelativePosition(Context context);
        bool IsFixed();
    }
}