using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public abstract class Container : UIElement
    {
        public Bound Bound { get; }
        public ICollection<Renderable> RenderableChilds { get; private set; }
        public Container(Renderer renderer, Bound? bound)
        {

            if (bound == null)
            {
                if (!Console.IsInputRedirected && !Console.IsOutputRedirected)
                {
                    Bound = new Bound(Console.WindowWidth, Console.WindowHeight);
                }
                else
                {
                    Bound = new Bound(20, 60);
                }
            }
            else
            {
                Bound = bound;
            }
            Renderer = renderer;
            RenderableChilds = new List<Renderable>();
        }
        public override void Render()
        {
            Renderer?.Render(this);
        }
    }
}