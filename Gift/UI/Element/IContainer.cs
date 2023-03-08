using Gift.UI.MetaData;

namespace Gift.UI.Element
{
    public interface IContainer : IUIElement
    {
        Bound Bound { get; }
        IList<IUIElement> Childs { get; }

        Context GetContextRenderable(Renderable renderable, Context context);
        bool isVisible(Renderable renderable);
    }
}