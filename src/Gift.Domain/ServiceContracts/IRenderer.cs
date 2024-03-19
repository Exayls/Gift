using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;

namespace Gift.Domain.ServiceContracts
{
    public interface IRenderer
    {
        IScreenDisplay GetRenderDisplay(UIElement ui);
    }
}
