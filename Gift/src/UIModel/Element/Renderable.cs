using Gift.UI.Border;
using Gift.UI.Conf;
using Gift.UI.Display;
using Gift.UI.MetaData;

namespace Gift.UI.Element
{
    public interface IRenderable
    {
        int Height { get; }
        int Width { get; }
        IBorder Border { get; set; }

        IScreenDisplay GetDisplayWithoutBorder(Bound bounds, IConfiguration configuration);
        IScreenDisplay GetDisplayBorder(Bound bounds, IConfiguration configuration);
        Position GetRelativePosition(Context context);
        bool IsFixed();
    }
}
