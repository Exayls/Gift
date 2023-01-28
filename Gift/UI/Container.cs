using Gift.UI.Interface;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI
{
    public abstract class Container : UIElement
    {
        public Bound Bound { get; protected set; }
        public IList<UIElement> Childs { get; protected set; }
        public Container(Bound bound)
        {

            Bound = bound;
            Childs = new List<UIElement>();
        }
        public Container()
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
            Childs = new List<UIElement>();
        }

        internal abstract bool isVisible(Renderable renderable);
    }
}