using Gift.Domain.Builders.UIModel.Display;
using Gift.Domain.ServiceContracts;
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

        public override bool IsSimilarTo(UIElement uiElement)
        {
            if (!(base.IsSimilarTo(uiElement)))
                return false;
            if (!(uiElement is Label))
                return false;
            Label element = (Label)uiElement;
            if (this.Text != element.Text)
                return false;
            return true;
        }

        public override IScreenDisplay GetDisplayWithoutBorder(IConfiguration configuration, IColorResolver colorResolver)
        {
            Color frontColor = colorResolver.GetFrontColor(this, configuration);
            Color backColor = colorResolver.GetBackColor(this, configuration);
            return new ScreenDisplay(Text, frontColor, backColor);
        }

        public override IScreenDisplay GetDisplayBorder(IConfiguration configuration, IColorResolver colorResolver)
        {
			var screen = new ScreenDisplayBuilder()
				.WithFrontColor(colorResolver.GetFrontColor(this, configuration))
				.WithBackColor(colorResolver.GetBackColor(this, configuration))
				.WithBound(new Size(Height, Width));
            return Border.GetDisplay(screen);

        }
    }
}
