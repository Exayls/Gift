using Gift.UI.Border;
using Gift.UI.Configuration;
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
        public Color? FrontColor { get; private set; }
        public Color? BackColor { get; private set; }

        private bool isSelectedElement;
        public bool IsSelectedElement
        {
            get => isSelectedElement;
            set
            {
                isSelectedElement = value;
            }
        }

        public bool IsInSelectedContainer { get; set; }

        protected UIElement(IBorder? border = null , Color? frontColor = null, Color? backColor = null)
        {
            Border = border?? new NoBorder();
            FrontColor = frontColor;
            BackColor = backColor;
        }

        public abstract IScreenDisplay GetDisplay(Bound bound);
        public abstract IScreenDisplay GetDisplayWithoutBorder(Bound bounds, IConfiguration configuration);
        public abstract IScreenDisplay GetDisplayBorder(Bound bound, IConfiguration configuration);
        public abstract Position GetRelativePosition(Context context);
        public abstract Position GetGlobalPosition(Context context);
        public abstract bool IsFixed();
    }
}