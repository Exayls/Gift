using Gift.UI.Border;
using Gift.UI.Configuration;
using Gift.UI.Display;
using Gift.UI.MetaData;

namespace Gift.UI.Element
{
    public class HStack : Container
    {

        public override int Height
        {
            get
            {
                if (Bound.Height != 0)
                {
                    return Bound.Height;
                }
                int maxHeightChild = 0;
                foreach (IUIElement renderable in Childs)
                {
                    if (!renderable.IsFixed())
                    {
                        if (maxHeightChild < renderable.Height)
                            maxHeightChild = renderable.Height;
                    }
                }
                return Border.Thickness * 2 + maxHeightChild;
            }
        }
        public override int Width
        {
            get
            {
                if (Bound.Width != 0)
                {
                    return Bound.Width;
                }
                int WidthAllChilds = 0;
                foreach (IUIElement renderable in Childs)
                {
                    if (!renderable.IsFixed())
                    {
                        WidthAllChilds += renderable.Width;
                    }
                }
                return Border.Thickness * 2 + WidthAllChilds;
            }
        }

        public HStack(IBorder border, IScreenDisplayFactory screenDisplayFactory) : this(border, screenDisplayFactory, new Bound(0, 0))
        {
        }

        public HStack(IBorder border, IScreenDisplayFactory screenDisplayFactory, Bound bound) : base(screenDisplayFactory, bound, border)
        {
        }

        public void AddChild(IUIElement uIElement)
        {
            Childs.Add(uIElement);
        }


        public override Context GetContextRenderable(IRenderable renderable, Context context)
        {
            int ChildContextPosition = GetWidthRenderable(renderable);
            if (renderable.IsFixed())
            {
                return new Context(
                    context.Position,
                    new Bound(0, 0));
            }
            else
            {
                int thickness = Border.Thickness;
                return new Context(
                    new Position(thickness + context.Position.y
                               , thickness + ChildContextPosition + context.Position.x),
                    new Bound(renderable.Height, renderable.Width));
            }
        }
        public override Context GetContextRelativeRenderable(IRenderable renderable, Context context)
        {
            int ChildContextPosition = GetWidthRenderable(renderable);
            if (renderable.IsFixed())
            {
                return new Context(
                    new Position(0
                               , ChildContextPosition),
                    new Bound(0, 0));
            }
            else
            {
                return new Context(
                    new Position(0
                               , ChildContextPosition),
                    new Bound(renderable.Height, renderable.Width));
            }
        }

        private int GetWidthRenderable(IRenderable renderableToFind)
        {
            int ChildContextPosition = 0;
            foreach (IUIElement renderable in Childs)
            {
                if (!renderable.IsFixed())
                {
                    if (renderable == renderableToFind)
                    {
                        return ChildContextPosition;
                    }
                    ChildContextPosition += renderable.Width;
                }
            }
            return 0;
        }

        public override bool IsFixed()
        {
            return false;
        }

        public override Position GetRelativePosition(Context context)
        {
            return new Position(context.Position.y,
                                context.Position.x);
        }
        public override Position GetGlobalPosition(Context context)
        {
            return new Position(context.Position.y,
                                context.Position.x);
        }

        public override IScreenDisplay GetDisplay(Bound bound)
        {
            return GetDisplayWithBorder(bound, GiftBase.FILLINGCHAR);
        }

        public IScreenDisplay GetDisplayWithBorder(Bound bound, char fillingChar)
        {
            int thickness = Border.Thickness;
            IScreenDisplay screenDisplay = GetDisplayBorder(bound, new DefaultConfiguration());
            IScreenDisplay emptyVstackScreen = GetDisplayWithoutBorder(bound, new DefaultConfiguration());
            screenDisplay.AddDisplay(emptyVstackScreen, new Position(thickness, thickness));
            return screenDisplay;
        }

        public override IScreenDisplay GetDisplayWithoutBorder(Bound bound, IConfiguration configuration)
        {
            int thickness = Border.Thickness;
            Bound boundEmptyVStack = new Bound(bound.Height - 2 * thickness, bound.Width - 2 * thickness);
            IScreenDisplay emptyVstackScreen = _screenDisplayFactory.Create(boundEmptyVStack, FrontColor ?? configuration.DefaultFrontColor, BackColor ?? configuration.DefaultBackColor, GiftBase.FILLINGCHAR);
            return emptyVstackScreen;
        }

    }
}