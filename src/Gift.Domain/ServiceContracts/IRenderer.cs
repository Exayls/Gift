using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Display;

namespace Gift.Domain.ServiceContracts
{
    public interface IRenderer
    {
        IScreenDisplay GetRenderDisplay(GiftUI ui);
    }
}
