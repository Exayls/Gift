using Gift.UI.Display;

namespace Gift.UI
{
    public interface IRenderer
    {
        IScreenDisplay GetRenderDisplay(IGiftUI ui);
    }
}