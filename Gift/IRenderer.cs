using Gift.UI;

namespace Gift
{
    public interface IRenderer
    {
        TextWriter GetRenderedBuffer(IGiftUI giftUI);
        TextWriter GetRenderedBuffer(IGiftUI giftUI, IScreenDisplay screen);
    }
}