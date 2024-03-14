using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.Element
{
    public interface Renderable
    {
        int Height { get; }
        int Width { get; }
        IBorder Border { get; set; }

        IScreenDisplay GetDisplayWithoutBorder(Bound bounds, IConfiguration configuration);
        IScreenDisplay GetDisplayBorder(Bound bounds, IConfiguration configuration, IColorResolver _colorResolver);
        IScreenDisplay GetDisplayBorder(Bound bounds, IConfiguration configuration);
        Position GetRelativePosition(Context context);
        bool IsFixed();
    }
}
