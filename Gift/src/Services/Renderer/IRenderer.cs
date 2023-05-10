using Gift.UI.Display;

namespace Gift.UI.Render
{
    public interface IRenderer
    {
        IScreenDisplay GetRenderDisplay(IGiftUI ui);
    }
}