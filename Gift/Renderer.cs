using Gift.UI;
using Gift.UI.Interface;
using System.Text;

namespace Gift
{
    public class Renderer
    {
        public TextWriter Output { get; }
        public Renderer(TextWriter output)
        {
            Output = output;
            
        }

        public void Render(Label Renderer, StringBuilder screenString)
        {
            UpdateDisplay(Renderer, screenString);
        }
        public void Render(Container container, StringBuilder screenString)
        {
            UpdateDisplay(container, screenString);
            foreach (Renderable r in container.RenderableChilds)
            {
                r.Render(screenString);
            }
        }
        public void Render(GiftUI giftUI)// base render
        {
            StringBuilder screenString = new StringBuilder();

            UpdateDisplay(giftUI, screenString);
            foreach (Renderable r in giftUI.RenderableChilds)
            {
                r.Render(screenString);
            }

            Output.Flush();
            Output.Write(screenString.ToString());
        }
        public void Render(Renderable Renderer, StringBuilder screenString)
        {
            UpdateDisplay(Renderer, screenString);
        }

        private void UpdateDisplay(Renderable renderable , StringBuilder screenString)
        {
            //renderable.Display(Output);
        }
        private void UpdateDisplay(GiftUI renderable, StringBuilder screenString)
        {
            Output.Flush();
            for (int i = 0; i < renderable.Bound.Height; i++)
            {
                screenString.Append(new string(GiftBase.FILLINGCHAR, renderable.Bound.Width));
                screenString.Append('\n');
            }
        }
        public void UpdateDisplay(Label label, StringBuilder screenString)
        {
            //string outputText = Output.
            //string emptylines = "";
            //for (int i = 0; i < label.Position.y; i++)
            //{
            //    emptylines += $"{"".PadLeft(label.Context?.Bounds?.Width??0)}\n";
            //}
            //string LeftSpace = "".PadLeft(Math.Min(label.Position.x, label.Context?.Bounds?.Width??int.MaxValue));

            string display = label.GetVisibleText();
            //display = $"{emptylines}{LeftSpace}{display}";
            //Output.Write(display);
            Helper.Replace(screenString, display,0 );
        }
    }
}
