using Gift.UI.Interface;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI
{
    public abstract class UIElement : Renderable
    {
        public Context? Context { get; set; }

        public UIElement()
        {
        }

        internal void setContext(Position globalPosition,Bound bound)
        {
            Context = new Context(globalPosition, bound);
        }
    }
}