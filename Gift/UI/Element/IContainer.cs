using Gift.UI.Display;
using Gift.UI.MetaData;

namespace Gift.UI.Element
{
    public interface IContainer : IUIElement
    {
        Bound Bound { get; }
        IList<IUIElement> Childs { get; }
        List<IUIElement> ElementsCycle { get; set; }

        Context GetContextRelativeRenderable(IRenderable renderable, Context context);
        Context GetContextRenderable(IRenderable renderable, Context context);
    }
}