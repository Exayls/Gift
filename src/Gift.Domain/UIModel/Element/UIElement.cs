using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.Element
{
    public abstract class UIElement : IRenderable
    {

        public abstract int Height { get; }
        public abstract int Width { get; }
        public IBorder Border { get; set; }
        public Color FrontColor { get; private set; }
        public Color BackColor { get; private set; }

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

        protected UIElement(IBorder? border = null, Color frontColor = Color.Default, Color backColor = Color.Default)
        {
            Border = border ?? new NoBorder();
            FrontColor = frontColor;
            BackColor = backColor;
        }

        public abstract IScreenDisplay GetDisplayWithoutBorder(Bound bounds, IConfiguration configuration);
        public abstract IScreenDisplay GetDisplayBorder(Bound bound, IConfiguration configuration);
        public abstract Position GetRelativePosition(Context context);
        public abstract bool IsFixed();

		public virtual bool Equals(UIElement element)
		{
            if (!this.Border.Equals(element.Border)) return false;
            if (!this.BackColor.Equals(element.BackColor)) return false;
            if (!this.FrontColor.Equals(element.FrontColor)) return false;
			return true;
		}
    }
}
