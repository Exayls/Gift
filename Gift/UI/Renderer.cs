using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public class Renderer : IRenderer
    {
        public IConfiguration Configuration { get; }

        public Renderer(IConfiguration? configuration = null)
        {
            Configuration = configuration ?? new DefaultConfiguration();
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
            IScreenDisplay display = CreateDisplay(Renderer, context);
            AddDisplayToSreen(screen, Renderer, context, display);
        }

        private void Render(IScreenDisplay screen, IContainer container, Context context)
        {
            IScreenDisplay border = CreateBorder(container, context);

            IScreenDisplay display = CreateDisplay(container, context);
            RenderAllChilds(display, container, context);
            AddDisplayToBorder(border, container, display);

            AddDisplayToSreen(screen, container, context, border);
        }

        private IScreenDisplay CreateDisplay(IRenderable container, Context context)
        {
            return container.GetDisplayWithoutBorder(context.Bounds, Configuration);
        }

        private void AddDisplayToBorder(IScreenDisplay screen, IContainer renderable, IScreenDisplay display)
        {
            Position relativePosition = new Position(renderable.Border.Thickness, renderable.Border.Thickness);
            screen.AddDisplay(display, relativePosition);
        }

        private IScreenDisplay CreateBorder(IContainer container, Context context)
        {
            return container.GetDisplayBorder(context.Bounds, Configuration);
        }

        private void AddDisplayToSreen(IScreenDisplay screen, IRenderable renderable, Context context, IScreenDisplay display)
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
