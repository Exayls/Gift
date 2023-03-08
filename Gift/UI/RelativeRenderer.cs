using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;
using System.Text;

namespace Gift.UI
{
    /// <summary>
    /// Render the UI to a TextWriter
    /// </summary>
    public class RelativeRenderer : IRenderer
    {
        public RelativeRenderer()
        {
        }

        public TextWriter GetRenderedBuffer(IGiftUI giftUI)
        {
            return GetRenderedBuffer(giftUI, giftUI.GetDisplay());
        }
        public TextWriter GetRenderedBuffer(IGiftUI giftUI, IScreenDisplay screen)
        {
            Context context = new Context(new(0, 0), screen.TotalBound);
            Render(screen, giftUI, context);

            TextWriter Output = new StringWriter();
            Output.Write(screen.DisplayString);
            return Output;
        }

        private void Render(IScreenDisplay screen, Renderable Renderer, Context context)
        {
            IScreenDisplay display = CreateDisplay(Renderer, context);
            UpdateDisplay(screen, Renderer, context, display);
        }

        private void Render(IScreenDisplay screen, IContainer container, Context context)
        {
            IScreenDisplay display = CreateDisplay(container, context);
            RenderAllChilds(display, container, context);
            UpdateDisplay(screen, container, context, display);
        }

        private IScreenDisplay CreateDisplay(Renderable container, Context context)
        {
            return container.GetDisplay(context.Bounds);
        }

        private void UpdateDisplay(IScreenDisplay screen, Renderable renderable, Context context, IScreenDisplay display)
        {
            Position globalPosition = renderable.GetGlobalPosition(context);
            screen.AddDisplay(display, globalPosition);
        }

        private void RenderAllChilds(IScreenDisplay screen, IContainer container, Context context)
        {
            foreach (Renderable renderable in container.Childs)
            {
                RenderAnyRenderable(screen, container, context, renderable);
            }
        }

        private void RenderAnyRenderable(IScreenDisplay screen, IContainer container, Context context, Renderable renderable)
        {
            Context renderableContext = container.GetContextRenderable(renderable, context);
            //if (container.isVisible(renderable))//TODO
            //{
            switch (renderable)
            {
                case Container containerToRender:
                    Render(screen, containerToRender, renderableContext);
                    break;
                default:
                    Render(screen, renderable, renderableContext);
                    break;
            }
            //}
        }

    }
}
