using Gift.UI.Border;
using Gift.UI.Display;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI.Element
{
    public abstract class Container : UIElement, IContainer
    {
        public Bound Bound { get; protected set; }
        public IList<IUIElement> Childs { get; protected set; }
        public Container(Bound bound, IBorder border) : base(border)
        {
            Bound = bound;
            Childs = new List<IUIElement>();
        }
        public Container()
        {
            if (!Console.IsInputRedirected && !Console.IsOutputRedirected)
            {
                Bound = new Bound(Console.WindowHeight, Console.WindowWidth);
            }
            else
            {
                Bound = new Bound(0, 0);
            }
            Childs = new List<IUIElement>();
        }

        public abstract Context GetContextRenderable(IRenderable renderable, Context context);
        public abstract Context GetContextRelativeRenderable(IRenderable renderable, Context context);
    }
}