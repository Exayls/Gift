using Gift.UI.MetaData;

namespace Gift.UI.Element
{
    public interface IContainer : IUIElement
    {
        Bound Bound { get; }
        IList<IUIElement> Childs { get; }

        Context GetContextRenderable(IRenderable renderable, Context context);
        bool isVisible(IRenderable renderable);
    }
}