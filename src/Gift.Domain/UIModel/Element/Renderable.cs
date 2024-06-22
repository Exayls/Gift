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
        string Id { get; }

        IScreenDisplay GetDisplayBorder(IConfiguration configuration, IColorResolver _colorResolver, IElementSizeCalculator sizeCalculator);
        IScreenDisplay GetDisplayWithoutBorder(IConfiguration configuration, IColorResolver colorResolver, IElementSizeCalculator sizeCalculator);
        Position GetRelativePosition(Position position);
        bool HasNoSize();
    }
}
