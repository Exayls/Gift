namespace Gift.View
{
    public interface Renderable
    {
        ICollection<Renderable> RenderableChilds{ get; set;}
        void Render();
    }
}