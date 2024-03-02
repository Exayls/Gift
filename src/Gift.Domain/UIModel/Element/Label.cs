using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.DispositionStrategy;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.Element
{
    public class Label : UIElement
    {
        public string Text { get; private set; }
        public IDispositionStrategy Disposition { get; private set; }

        public override int Height
        {
            get
            {
                return 1 + 2 * Border.Thickness;
            }
        }
        public override int Width
        {
            get
            {
                return Text.Length + 2 * Border.Thickness;
            }
        }

        public Label(string text, Position? position = null, IBorder? border = null, Color frontColor = Color.Default,
                     Color backColor = Color.Default)
            : base(border, frontColor, backColor)
        {
            Text = text;
            if (position != null)
            {
                Disposition = new ExplicitDisposition(position);
            }
            else
            {
                Disposition = new ImplicitDisposition();
            }
        }

        public override bool IsFixed()
        {
            return Disposition is ExplicitDisposition;
        }

        public override Position GetRelativePosition(Context context)
        {
            int context_y = context.Position.y;
            int context_x = context.Position.x;
            int relative_y = Disposition.Position.y;
            int relative_x = Disposition.Position.x;
            int position_y = context_y + relative_y;
            int position_x = context_x + relative_x;
            Position position = new Position(position_y, position_x);
            return position;
        }

        public override IScreenDisplay GetDisplayWithoutBorder(Bound bound, IConfiguration configuration)
        {
            Color frontColor = FrontColor == Color.Default ? configuration.DefaultFrontColor : FrontColor;
            Color backColor = BackColor == Color.Default ? configuration.DefaultBackColor : BackColor;
            if (IsSelectedElement && IsInSelectedContainer)
            {
                frontColor = configuration.SelectedElementFrontColor == Color.Default
                                 ? frontColor
                                 : configuration.SelectedElementFrontColor;
                backColor = configuration.SelectedElementBackColor == Color.Default
                                ? backColor
                                : configuration.SelectedElementBackColor;
            }
            return new ScreenDisplay(Text, frontColor, backColor);
        }

        public override IScreenDisplay GetDisplayBorder(Bound bound, IConfiguration configuration)
        {
            return Border.GetDisplay(new Bound(Height, Width),
                                     FrontColor == Color.Default ? configuration.DefaultFrontColor : FrontColor,
                                     BackColor == Color.Default ? configuration.DefaultBackColor : BackColor);
        }

        public override bool Equals(UIElement uiElement)
        {
            if (!(base.Equals(uiElement)))
                return false;
            if (!(uiElement is Label))
                return false;
            Label element = (Label)uiElement;
            if (this.Text != element.Text)
                return false;
            return true;
        }
    }
}
