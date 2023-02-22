using Gift.UI.Interface;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI
{
    public abstract class Container : UIElement, IContainer
    {
        public Bound Bound { get; protected set; }
        public IList<IUIElement> Childs { get; protected set; }
        public Container(Bound bound)
        {

            Bound = bound;
            Childs = new List<IUIElement>();
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
            Childs = new List<IUIElement>();
        }

        public abstract bool isVisible(Renderable renderable);


        public abstract Context GetContext(Renderable renderable, Context context);

    }
}