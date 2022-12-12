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


        public void Render(Renderable renderable)
        {
            UpdateDisplay(renderable); 
            if (renderable is Container)
            {
                Container container = (Container)renderable;
                foreach (Renderable r in container.RenderableChilds)
                {
                    this.Render(r);
                }
            }
        }

        private void UpdateDisplay(Renderable renderable)
        {
            renderable.Display(Output);
        }
    }
}