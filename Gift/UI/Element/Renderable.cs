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
        IScreenDisplay GetDisplayWithoutBorder(Bound bounds);
        IScreenDisplay GetDisplayWithoutBorder(Bound bounds, Color frontColor, Color BackColor);
        IScreenDisplay GetDisplayBorder(Bound bounds);
        IScreenDisplay GetDisplayBorder(Bound bounds, Color frontColor, Color BackColor);
        Position GetGlobalPosition(Context context);
        Position GetRelativePosition(Context context);
        bool IsFixed();
    }
}