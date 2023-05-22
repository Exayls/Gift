using Gift.UI.Border;
using Gift.UI.Configuration;
using Gift.UI.Display;
using Gift.UI.MetaData;
using Gift.UI.Strategy;
using System.Runtime.CompilerServices;
using System.Text;

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
                return 1;
            }
        }
        public override int Width
        {
            get
            {
                return Text.Length;
            }
        }

        public Label(string text, Position? position = null, IBorder? border = null, Color? frontColor = null, Color? backColor = null) : base(border, frontColor, backColor)
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
            int global_y = context_y + relative_y;
            int global_x = context_x + relative_x;
            Position position = new Position(global_y, global_x);
            return position;
        }

        public override IScreenDisplay GetDisplayWithoutBorder(Bound bound, IConfiguration configuration)
        {
            Color frontColor = FrontColor ?? configuration.DefaultFrontColor;
            Color backColor = BackColor ?? configuration.DefaultBackColor;
            if (IsSelectedElement && IsInSelectedContainer)
            {
                frontColor = configuration.SelectedElementFrontColor ?? frontColor;
                backColor = configuration.SelectedElementBackColor ?? backColor;
            }
            return new ScreenDisplay(Text, frontColor, backColor);
        }

        public override IScreenDisplay GetDisplayBorder(Bound bound, IConfiguration configuration)
        {
            return Border.GetDisplay(bound, FrontColor ?? configuration.DefaultFrontColor, BackColor ?? configuration.DefaultBackColor);
        }
    }
}