using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public interface IGiftUI : IContainer
    {
        List<IContainer> SelectableContainers { get; set; }
        IContainer? SelectedContainer { get; set; }

        void PreviousElementInSelectedContainer();
        void NextElementInSelectedContainer();
        void Resize(Bound bound);
        void NextContainer();
        void PreviousContainer();
    }
}