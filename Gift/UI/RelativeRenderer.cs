using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;

namespace Gift.UI
{
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

        private void Render(IScreenDisplay screen, IRenderable Renderer, Context context)
        {
            IScreenDisplay display = CreateDisplay(Renderer, context);
            UpdateScreenWithNewDisplay(screen, Renderer, context, display);
        }

        private void Render(IScreenDisplay screen, IContainer container, Context context)
        {
            IScreenDisplay display = CreateDisplay(container, context);
            RenderAllChilds(display, container, context);
            UpdateScreenWithNewDisplay(screen, container, context, display);
        }

        private IScreenDisplay CreateDisplay(IRenderable container, Context context)
        {
            return container.GetDisplay(context.Bounds);
        }

        private void UpdateScreenWithNewDisplay(IScreenDisplay screen, IRenderable renderable, Context context, IScreenDisplay display)
        {
            Position relativePosition = renderable.GetRelativePosition(context);
            screen.AddDisplay(display, relativePosition);
        }

        private void RenderAllChilds(IScreenDisplay screen, IContainer container, Context context)
        {
            foreach (IRenderable renderable in container.Childs)
            {
                RenderContainerOrElement(screen, container, context, renderable);
            }
        }

        private void RenderContainerOrElement(IScreenDisplay screen, IContainer container, Context context, IRenderable renderable)
        {
            Context renderableContext = container.GetContextRelativeRenderable(renderable, context);
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
