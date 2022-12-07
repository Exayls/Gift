namespace Gift.View.View
{
    public class Panel : UIElement
    {
        public Panel()
        {
        }

        ICollection<Renderable> Renderable.RenderableChilds { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Render()
        {
            throw new NotImplementedException();
        }

        void UIElement.Render()
        {
            throw new NotImplementedException();
        }

        void Renderable.Render()
        {
            throw new NotImplementedException();
        }
    }
}