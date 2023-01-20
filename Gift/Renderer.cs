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
        public Renderer()
        {
        }

        private void Render(Renderable Renderer, ScreenDisplay screen)
        {
            UpdateDisplay(Renderer, screen);
        }

        public TextWriter Render(GiftUI giftUI)
        {
            ScreenDisplay screen = new ScreenDisplay(giftUI.Bound);
            UpdateDisplay(giftUI, screen);
            RenderAllChilds(giftUI, screen);
            TextWriter Output = new StringWriter();
            Output.Write(screen.DisplayString);
            return Output;
        }

        private void RenderAllChilds(GiftUI giftUI, ScreenDisplay screen)
        {
            foreach (dynamic renderable in giftUI.Childs)//dynamic to use overloaded method
            {
                Render(renderable, screen);
            }
        }

        private void Render(Container container, ScreenDisplay screen)
        {
            UpdateDisplay(container, screen);
            foreach (dynamic renderable in container.Childs)
            {
                Render(renderable, screen);
            }
        }
        private void Render(Label Renderer, ScreenDisplay screen)
        {
            UpdateDisplay(Renderer, screen);
        }

        private void UpdateDisplay(Renderable renderable, ScreenDisplay screen)
        {
        }
        private void UpdateDisplay(GiftUI renderable, ScreenDisplay screen)
        {
            for (int i = 0; i < renderable.Bound.Height; i++)
            {
                screen.DisplayString.Append(new string(GiftBase.FILLINGCHAR, renderable.Bound.Width));
                screen.DisplayString.Append('\n');
            }
        }
        private void UpdateDisplay(Label label, ScreenDisplay screen)
        {
            string display = label.GetVisibleText();
            Position globalPosition = GetGlobalPosition(label);
            Helper.Replace(screen.DisplayString, display, globalPosition.y * (screen.TotalBound.Width + 1) + globalPosition.x);
        }

        private static Position GetGlobalPosition(Label label)
        {
            int context_y = label?.Context?.GlobalPosition?.y ?? 0;
            int context_x = label?.Context?.GlobalPosition?.x ?? 0;
            int relative_y = label?.Disposition.Position?.y ?? 0;
            int relative_x = label?.Disposition.Position?.x ?? 0;
            int global_y = context_y + relative_y;
            int global_x = context_x + relative_x;
            Position globalPosition = new Position(global_y, global_x);
            return globalPosition;
        }
    }
}
