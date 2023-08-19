using System.Collections.Generic;
using Gift.UI.MetaData;

namespace Gift.UI.Element
{
    public interface IContainer : IUIElement
    {
        Bound Bound { get; }
        IList<IUIElement> Childs { get; }
        IList<IUIElement> SelectableElements { get; set; }
        IUIElement? SelectedElement { get; set; }
        bool IsSelectedContainer { get; set; }
        int ScrollIndex { get; }

        void AddUnselectableChild(IUIElement uIElement);
        Context GetContextRelativeRenderable(IRenderable renderable, Context context);
        void NextElement();
        void PreviousElement();
        void ScrollDown();
        void ScrollUp();
    }
}
