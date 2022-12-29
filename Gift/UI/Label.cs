using Gift.UI;
using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public class Label : UIElement
    {
        public string Text { get; private set; }
        public Position Position { get; private set; }

        public Label(string text, Position Position) : base()
        {
            Text = text;
            this.Position = Position;
        }

        public override void Display(TextWriter output)
        {
            string emptylines = "";
            if (this.Position.y == 2)
            {
                emptylines = $"{"".PadLeft(16)}\n{"".PadLeft(16)}\n";
            }

            int MaxWidth = Context != null ? Context.Width : 0;
            string displayLeftSpace = Text.PadLeft(Position.x + Text.Length);
            string display = displayLeftSpace.Length > MaxWidth ? displayLeftSpace.Substring(0, MaxWidth) : displayLeftSpace;
            display = $"{emptylines}{display}";
            output.Write(display);
        }
    }
}