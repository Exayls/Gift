using Gift.UI.Display;

namespace Gift.UI
{
    public interface IRenderer
    {
        TextWriter GetRenderWriter(IGiftUI giftUI);
        TextWriter GetRenderWriter(IGiftUI giftUI, IScreenDisplay screen);
    }
}