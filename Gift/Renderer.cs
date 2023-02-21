﻿using Gift.UI;
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

        private void Render(ScreenDisplay screen, Renderable Renderer, Context context)
        {
            UpdateDisplay(screen, Renderer, context);
        }

        public TextWriter GetRenderedBuffer(IGiftUI giftUI)
        {
            ScreenDisplay screen = new ScreenDisplay(giftUI.Bound);
            Render(giftUI, screen);
            TextWriter Output = new StringWriter();
            Output.Write(screen.DisplayString);
            return Output;
        }

        private void Render(IGiftUI giftUI, ScreenDisplay screen)
        {
            Context context = new Context(new(0, 0), screen.TotalBound);
            UpdateDisplay(screen, giftUI, context);
            RenderAllChilds(screen, giftUI, context);
        }

        private void RenderAllChilds(ScreenDisplay screen, IContainer container, Context context)
        {
            foreach (Renderable renderable in container.Childs)
            {
                RenderAnyRenderable(screen, container, context, renderable);
            }
        }

        private void RenderAnyRenderable(ScreenDisplay screen, IContainer container, Context context, Renderable renderable)
        {
            Context renderableContext = container.GetContext(renderable, context);
            if (container.isVisible(renderable))
            {
                switch (renderable)
                {
                    case Container c:
                        Render(screen, c, renderableContext);
                        break;
                    default:
                        Render(screen, renderable, renderableContext);
                        break;
                }
            }
        }

        private void Render(ScreenDisplay screen, Container container, Context context)
        {
            UpdateDisplay(screen, container, context);
            RenderAllChilds(screen, container, context);
        }
        private void UpdateDisplay(IScreenDisplay screen, Renderable renderable, Context context)
        {
            IScreenDisplay display = renderable.GetDisplay(context.Bounds);
            Position globalPosition = renderable.GetGlobalPosition(context);
            screen.AddDisplay(display, globalPosition);
            //Helper.Replace(screen.DisplayString, display, globalPosition.y * (screen.TotalBound.Width + 1) + globalPosition.x);
        }

        //private void UpdateDisplay(ScreenDisplay screen, Label label, Context context)
        //{
        //    string display = label.GetDisplay();
        //    Position globalPosition = GetGlobalPosition(label, context);
        //    Helper.Replace(screen.DisplayString, display, globalPosition.y * (screen.TotalBound.Width + 1) + globalPosition.x);
        //}

        //private static Position GetGlobalPosition(Label label, Context context)
        //{
        //    int context_y = context.GlobalPosition?.y ?? 0;
        //    int context_x = context.GlobalPosition?.x ?? 0;
        //    int relative_y = label.Disposition.Position.y;
        //    int relative_x = label.Disposition.Position.x;
        //    int global_y = context_y + relative_y;
        //    int global_x = context_x + relative_x;
        //    Position globalPosition = new Position(global_y, global_x);
        //    return globalPosition;
        //}
    }
}
