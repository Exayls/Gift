using Gift.UI.Border;
using Gift.UI.Interface;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI
{
    public abstract class UIElement : Renderable, IUIElement
    {
        public Context? Context { get; set; }

        public abstract int Height { get; }
        public IBorder Border { get ; set ; }

        protected UIElement(IBorder border)
        {
            Border = border;
        }
        protected UIElement()
        {
            Border = new NoBorder();
        }

        public abstract IScreenDisplay GetDisplay(Bound bound);
        public abstract Position GetGlobalPosition(Context context);
        public abstract bool IsFixed();

        internal void setContext(Position globalPosition, Bound bound)
        {
            Context = new Context(globalPosition, bound);
        }
    }
}