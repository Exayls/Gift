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
            foreach (Renderable r in renderable.RenderableChilds)
            {
                this.Render(r);
            }
        }

        private void UpdateDisplay(Renderable renderable)
        {
            renderable.Display(Output);
        }
    }
}