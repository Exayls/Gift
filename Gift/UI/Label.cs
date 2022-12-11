using Gift.UI;
using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public class Label : UIElement
    {
        private string text;
        private Position position;

        public Label(string text, Position position): base()
        {
            this.text = text;
            this.position = position;
        }

        public override void Display(TextWriter output)
        {
            output.Write("Hello");
        }
    }
}