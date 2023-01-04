using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public abstract class UIElement : Renderable
    {
        public Renderer? Renderer { get; set; }
        public Context? Context { get; set; }

        public UIElement()
        {
        }
        //public abstract void Display(TextWriter output);

        public virtual void Render()
        {
            Renderer?.Render(this);
        }

        internal void setContext(Position globalPosition,Bound bound)
        {
            Context = new Context(globalPosition, bound);
        }
    }
}