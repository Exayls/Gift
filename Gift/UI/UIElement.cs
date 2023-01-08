using Gift.UI.Interface;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI
{
    public abstract class UIElement : Renderable
    {
        public Renderer Renderer { get; set; }
        public Context? Context { get; set; }

        public UIElement()
        {
        }

        public virtual void Render(StringBuilder stringBuilder)
        {
            Renderer?.Render(this, stringBuilder);
        }

        internal void setContext(Position globalPosition,Bound bound)
        {
            Context = new Context(globalPosition, bound);
        }
    }
}