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
            UpdateDisplay(renderable); 
            foreach (Renderable r in renderable.RenderableChilds)
            {
                this.Render(r);
            }
        }

        private void UpdateDisplay(Renderable renderable)
        {
            renderable.display();
        }
    }
}