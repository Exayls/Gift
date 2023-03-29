using Gift.UI.Border;
using Gift.UI.Display;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI.Element
{
    public abstract class UIElement : IUIElement
    {

        public abstract int Height { get; }
        public abstract int Width { get; }
        public IBorder Border { get; set; }


        protected UIElement(IBorder border)
        {
            Border = border;
        }
        protected UIElement()
        {
            Border = new NoBorder();
        }

        public abstract IScreenDisplay GetDisplay(Bound bound);
        public abstract IScreenDisplay GetDisplayWithoutBorder(Bound bound);
        public abstract IScreenDisplay GetDisplayWithoutBorder(Bound bounds, Color frontColor, Color BackColor);
        public abstract IScreenDisplay GetDisplayBorder(Bound bound);
        public abstract IScreenDisplay GetDisplayBorder(Bound bounds, Color frontColor, Color BackColor);
        public abstract Position GetRelativePosition(Context context);
        public abstract Position GetGlobalPosition(Context context);
        public abstract bool IsFixed();
    }
}