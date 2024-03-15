using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Displayer.Rendering
{
    public class Renderer : IRenderer
    {
        private readonly IConfiguration _configuration;
        private readonly IColorResolver _colorResolver;

        public Renderer(IConfiguration configuration, IColorResolver colorResolver)
        {
            _configuration = configuration;
            _colorResolver = colorResolver;
        }

        public IScreenDisplay GetRenderDisplay(GiftUI giftUI)
        {
            Context context = new Context(new(0, 0), giftUI.Bound);
            IScreenDisplay screen = CreateDisplay(giftUI, context);
            Render(screen, giftUI, context);
            return screen;
        }

        private void Render(IScreenDisplay screen, Renderable renderable, Context context)
        {
            IScreenDisplay border = CreateBorder(renderable, context);
            IScreenDisplay display = CreateDisplay(renderable, context);
            AddDisplayToBorder(border, renderable, display);
            AddDisplayToSreen(screen, renderable, context, border);
        }

        private void Render(IScreenDisplay screen, Container container, Context context)
        {
            IScreenDisplay border = CreateBorder(container, context);

            IScreenDisplay display = CreateDisplay(container, context);
            RenderAllChilds(display, container, context);
            AddDisplayToBorder(border, container, display);

            AddDisplayToSreen(screen, container, context, border);
        }

        private IScreenDisplay CreateBorder(Renderable element, Context context)
        {
            return element.GetDisplayBorder(context.Bounds, _configuration, _colorResolver);
        }

        private IScreenDisplay CreateDisplay(Renderable container, Context context)
        {
            return container.GetDisplayWithoutBorder(context.Bounds, _configuration, _colorResolver);
        }

        private void AddDisplayToBorder(IScreenDisplay screen, Renderable renderable, IScreenDisplay display)
        {
            Position relativePosition = new Position(renderable.Border.Thickness, renderable.Border.Thickness);
            screen.AddDisplay(display, relativePosition);
        }

        private void AddDisplayToSreen(IScreenDisplay screen, Renderable renderable, Context context, IScreenDisplay display)
        {
            Position relativePosition = renderable.GetRelativePosition(context);
            screen.AddDisplay(display, relativePosition);
        }

        private void RenderAllChilds(IScreenDisplay screen, Container container, Context context)
        {
            lock (container.Childs)
            {
                foreach (Renderable renderable in container.Childs)
                {
                    RenderContainerOrElement(screen, container, context, renderable);
                }
            }
        }

        private void RenderContainerOrElement(IScreenDisplay screen, Container container, Context context, Renderable renderable)
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
