using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI
{
    public class Renderer : IRenderer
    {
        public Renderer()
        {
        }

        public IScreenDisplay GetRenderDisplay(IGiftUI giftUI)
        {
            var screen = giftUI.GetDisplay();
            Context context = new Context(new(0, 0), screen.TotalBound);
            Render(screen, giftUI, context);
            return screen;
        }

        private void Render(IScreenDisplay screen, IRenderable Renderer, Context context)
        {
            UpdateDisplay(screen, Renderer, context);
        }

        private void Render(IScreenDisplay screen, IContainer container, Context context)
        {
            UpdateDisplay(screen, container, context);
            RenderAllChilds(screen, container, context);
        }

        private void UpdateDisplay(IScreenDisplay screen, IRenderable renderable, Context context)
        {
            IScreenDisplay display = renderable.GetDisplay(context.Bounds);
            Position globalPosition = renderable.GetGlobalPosition(context);
            screen.AddDisplay(display, globalPosition);
        }

        private void RenderAllChilds(IScreenDisplay screen, IContainer container, Context context)
        {
            foreach (IRenderable renderable in container.Childs)
            {
                RenderAnyRenderable(screen, container, context, renderable);
            }
        }

        private void RenderAnyRenderable(IScreenDisplay screen, IContainer container, Context context, IRenderable renderable)
        {
            Context renderableContext = container.GetContextRenderable(renderable, context);
            switch (renderable)
            {
                case Container containerToRender:
                    Render(screen, containerToRender, renderableContext);
                    break;
                default:
                    Render(screen, renderable, renderableContext);
                    break;
            }
        }

    }
}
