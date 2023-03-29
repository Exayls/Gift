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
            Position globalPosition = new Position(global_y, global_x);
            //Position globalPosition = new Position(context_y, context_x);
            return globalPosition;
        }
        public override Position GetGlobalPosition(Context context)
        {
            int context_y = context.Position.y;
            int context_x = context.Position.x;
            int relative_y = Disposition.Position.y;
            int relative_x = Disposition.Position.x;
            int global_y = context_y + relative_y;
            int global_x = context_x + relative_x;
            Position globalPosition = new Position(global_y, global_x);
            return globalPosition;
        }

        public override IScreenDisplay GetDisplay(Bound bound)
        {
            return new ScreenDisplay(Text);
        }

        public override IScreenDisplay GetDisplayWithoutBorder(Bound bound, Color frontColor = Color.White, Color BackColor = Color.Black)
        {
            return new ScreenDisplay(Text);
        }
        public override IScreenDisplay GetDisplayBorder(Bound bound)
        {
            return Border.GetDisplay(bound);
        }

        public override IScreenDisplay GetDisplayBorder(Bound bound, Color frontColor, Color backColor)
        {
            return Border.GetDisplay(bound, frontColor, backColor);
        }
    }
}