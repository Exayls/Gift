using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public interface IGiftUI : IContainer
    {
        List<IContainer> SelectableContainers { get; set; }
        IScreenDisplay GetDisplay();
        void SetChild(UIElement UIElement);
    }
}