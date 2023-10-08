using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Display;

namespace Gift.ApplicationService.services.Renderer
{
    public interface IRenderer
    {
        IScreenDisplay GetRenderDisplay(GiftUI ui);
    }
}
