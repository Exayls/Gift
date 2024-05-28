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
            get {
                return 1 + 2 * Border.Thickness;
            }
        }
        public override int Width
        {
            get {
                return Text.Length + 2 * Border.Thickness;
            }
        }

        public Label(string text, Position? position, IBorder? border, Color frontColor,
                     Color backColor, string id)
            : base(border, frontColor, backColor, id)
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

        public override Position GetRelativePosition(Position position)
        {
            int context_y = position.y;
            int context_x = position.x;
            int relative_y = Disposition.Position.y;
            int relative_x = Disposition.Position.x;
            int position_y = context_y + relative_y;
            int position_x = context_x + relative_x;
            Position finalPosition = new Position(position_y, position_x);
            return finalPosition;
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

        public override IScreenDisplay GetDisplayWithoutBorder(IConfiguration configuration, IColorResolver colorResolver, IElementSizeCalculator sizeCalculator)
        {
            Color frontColor = colorResolver.GetFrontColor(this, configuration);
            Color backColor = colorResolver.GetBackColor(this, configuration);
            return new ScreenDisplay(Text, frontColor, backColor);
        }

        public override IScreenDisplay GetDisplayBorder(IConfiguration configuration, IColorResolver colorResolver, IElementSizeCalculator sizeCalculator)
        {
            var screen = new ScreenDisplayBuilder()
                             .WithFrontColor(colorResolver.GetFrontColor(this, configuration))
                             .WithBackColor(colorResolver.GetBackColor(this, configuration))
                             .WithBound(sizeCalculator.GetTrueSize(this));
            return Border.GetDisplay(screen);
        }
    }
}
