using Gift.UI;
using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public class Label : UIElement
    {
        private string text;
        private Position Position;

        public Label(string text, Position Position) : base()
        {
            this.text = text;
            this.Position = Position;
        }

        public override void Display(TextWriter output)
        {
            int yMax = Context != null? Context.Y: 0;
            string displayLeftSpace = text.PadLeft(Position.y + text.Length);
            string display = displayLeftSpace.Length > yMax ? displayLeftSpace.Substring(0, yMax) : displayLeftSpace;

            output.Write(display);
        }
    }
}