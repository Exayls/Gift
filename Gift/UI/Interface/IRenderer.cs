namespace Gift.UI.Interface
{
    public interface IRenderer
    {
        TextWriter GetRenderedBuffer(IGiftUI giftUI);
        TextWriter GetRenderedBuffer(IGiftUI giftUI, IScreenDisplay screen);
    }
}