using Gift.UI.Interface;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI
{
    public abstract class UIElement : Renderable, IUIElement
    {
        public Context? Context { get; set; }

        public abstract int Height { get; }

        public abstract IScreenDisplay GetDisplay(Bound bound);
        public abstract Position GetGlobalPosition(Context context);
        public abstract bool IsFixed();

        internal void setContext(Position globalPosition, Bound bound)
        {
            Context = new Context(globalPosition, bound);
        }
    }
}