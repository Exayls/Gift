using Gift.UI;
using Gift.UI.Interface;
using Gift.UI.MetaData;
using Gift.UI.Strategy;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gift.UI
{
    public class Label : UIElement
    {
        public string Text { get; private set; }
        public DispositionStrategy Disposition { get; private set; }

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
        public bool IsExplicit()
        {
            return Disposition is ExplicitDisposition;
        }

        public string GetVisibleText()
        {
            string text = Text;
            int widthLine = Disposition.Position.x + text.Length;
            int MaxWidth = Context?.Bounds?.Width ?? 0;
            string display = Disposition.Position.x <= MaxWidth? (widthLine > MaxWidth ? text.Substring(0, widthLine-MaxWidth-1) : text) : "";
            return display;
        }
    }
}