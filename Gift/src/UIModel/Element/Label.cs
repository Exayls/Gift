using Gift.UI.Border;
using Gift.UI.Configuration;
using Gift.UI.Display;
using Gift.UI.MetaData;
using Gift.UI.Strategy;

namespace Gift.UI.Element
{
    public class Label : UIElement
    {
        public string Text { get; private set; }
        public DispositionStrategy Disposition { get; private set; }

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

        public Label(string text, Position? position = null, IBorder? border = null, Color frontColor = Color.Default, Color backColor = Color.Default) : base(border, frontColor, backColor)
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
                frontColor = configuration.SelectedElementFrontColor == Color.Default ? frontColor : configuration.SelectedElementFrontColor;
                backColor = configuration.SelectedElementBackColor == Color.Default ? backColor : configuration.SelectedElementBackColor;
            }
            return new ScreenDisplay(Text, frontColor, backColor);
        }

        public override IScreenDisplay GetDisplayBorder(Bound bound, IConfiguration configuration)
        {
            return Border.GetDisplay(new Bound(Height, Width), FrontColor == Color.Default ? configuration.DefaultFrontColor : FrontColor, BackColor == Color.Default ? configuration.DefaultBackColor : BackColor);
        }
    }
}
