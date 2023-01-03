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
        public void Render(GiftUI giftUI)
        {
            UpdateDisplay(giftUI); 
        }
        public void Render(Renderable Renderer)
        {
            UpdateDisplay(Renderer); 
        }

        private void UpdateDisplay(Renderable renderable)
        {
            renderable.Display(Output);
        }
        private void UpdateDisplay(GiftUI renderable)
        {
            for (int i = 0; i < renderable.Bound.Height; i++)
            {
                Output.Write(new string(GiftBase.FILLINGCHAR,renderable.Bound.Width));
                Output.Write('\n');
            }
        }
    }
}