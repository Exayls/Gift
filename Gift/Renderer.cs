using Gift.UI;
using Gift.UI.Interface;
using Gift.UI.MetaData;
using System.Text;

namespace Gift
{
    public class Renderer
    {
        public TextWriter Output { get; }
        private Bound TotalBound { get; set; }// really bad

        public Renderer(TextWriter output)
        {
            Output = output;
        }

        public void Render(Renderable Renderer, StringBuilder screenString)
        {
            UpdateDisplay(Renderer, screenString);
        }

        public void Render(GiftUI giftUI)// base render
        {
            
            UpdateTotalBound(giftUI);
            StringBuilder screenString = new StringBuilder();//Replace by class

            UpdateDisplay(giftUI, screenString);
            foreach (dynamic renderable in giftUI.Childs)
            {
                Render(renderable,screenString);
            }

            Output.Flush();
            Output.Write(screenString.ToString());
        }

        public void Render(Container container, StringBuilder screenString)
        {
            UpdateDisplay(container, screenString);
            foreach (dynamic renderable in container.Childs)
            {
                Render(renderable, screenString);
            }
        }
        public void Render(Label Renderer, StringBuilder screenString)
        {
            UpdateDisplay(Renderer, screenString);
        }

        private void UpdateDisplay(Renderable renderable, StringBuilder screenString)
        {
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
            string display = label.GetVisibleText();
            int context_y = label?.Context?.GlobalPosition?.y ?? 0;
            int context_x = label?.Context?.GlobalPosition?.x ?? 0;
            int relative_y = label?.Disposition.Position?.y ?? 0;
            int relative_x = label?.Disposition.Position?.x ?? 0;

            int global_y = context_y + relative_y;
            int global_x = context_x + relative_x;
            Helper.Replace(screenString, display, global_y * (TotalBound.Width + 1) + global_x);
        }
        public void UpdateTotalBound(GiftUI giftUi)
        {
            TotalBound = giftUi.Bound;
        }
    }
}
