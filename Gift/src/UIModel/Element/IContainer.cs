using Gift.UI.Display;
using Gift.UI.MetaData;

namespace Gift.UI.Element
{
    public interface IContainer : IUIElement
    {
        Bound Bound { get; }
        IList<IUIElement> Childs { get; }
        List<IUIElement> SelectableElements { get; set; }
        IUIElement? SelectedElement { get; set; }
        bool IsSelectedContainer { get; set; }
        int ScrollIndex { get; }

        void AddChild(IUIElement uIElement);
        Context GetContextRelativeRenderable(IRenderable renderable, Context context);
        void NextElement();
        void PreviousElement();
        void ScrollDown();
        void ScrollUp();
    }
}