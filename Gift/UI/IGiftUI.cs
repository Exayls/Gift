using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;

namespace Gift.UI
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