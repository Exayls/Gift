using Gift.UI.Interface;

namespace Gift.UI
{
    public abstract class UIElement : Renderable
    {
        public Renderer? Renderer { get; set; }
        public ICollection<Renderable> RenderableChilds { get; private set; }

        public UIElement()
        {
            RenderableChilds = new List<Renderable>();
        }
        public abstract void Display(TextWriter output);

        public void Render()
        {
            Renderer?.Render(this);
        }
    }
}