namespace Gift.UI.Interface
{
    public interface Renderable
    {
        ICollection<Renderable> RenderableChilds { get; }
        void Display(TextWriter output);
        void Render();
    }
}