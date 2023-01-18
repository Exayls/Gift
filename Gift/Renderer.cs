using Gift.UI;
using Gift.UI.Interface;
using Gift.UI.MetaData;
using System.Text;

namespace Gift
{
    /// <summary>
    /// Render the UI to a TextWriter
    /// </summary>
    public class Renderer
    {
        public TextWriter Output { get; }
        private Bound TotalBound { get; set; }// really bad

        public Renderer(TextWriter output)
        {
            Output = output;
        }

        public void Render(Renderable Renderer, ScreenDisplay screen)
        {
            UpdateDisplay(Renderer, screen);
        }

        public TextWriter Render(GiftUI giftUI)// base render
        {

            UpdateTotalBound(giftUI);
            ScreenDisplay screen = new ScreenDisplay();

            UpdateDisplay(giftUI, screen);
            foreach (dynamic renderable in giftUI.Childs)
            {
                Render(renderable, screen);
            }

            Output.Flush();
            Output.Write(screen.DisplayString.ToString());
            return this.Output;
        }

        public void Render(Container container, ScreenDisplay screen)
        {
            UpdateDisplay(container, screen);
            foreach (dynamic renderable in container.Childs)
            {
                Render(renderable, screen);
            }
        }
        public void Render(Label Renderer, ScreenDisplay screen)
        {
            UpdateDisplay(Renderer, screen);
        }

        private void UpdateDisplay(Renderable renderable, ScreenDisplay screen)
        {
        }
        private void UpdateDisplay(GiftUI renderable, ScreenDisplay screen)
        {
            Output.Flush();
            for (int i = 0; i < renderable.Bound.Height; i++)
            {
                screen.DisplayString.Append(new string(GiftBase.FILLINGCHAR, renderable.Bound.Width));
                screen.DisplayString.Append('\n');
            }
        }
        public void UpdateDisplay(Label label, ScreenDisplay screen)
        {
            string display = label.GetVisibleText();
            int context_y = label?.Context?.GlobalPosition?.y ?? 0;
            int context_x = label?.Context?.GlobalPosition?.x ?? 0;
            int relative_y = label?.Disposition.Position?.y ?? 0;
            int relative_x = label?.Disposition.Position?.x ?? 0;

            int global_y = context_y + relative_y;
            int global_x = context_x + relative_x;
            Helper.Replace(screen.DisplayString, display, global_y * (TotalBound.Width + 1) + global_x);
        }
        public void UpdateTotalBound(GiftUI giftUi)
        {
            TotalBound = giftUi.Bound;
        }
    }
}
