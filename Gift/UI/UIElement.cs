using Gift.UI.Interface;

namespace Gift.UI
{
    public abstract class UIElement : Renderable
    {
        public Renderer? Renderer { get; set; }
        public Bound? Context { get; set; }

        public UIElement()
        {
        }
        public abstract void Display(TextWriter output);

        public void Render()
        {
            Renderer?.Render(this);
        }

        internal void setContext(Bound bound)
        {
            Context = bound;
        }
    }
}