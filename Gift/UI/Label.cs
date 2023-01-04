using Gift.UI;
using Gift.UI.Interface;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI
{
    public class Label : UIElement
    {
        public string Text { get; private set; }
        public Position Position { get; private set; }

        public Label(string text, Position Position)
        {
            Text = text;
            this.Position = Position;
        }

        public string GetVisibleText()
        {
            string text = this.Text;
            Context? Context = this.Context;
            int widthLine = this.Position.x + text.Length;
            int MaxWidth = Context?.Bounds?.Width ?? 0;
            string display = widthLine <= MaxWidth+text.Length? (widthLine > MaxWidth ? text.Substring(0, widthLine-MaxWidth-1) : text) : "";
            return display;
        }
        public override void Render(StringBuilder stringBuilder)
        {
            Renderer?.Render(this, stringBuilder);
        }
    }
}