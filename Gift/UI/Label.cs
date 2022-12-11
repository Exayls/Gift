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
            string display = text.PadLeft(Position.y + text.Length);
            display = display.Length > 60 ? display.Substring(0, 60) : display;

            output.Write(display);
        }
    }
}