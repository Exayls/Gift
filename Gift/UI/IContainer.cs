using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public interface IContainer: IUIElement
    {
        Bound Bound { get; }
        IList<IUIElement> Childs { get; }

        Context GetContext(Renderable renderable, Context context);
        bool isVisible(Renderable renderable);
    }
}