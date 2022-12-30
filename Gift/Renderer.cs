using Gift.UI;
using Gift.UI.Interface;

namespace Gift
{
    public class Renderer
    {
        public TextWriter Output { get; }
        public Renderer(TextWriter output)
        {
            Output = output;
        }

        public void Render(Container container)
        {
        UpdateDisplay(container); 
            foreach (Renderable r in container.RenderableChilds)
            {
                this.Render(r);
            }
        }
        public void Render(Renderable Renderer)
        {
            UpdateDisplay(Renderer); 
        }

        private void UpdateDisplay(Renderable renderable)
        {
            renderable.Display(Output);
        }
    }
}