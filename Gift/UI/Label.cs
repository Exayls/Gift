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
            for (int i = 0; i < Position.y; i++)
            {
                emptylines += $"{"".PadLeft(16)}\n";
            }
            string LeftSpace = "".PadLeft(Math.Min(Position.x, Context?.Bounds?.Width??int.MaxValue));

            string display = GetVisibleText(this);
            display = $"{emptylines}{LeftSpace}{display}";
            output.Write(display);
        }
        public static string GetVisibleText(Label Label)
        {
            if (Label == null)
            {
                throw new ArgumentNullException("label");
            }
            string text = Label.Text;
            Context? Context = Label.Context;
            int widthLine = Label.Position.x + text.Length;
            int MaxWidth = Context?.Bounds?.Width ?? 0;
            string display = widthLine <= MaxWidth+text.Length? (widthLine > MaxWidth ? text.Substring(0, widthLine-MaxWidth-1) : text) : "";
            return display;
        }
    }
}