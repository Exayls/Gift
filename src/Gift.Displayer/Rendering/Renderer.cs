using Gift.Domain.ServiceContracts;
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

        public IScreenDisplay GetRenderDisplay(UIElement giftUI)
        {
            Position position = new Position(0, 0);
            IScreenDisplay border = CreateBorder(giftUI);
            IScreenDisplay screen = CreateDisplay(giftUI);
            AddDisplayToBorder(border, giftUI, screen);
            Render(screen, giftUI, position);
            return screen;
        }

        private void Render(IScreenDisplay screen, Renderable renderable, Position position)
        {
            IScreenDisplay border = CreateBorder(renderable);
            IScreenDisplay display = CreateDisplay(renderable);
            AddDisplayToBorder(border, renderable, display);
            AddDisplayToScreen(screen, renderable, position, border);
        }

        private void Render(IScreenDisplay screen, Container container, Position context)
        {
            IScreenDisplay border = CreateBorder(container);
            IScreenDisplay display = CreateDisplay(container);
            RenderAllChilds(display, container, context);
            AddDisplayToBorder(border, container, display);

            AddDisplayToScreen(screen, container, context, border);
        }

        private IScreenDisplay CreateBorder(Renderable element)
        {
            return element.GetDisplayBorder(_configuration, _colorResolver);
        }

        private IScreenDisplay CreateDisplay(Renderable container)
        {
            return container.GetDisplayWithoutBorder(_configuration, _colorResolver);
        }

        private void AddDisplayToBorder(IScreenDisplay screen, Renderable renderable, IScreenDisplay display)
        {
            Position relativePosition = new Position(renderable.Border.Thickness, renderable.Border.Thickness);
            screen.AddDisplay(display, relativePosition);
        }

        private void AddDisplayToScreen(IScreenDisplay screen, Renderable renderable, Position position, IScreenDisplay display)
        {
            Position relativePosition = renderable.GetRelativePosition(position);
            screen.AddDisplay(display, relativePosition);
        }

        private void RenderAllChilds(IScreenDisplay screen, Container container, Position context)
        {
            lock (container.Childs)
            {
                foreach (Renderable renderable in container.Childs)
                {
                    RenderContainerOrElement(screen, container, context, renderable);
                }
            }
        }

        private void RenderContainerOrElement(IScreenDisplay screen, Container container, Position context, Renderable renderable)
        {
            Position renderableContext = container.GetContext(renderable, context);
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
