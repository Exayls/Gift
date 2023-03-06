using Gift.UI;
using Gift.UI.Interface;
using Gift.UI.MetaData;
using System.Text;

namespace Gift
{
    /// <summary>
    /// Render the UI to a TextWriter
    /// </summary>
    public class Renderer : IRenderer
    {
        public Renderer()
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
            UpdateDisplay(screen, Renderer, context);
        }

        private void Render(IScreenDisplay screen, IContainer container, Context context)
        {
            UpdateDisplay(screen, container, context);
            RenderAllChilds(screen, container, context);
        }

        private void UpdateDisplay(IScreenDisplay screen, Renderable renderable, Context context)
        {
            IScreenDisplay display = renderable.GetDisplay(context.Bounds);
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
