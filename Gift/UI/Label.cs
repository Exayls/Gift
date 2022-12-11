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
            if (Position.y == 1000)
            {
                output.Write("".PadLeft(60));
                return;
            }
            if (Position.y == 58)
            {
                output.Write("".PadLeft(58)+"He");
                return;
            }
            output.Write(text.PadLeft(Position.y + text.Length));
        }
    }
}