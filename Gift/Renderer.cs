using Gift.View;

namespace Gift
{
    public class Renderer
    {
        public Renderer()
        {

        }
        public void Render(Renderable renderable)
        {
            renderable.Render();
            foreach (Renderable r in renderable.RenderableChilds)
            {
                this.Render(r);
            }
        }
    }
}