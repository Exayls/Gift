namespace Gift.View
{
    public interface Renderable
    {
        ICollection<Renderable> RenderableChilds{ get;}

        void display();
        void Render();
    }
}