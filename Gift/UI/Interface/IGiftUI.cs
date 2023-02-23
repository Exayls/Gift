using Gift.UI.MetaData;

namespace Gift.UI.Interface
{
    public interface IGiftUI : IContainer
    {
        int Height { get; }
        public Bound Bound { get; }

        IScreenDisplay GetDisplay();
        bool IsFixed();
        void SetChild(UIElement UIElement);
    }
}