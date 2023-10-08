using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.MetaData;
using Gift.UI.Conf;
using Gift.UI.Display;

namespace Gift.Domain.UIModel.Element
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
