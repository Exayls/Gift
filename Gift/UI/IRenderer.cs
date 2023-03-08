using Gift.UI.Display;

namespace Gift.UI
{
    public interface IRenderer
    {
        TextWriter GetRenderedBuffer(IGiftUI giftUI);
        TextWriter GetRenderedBuffer(IGiftUI giftUI, IScreenDisplay screen);
    }
}