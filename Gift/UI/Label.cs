using Gift.UI;
using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public class Label : UIElement
    {
        private string text;
        private Position Position;

        public Label(string text, Position Position): base()
        {
            this.text = text;
            this.Position = Position;
        }

        public override void Display(TextWriter output)
        {
            if (text == "test")
            {
            output.Write("test".PadLeft(Position.y + "test".Length));
            }
            else
            {
            output.Write("Hello".PadLeft(Position.y + "Hello".Length));
            }
            //output.Write("Hello".PadLeft(Position.y + "Hello".Length));
        }
    }
}