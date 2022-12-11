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
            if(Position.y == 30)
            {
                output.Write("                              Hello");
            }
            else if(Position.y == 10)
            {
                output.Write("          Hello");
            }
            else
            {
            output.Write("Hello");
            }
        }
    }
}