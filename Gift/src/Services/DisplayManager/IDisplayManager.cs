using Gift.UI.MetaData;

namespace Gift.UI.DisplayManager
{
    public interface IDisplayManager
    {
        void NextContainer();
        void NextElementInSelectedContainer();
        void PreviousContainer();
        void PreviousElementInSelectedContainer();
        void Resize(Bound bound);
        void ScrollDown();
        void ScrollUp();
        void UpdateDisplay();
    }
}
