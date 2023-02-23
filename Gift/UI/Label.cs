using Gift.UI.Interface;
using Gift.UI.MetaData;
using Gift.UI.Strategy;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gift.UI
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

        public Label(string text, Position position)
        {
            Text = text;
            Disposition = new ExplicitDisposition(position);
        }
        public Label(string text)
        {
            Text = text;
            Disposition = new ImplicitDisposition();
        }

        public string GetDisplay()
        {
            string text = Text;
            int widthLine = Disposition.Position.x + text.Length;
            int MaxWidth = Context?.Bounds?.Width ?? 0;
            string display = Disposition.Position.x <= MaxWidth? (widthLine > MaxWidth ? text.Substring(0, widthLine-MaxWidth-1) : text) : "";
            return display;
        }

        public override bool IsFixed()
        {
            return Disposition is ExplicitDisposition;
        }


        public override Position GetGlobalPosition(Context context)
        {
            int context_y = context.GlobalPosition?.y ?? 0;
            int context_x = context.GlobalPosition?.x ?? 0;
            int relative_y = this.Disposition.Position.y;
            int relative_x = this.Disposition.Position.x;
            int global_y = context_y + relative_y;
            int global_x = context_x + relative_x;
            Position globalPosition = new Position(global_y, global_x);
            return globalPosition;
        }

        public override IScreenDisplay GetDisplay(Bound bound)
        {
            return new ScreenDisplay(this.Text);
            //IScreenDisplay screen = new ScreenDisplay(bound);

            //string text = Text;
            //int widthLine = Disposition.Position.x + text.Length;
            //int MaxWidth = Context?.Bounds?.Width ?? 0;
            //string display = Disposition.Position.x <= MaxWidth? (widthLine > MaxWidth ? text.Substring(0, widthLine-MaxWidth-1) : text) : "";
            //screen.AddString(display, Disposition.Position);
            //return screen;
        }
    }
}