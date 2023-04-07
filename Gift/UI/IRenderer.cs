using Gift.UI.Display;

namespace Gift.UI
{
    public interface IRenderer
    {
        IScreenDisplay GetRenderDisplay(GiftUI ui);
        TextWriter GetRenderWriter(IGiftUI giftUI);
        TextWriter GetRenderWriter(IGiftUI giftUI, IScreenDisplay screen);
    }
}