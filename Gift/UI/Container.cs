using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public abstract class Container : UIElement
    {
        public Bound Bound { get; protected set; }
        public ICollection<Renderable> RenderableChilds { get; protected set; }
        public Container(Renderer renderer, Bound? bound)
        {

            if (bound == null)
            {
                if (Context?.Bounds != null)
                {
                    Bound = new Bound(Context.Bounds.Height, Context.Bounds.Width);
                }
                else if (!Console.IsInputRedirected && !Console.IsOutputRedirected)
                {
                    Bound = new Bound(Console.WindowHeight, Console.WindowWidth);
                }
                else
                {
                    Bound = new Bound(0, 0);
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